namespace T01.School
{
    using System;
    using System.Linq;
    using System.Text;
    using Common;
    using T01.School.Contracts;

    public abstract class People : IPeople, IComment
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private string comment;

        public People(string firstName, string middleName, string lastName)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            protected set
            {
                Validation.StringIsNullOrEmpty(value, "FirstName");
                this.firstName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return this.middleName;
            }

            protected set
            {
                Validation.StringIsNullOrEmpty(value, "MiddleName");
                this.middleName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            protected set
            {
                Validation.StringIsNullOrEmpty(value, "LastName");
                this.lastName = value;
            }
        }

        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.MiddleName + " " + this.LastName;
            }
        }

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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Name: {0}", this.FullName);

            if (this.Comment != null)
            {
                sb.AppendFormat(Environment.NewLine + "Comment of {0}: {1}", this.FullName, this.Comment);
            }

            return sb.ToString();
        }
    }
}
