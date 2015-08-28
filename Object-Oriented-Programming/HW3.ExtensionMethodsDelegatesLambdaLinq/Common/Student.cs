namespace Common
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Student
    {
        private const int MaxAge = 130;

        private string firstName;
        private string lastName;
        private int age;

        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Marks = new List<int>();
        }

        public int Fn { get; set; }

        public string Tel { get; set; }

        public string Email { get; set; }

        public List<int> Marks { get; set; }

        // I know groupNumber has to be equal to this.GroupNumber, but I don't want to refactor everything. 
        // This property need to be removed next time, because it's used in Group class
        public int GroupNumber { get; set; }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                this.ValidateNullOrEmpty(value);
                this.lastName = value;
            }
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                this.ValidateNullOrEmpty(value);
                this.firstName = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                this.ValidateAge(value);
                this.age = value;
            }
        }

        // I know groupNumber has to be equal to this.GroupNumber, but I don't want to refactor everything.
        public Group Group { get; set; }
        
        public string MarksPrint()
        {
            if (this.Marks.Count == 0)
            {
                return "No marks";
            }

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < this.Marks.Count; i++)
            {
                sb.Append(this.Marks[i]);

                if (i != this.Marks.Count - 1)
                {
                    sb.Append(", ");
                }
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("{0} {1}", this.FirstName, this.LastName));

            if (this.Age != 0)
            {
                sb.Append(", ");
                sb.Append("Age: " + this.Age);
            }

            if (this.Fn != 0)
            {
                sb.Append(", ");
                sb.Append("Fn: " + this.Fn);
            }

            if (this.Tel != null)
            {
                sb.Append(", ");
                sb.Append("Tel: " + this.Tel);
            }

            if (this.Email != null)
            {
                sb.Append(", ");
                sb.Append("Email: " + this.Email);
            }

            if (this.GroupNumber != 0)
            {
                sb.Append(", ");
                sb.Append("GroupNumber: " + this.GroupNumber);
            }

            if (this.Marks.Count > 0)
            {
                sb.AppendLine(this.MarksPrint());
            }

            return sb.ToString();
        }

        private void ValidateAge(int value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("You are too young to play with this class. Can't be less than zero");
            }
            else if (value > MaxAge)
            {
                throw new ArgumentOutOfRangeException("You are too old to play with this class. Can't be greater than " + MaxAge);
            }
        }

        private void ValidateNullOrEmpty(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Value can't be null");
            }
        }
    }
}
