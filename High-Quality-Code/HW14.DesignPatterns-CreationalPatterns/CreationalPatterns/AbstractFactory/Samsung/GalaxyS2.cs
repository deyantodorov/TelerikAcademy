using AbstractFactory.Interfaces;

namespace AbstractFactory.Samsung
{
    public class GalaxyS2 : ISmartPhone
    {
        public string Name()
        {
            return "GalaxyS2";
        }
    }
}