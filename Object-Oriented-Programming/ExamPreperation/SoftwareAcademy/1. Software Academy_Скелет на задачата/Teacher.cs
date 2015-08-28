namespace SoftwareAcademy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using SoftwareAcademy.Common;
    using SoftwareAcademy.Contracts;

    public class Teacher : ITeacher
    {
        private readonly IList<ICourse> courses;
        private string name;
        
        public Teacher(string name)
        {
            this.Name = name;
            this.courses = new List<ICourse>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                Validate.StringIsNullOrEmpty(value, "Teacher Name");
                this.name = value;
            }
        }

        public void AddCourse(ICourse course)
        {
            Validate.IsNull(course, "Teacher AddCourse");
            this.courses.Add(course);
        }

        public override string ToString()
        {
            string print = this.GetTeacherToString();
            return print.ToString();
        }

        // Teacher: Name=Svetlin Nakov; Courses=[OOP, HTML]
        private string GetTeacherToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(string.Format("Teacher: Name={0}", this.Name));

            if (this.courses.Count > 0)
            {
                sb.Append("; Courses=[");

                for (int i = 0; i < this.courses.Count; i++)
                {
                    if (i < this.courses.Count - 1)
                    {
                        sb.Append(string.Format("{0}, ", this.courses[i].Name));
                    }
                    else
                    {
                        sb.Append(string.Format("{0}", this.courses[i].Name));
                    }
                }

                sb.Append("]");
            }

            return sb.ToString();
        }
    }
}