using AbstractFactory.Interfaces;

namespace AbstractFactory.Htc
{
    public class HtcFactory : IPhoneFactory
    {
        public ISimplePhone GetSimplePhone()
        {
            return new Genie();
        }

        public ISmartPhone GetSmartPhone()
        {
            return new Titan();
        }
    }
}