namespace StudentSystem.Data
{
    using System.Data.Entity;
    using StudentSystem.Data.Migrations;
    using StudentSystem.Models;

    public class StudentSystemDbContext : DbContext
    {
        public StudentSystemDbContext()
            : base("StudentSystemConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemDbContext, Configuration>());
        }

        public virtual IDbSet<Course> Courses { get; set; }

        public virtual IDbSet<Homework> Homeworks { get; set; }

        public virtual IDbSet<Student> Students { get; set; }

        public virtual IDbSet<Test> Tests { get; set; }
    }
}
