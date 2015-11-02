namespace StudentSystem.Models
{
    using System;
    using System.Collections.Generic;

    public class Test
    {
        private ICollection<Student> students;

        public Test()
        {
            this.students = new HashSet<Student>();
        }

        public int Id { get; set; }

        public virtual ICollection<Student> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }

        public virtual Guid CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}