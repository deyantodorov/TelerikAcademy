namespace T01.School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using T01.School.Contracts;

    public class Classes : IComment
    {
        private string comment;

        public Classes()
        {
            this.Teachers = new HashSet<Teacher>();
            this.Students = new HashSet<Student>();
        }

        public TextIdentifier TextIdentifier { get; set; }

        public HashSet<Teacher> Teachers { get; set; }

        public HashSet<Student> Students { get; set; }

        public string Comment
        {
            get
            {
                return this.comment;
            }

            set
            {
                Validation.StringIsNullOrEmpty(value, "Comment");
                this.comment = value;
            }
        }
    }
}