using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyEcosystem
{
    public class Boar : Animal, ICarnivore, IHerbivore
    {
        private const int InitialBoarSize = 4;
        private int biteSize;

        public Boar(string name, Point position)
            : base(name, position, InitialBoarSize)
        {
            this.biteSize = 2;
        }

        public int EatPlant(Plant plant)
        {
            if (plant != null)
            {
                this.Size++;
                return plant.GetEatenQuantity(this.biteSize);
            }

            return 0;
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal != null && animal.Size <= this.Size)
            {
                return animal.GetMeatFromKillQuantity();
            }

            return 0;
        }
    }
}
