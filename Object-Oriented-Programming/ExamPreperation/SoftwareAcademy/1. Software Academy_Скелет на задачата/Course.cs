namespace SoftwareAcademy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using SoftwareAcademy.Common;
    using SoftwareAcademy.Contracts;

    public abstract class Course : ICourse
    {
        private readonly IList<string> topics;
        private string name;

        public Course(string name, ITeacher teacher)
        {
            this.Name = name;
            this.Teacher = teacher;
            this.topics = new List<string>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                Validate.StringIsNullOrEmpty(value, "Name");
                this.name = value;
            }
        }

        public ITeacher Teacher { get; set; }

        public void AddTopic(string topic)
        {
            Validate.StringIsNullOrEmpty(topic, "AddTopic");
            this.topics.Add(topic);
        }

        public override string ToString()
        {
            string print = this.GetCourseToString();
            return print;
        }

        private string GetCourseToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("{0}", this.GetType().Name);
            sb.AppendFormat(": Name={0}", this.Name);

            if (this.Teacher != null)
            {
                sb.AppendFormat("; Teacher={0}", this.Teacher.Name);
            }

            if (this.topics.Count > 0)
            {
                sb.Append("; Topics=[");

                for (int i = 0; i < this.topics.Count; i++)
                {
                    if (i < this.topics.Count - 1)
                    {
                        sb.AppendFormat("{0}, ", this.topics[i]);
                    }
                    else
                    {
                        sb.AppendFormat("{0}", this.topics[i]);
                    }
                }

                sb.Append("]");
            }

            return sb.ToString();
        }
    }
}
