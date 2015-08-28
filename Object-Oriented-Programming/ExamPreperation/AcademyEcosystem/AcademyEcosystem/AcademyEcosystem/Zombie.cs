using System;
using System.Linq;

namespace AcademyEcosystem
{
    public class Zombie : Animal
    {
        private const int ZombieMeatSize = 10;

        public Zombie(string name, Point position)
            : base(name, position, 0)
        {
        }

        public override int GetMeatFromKillQuantity()
        {
            return ZombieMeatSize;
        }
    }
}
