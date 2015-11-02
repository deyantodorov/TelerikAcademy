namespace StudentSystem.Data.Repositories
{
    using System.Data.Entity;
    using StudentSystem.Models;


    public interface IStudentSystemData
    {
        DbContext Context { get; }

        IRepository<Course> Courses { get; }

        IRepository<Homework> Homeworks { get; }

        IRepository<Student> Students { get; }

        IRepository<Test> Tests { get; }

        void Dispose();

        int SaveChanges();
    }
}
