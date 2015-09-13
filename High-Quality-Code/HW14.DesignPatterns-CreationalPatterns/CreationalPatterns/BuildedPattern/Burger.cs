using BuildedPattern.Interfaces;

namespace BuildedPattern
{
    public abstract class Burger : IItem
    {
        public abstract string Name();

        public IPackable Packing()
        {
            return  new Wrapper();
        }

        public abstract float Price();
    }
}
