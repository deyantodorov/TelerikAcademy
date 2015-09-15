using System;
using System.Collections.Generic;

namespace CompositePattern
{
    public class Supervisor : IEmployee
    {
        private readonly List<IEmployee> subordinate;

        public Supervisor(string name, int hanppiness)
        {
            this.Name = name;
            this.Happiness = hanppiness;
            this.subordinate = new List<IEmployee>();
        }

        public string Name { get; private set; }
        public int Happiness { get; private set; }

        public void ShowHappiness()
        {
            Console.WriteLine($"{this.Name} showed happiness level of {this.Happiness}");
            this.subordinate.ForEach(x => x.ShowHappiness());
        }

        public void AddSubordinate(IEmployee employee)
        {
            this.subordinate.Add(employee);
        }
    }
}