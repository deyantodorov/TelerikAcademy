namespace StudentSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using StudentSystem.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentSystemDbContext>
    {
        public Configuration()
        {
            // TODO: Set to False in production
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StudentSystemDbContext context)
        {
            if (!context.Students.Any())
            {
                AddStudent(context);
            }
        }

        private static void AddStudent(StudentSystemDbContext context)
        {
            var student = new Student
            {
                FirstName = "Ivan",
                LastName = "Ivanov",
                StudentInfo =
                {
                    Address = "Sofia",
                    Email = "ivan.ivanov@abv.bg"
                }
            };

            context.Students.Add(student);
            context.SaveChanges();
        }
    }
}
