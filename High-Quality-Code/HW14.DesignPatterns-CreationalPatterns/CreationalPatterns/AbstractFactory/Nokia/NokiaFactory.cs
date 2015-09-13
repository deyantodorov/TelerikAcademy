using AbstractFactory.Interfaces;

namespace AbstractFactory.Nokia
{
    public class NokiaFactory : IPhoneFactory
    {
        public ISimplePhone GetSimplePhone()
        {
            return new Asha();
        }

        public ISmartPhone GetSmartPhone()
        {
            return new Lumia();
        }
    }
}