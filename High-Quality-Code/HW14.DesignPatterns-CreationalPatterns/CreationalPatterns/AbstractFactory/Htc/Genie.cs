using AbstractFactory.Interfaces;

namespace AbstractFactory.Htc
{
    public class Genie : ISimplePhone
    {
        public string Name()
        {
            return "Genie";
        }
    }
}