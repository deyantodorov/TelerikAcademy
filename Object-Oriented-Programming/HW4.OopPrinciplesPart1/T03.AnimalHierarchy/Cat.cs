namespace T03.AnimalHierarchy
{
    using System;
    using T03.AnimalHierarchy.Contracts;

    public abstract class Cat : Animal, IAnimal, ISound
    {
        public Cat(int age, string name)
            : base(age, name)
        {
        }

        public Sex Sex { get; protected set; }
    }
}
