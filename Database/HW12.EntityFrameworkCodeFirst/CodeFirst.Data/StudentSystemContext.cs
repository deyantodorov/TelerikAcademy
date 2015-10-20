namespace CodeFirst.Data
{
    using CodeFirst.Models;
    using System.Data.Entity;

    public class StudentSystemContext:DbContext
    {
        public StudentSystemContext()
            : base("StudentSystemDB")
        {
        }

        public DbSet<Course> Courses { get; set; }
        
        public DbSet<Homework> Homeworks { get; set; }

        public DbSet<Material> Materials { get; set; }

        public DbSet<Student> Students { get; set; }

    }
}
