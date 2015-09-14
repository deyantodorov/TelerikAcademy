using System;

namespace FluentInterface
{
    public class PersonFluent
    {
        private readonly Person person = new Person();

        public PersonFluent NameOfPerson(string name)
        {
            this.person.Name = name;
            return this;
        }

        public PersonFluent BornAt(string dateOfBirth)
        {
            this.person.DateOfBirth = Convert.ToDateTime(dateOfBirth);
            return this;
        }

        public PersonFluent Address(string address)
        {
            this.person.Address = address;
            return this;
        }

        public override string ToString()
        {
            return this.person.ToString();
        }
    }
}
