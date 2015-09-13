using BuildedPattern.Interfaces;

namespace BuildedPattern
{
    public abstract class ColdDrink : IItem
    {
        public abstract string Name();

        public IPackable Packing()
        {
            return new Bottle();
        }

        public abstract float Price();
    }
}
