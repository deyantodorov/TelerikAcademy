using System;

namespace CompositePattern
{
    public class Worker : IEmployee
    {
        public Worker(string name, int hanppiness)
        {
            this.Name = name;
            this.Happiness = hanppiness;
        }

        public string Name { get; private set; }
        public int Happiness { get; private set; }

        public void ShowHappiness()
        {
            Console.WriteLine($"{this.Name} showed happiness level of {this.Happiness}");
        }
    }
}