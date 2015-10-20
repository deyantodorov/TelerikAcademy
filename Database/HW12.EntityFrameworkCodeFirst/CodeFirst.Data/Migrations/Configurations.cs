namespace CodeFirst.Data.Migrations
{
    using CodeFirst.Models;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public class Configurations : DbMigrationsConfiguration<StudentSystemContext>
    {
        public Configurations()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StudentSystemContext context)
        {
            context.Courses.AddOrUpdate(
                c => c.Name,
                    new Course
                    {
                        Name = "Database and SQL", Description = "Telerik Academy Course on DB"
                    },
                    new Course
                    {
                        Name = "DSA", Description = "Data Structures and Algorithms"
                    }
                );

            context.Students.AddOrUpdate(
                s => s.Name,
                    new Student
                    {
                        Name ="Mircho Mirchev", FacultyNumber="123123"
                    },
                    new Student
                    {
                        Name ="Svircho Svircheve", FacultyNumber="321321"
                    },
                    new Student
                    {
                        Name ="Pencho Penchev", FacultyNumber="213213"
                    }
                );

            context.Students
                .Where(x => x.FacultyNumber == "123123")
                .First()
                .Courses.Add(context.Courses.Where(c => c.Name == "DSA").First());

            context.Students
                .Where(x => x.FacultyNumber == "213213")
                .First()
                .Courses.Add(context.Courses.Where(c => c.Name == "Database and SQL").First());

            context.Students
                .Where(x => x.FacultyNumber == "213213")
                .First()
                .Courses.Add(context.Courses.Where(c => c.Name == "DSA").First());

            context.Students
                .Where(x => x.FacultyNumber == "321321")
                .First()
                .Courses.Add(context.Courses.Where(c => c.Name == "Database and SQL").First());

            context.SaveChanges();
        }
    }
}
