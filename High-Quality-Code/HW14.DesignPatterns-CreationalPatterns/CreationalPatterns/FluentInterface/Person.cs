using System;

namespace FluentInterface
{
    public class Person
    {
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        public override string ToString()
        {
            return $"Name {this.Name}, birth: {this.DateOfBirth}, address: {this.Address}";
        }
    }
}
