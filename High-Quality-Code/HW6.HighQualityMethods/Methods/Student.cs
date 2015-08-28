namespace Methods
{
    using System;

    public class Student
    {
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        private string description;

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                this.ValidateStringIsNullOrEmpty(value, "First name");
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                this.ValidateStringIsNullOrEmpty(value, "Last name");
                this.lastName = value;
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return this.dateOfBirth;
            }

            set
            {
                this.dateOfBirth = value;
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }

            set
            {
                this.ValidateStringIsNullOrEmpty(value, "Description");
                this.description = value;
            }
        }

        public bool IsOlder(Student student)
        {
            // 1 is default year in DateTime format
            if (this.DateOfBirth.Year == 1 || student.DateOfBirth.Year == 1)
            {
                throw new ArgumentNullException("No information about date of birth for Students");
            }

            return this.DateOfBirth > student.DateOfBirth;
        }

        private void ValidateStringIsNullOrEmpty(string value, string name)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(name + " can't be null or empty");
            }
        }
    }
}
