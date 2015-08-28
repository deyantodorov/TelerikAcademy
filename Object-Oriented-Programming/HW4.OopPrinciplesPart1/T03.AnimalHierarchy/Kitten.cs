namespace T03.AnimalHierarchy
{
    using System;
    using System.Linq;
    using T03.AnimalHierarchy.Contracts;

    public class Kitten : Cat, IAnimal, ISound
    {
        public Kitten(int age, string name)
            : base(age, name)
        {
            this.Sex = Sex.Female;
        }

        public override string Sound()
        {
            return "May may";
        }
    }
}
