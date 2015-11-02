namespace StudentSystem.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using StudentSystem.Data.Repositories;
    using StudentSystem.Models;

    public class StudentSystemData : IStudentSystemData
    {
        private readonly DbContext context;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public StudentSystemData(DbContext context)
        {
            this.context = context;
        }

        public DbContext Context
        {
            get { return this.context; }
        }

        public IRepository<Course> Courses
        {
            get { return this.GetRepository<Course>(); }
        }

        public IRepository<Homework> Homeworks
        {
            get { return this.GetRepository<Homework>(); }
        }

        public IRepository<Student> Students
        {
            get { return this.GetRepository<Student>(); }
        }

        public IRepository<Test> Tests
        {
            get { return this.GetRepository<Test>(); }
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>
        /// The number of objects written to the underlying database.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">Thrown if the context has been disposed.</exception>
        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && this.context != null)
            {
                this.context.Dispose();
            }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (this.repositories.ContainsKey(typeof(T)))
            {
                return (IRepository<T>)this.repositories[typeof(T)];
            }

            var type = typeof(Repository<T>);
            this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}
