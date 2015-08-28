namespace MobilePhone
{
    using System;

    public class Person
    {
        private string firstName;
        private string lastName;

        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
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
                DataValidator.StringNullEmptyValidation("LastName", value);
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
                DataValidator.StringNullEmptyValidation("FirstName", value);
                this.firstName = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.FirstName, this.LastName);
        }
    }
}
