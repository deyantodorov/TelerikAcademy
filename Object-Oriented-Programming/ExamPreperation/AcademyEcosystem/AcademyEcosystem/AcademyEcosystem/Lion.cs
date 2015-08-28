using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyEcosystem
{
    public class Lion : Animal, ICarnivore
    {
        private const int InitialLionSize = 6;

        public Lion(string name, Point position)
            : base(name, position, InitialLionSize)
        {
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal != null && animal.Size <= this.Size * 2)
            {
                this.Size++;
                return animal.GetMeatFromKillQuantity();
            }

            return 0;
        }
    }
}
