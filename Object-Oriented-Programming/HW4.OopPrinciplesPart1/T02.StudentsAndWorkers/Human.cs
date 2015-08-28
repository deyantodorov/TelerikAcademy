namespace T02.StudentsAndWorkers
{
    using System;
    using System.Linq;
    using T02.StudentsAndWorkers.Contracts;

    public abstract class Human : IHuman
    {
        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
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

            protected set
            {
                this.lastName = value;
            }
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            protected set
            {
                this.firstName = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.FirstName, this.LastName);
        }
    }
}