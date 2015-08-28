namespace T03.AnimalHierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using T03.AnimalHierarchy.Contracts;

    public abstract class Animal : IAnimal, ISound
    {
        private int age;
        private string name;

        public Animal(int age, string name)
        {
            this.Age = age;
            this.Name = name;
        }

        public virtual Sex Sex { get; set; }

        public string Name
        {
            get
            {
                return this.name;
            }

            protected set
            {
                Validation.StringIsNullOrEmpty(value, "Name");
                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            protected set
            {
                Validation.LessThanZero<int>(value, 0, "Age");
                this.age = value;
            }
        }

        public static double AverageAge(IEnumerable<IAnimal> animals)
        {
            double average = animals.Average(x => x.Age);
            return average;
        }

        public abstract string Sound();

        public override string ToString()
        {
            return string.Format("I'm: {0}, Age: {1}, Name: {2}", this.GetType().Name, this.Age, this.Name);
        }
    }
}
