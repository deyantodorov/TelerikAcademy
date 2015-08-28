namespace T11.BankAccountData
{
    using System;

    public class Person
    {
        private string firstName;
        private string middleName;
        private string lastName;

        public Person(string firstName, string middleName, string lastName)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                IsCorrectString(value);
                this.lastName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return this.middleName;
            }

            set
            {
                IsCorrectString(value);
                this.middleName = value;
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
                IsCorrectString(value);
                this.firstName = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", this.FirstName, this.MiddleName, this.LastName);
        }

        private static void IsCorrectString(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Invalid value " + value);
            }
        }
    }
}
