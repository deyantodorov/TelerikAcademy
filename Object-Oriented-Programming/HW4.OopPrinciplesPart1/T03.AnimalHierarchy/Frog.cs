namespace T03.AnimalHierarchy
{
    using System;
    using System.Linq;
    using T03.AnimalHierarchy.Contracts;

    public class Frog : Animal, IAnimal, ISound
    {
        public Frog(int age, string name)
            : base(age, name)
        {
        }

        public override string Sound()
        {
            return "Kwak kwak";
        }
    }
}
