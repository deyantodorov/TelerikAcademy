namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Course : ICourse
    {
        private string name;
        private string teacherName;
        private IList<string> students;

        protected Course(string name)
        {
            this.Name = name;
        }

        protected Course(string name, string teacherName)
            : this(name)
        {
            this.TeacherName = teacherName;
        }

        protected Course(string name, string teacherName, IList<string> students)
            : this(name, teacherName)
        {
            this.Students = students;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.StringIsNotNullOrEmpty(value, "Name");
                this.name = value;
            }
        }

        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }

            set
            {
                this.StringIsNotNullOrEmpty(value, "Teacher name");
                this.teacherName = value;
            }
        }

        public IList<string> Students
        {
            get
            {
                return this.students;
            }

            set
            {
                this.IsNotNull(value, "Student");
                this.students = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("Name = ");
            result.Append(this.Name);

            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }

            if (this.Students != null)
            {
                result.Append("; Students = ");
                result.Append(this.GetStudentsAsString());
            }

            return result.ToString();
        }

        protected void StringIsNotNullOrEmpty(string value, string name)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(name + " can't be null or empty");
            }
        }

        protected void IsNotNull<T>(T value, string name)
        {
            if (value == null)
            {
                throw new ArgumentNullException(name + " can't be null");
            }
        }

        private string GetStudentsAsString()
        {
            return "{ " + string.Join(", ", this.Students) + " }";
        }
    }
}
