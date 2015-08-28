namespace T03.AnimalHierarchy
{
    using System;
    using System.Linq;
    using T03.AnimalHierarchy.Contracts;

    public class Tomcat : Cat, IAnimal, ISound
    {
        public Tomcat(int age, string name)
            : base(age, name)
        {
            this.Sex = Sex.Male;
        }

        public override string Sound()
        {
            return "Grr grr";
        }
    }
}
