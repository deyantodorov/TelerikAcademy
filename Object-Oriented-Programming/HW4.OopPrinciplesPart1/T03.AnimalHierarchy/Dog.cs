namespace T03.AnimalHierarchy
{
    using System;
    using System.Linq;
    using T03.AnimalHierarchy.Contracts;

    public class Dog : Animal, IAnimal, ISound
    {
        public Dog(int age, string name)
            : base(age, name)
        {
        }

        public override string Sound()
        {
            return "Bau bau";
        }
    }
}
