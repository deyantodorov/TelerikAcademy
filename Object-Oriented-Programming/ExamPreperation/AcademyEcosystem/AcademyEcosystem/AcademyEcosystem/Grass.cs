namespace AcademyEcosystem
{
    using System;
    using System.Linq;

    public class Grass : Plant
    {
        private const int InitialGrassSize = 2;

        public Grass(Point location)
            : base(location, InitialGrassSize)
        {
        }

        public override void Update(int timeElapsed)
        {
            this.Size += timeElapsed;
            base.Update(timeElapsed);
        }
    }
}
