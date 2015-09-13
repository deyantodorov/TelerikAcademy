using AbstractFactory.Interfaces;

namespace AbstractFactory.Htc
{
    public class Titan : ISmartPhone
    {
        public string Name()
        {
            return "Titan";
        }
    }
}