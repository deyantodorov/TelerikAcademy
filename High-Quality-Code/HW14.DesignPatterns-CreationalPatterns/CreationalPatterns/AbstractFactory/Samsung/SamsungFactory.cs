using AbstractFactory.Interfaces;

namespace AbstractFactory.Samsung
{
    public class SamsungFactory : IPhoneFactory
    {
        public ISimplePhone GetSimplePhone()
        {
            return new Primo();
        }

        public ISmartPhone GetSmartPhone()
        {
            return new GalaxyS2();
        }
    }
}