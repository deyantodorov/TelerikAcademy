using System;
using System.Linq;

namespace AcademyEcosystem
{
    public class Wolf : Animal, ICarnivore
    {
        private const int InitialWolfSize = 4;

        public Wolf(string name, Point position)
            : base(name, position, InitialWolfSize)
        {
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal != null && (animal.Size <= this.Size || animal.State == AnimalState.Sleeping))
            {
                return animal.GetMeatFromKillQuantity();
            }

            return 0;
        }
    }
}
