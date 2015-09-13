using AbstractFactory.Interfaces;

namespace AbstractFactory.Nokia
{
    public class Lumia : ISmartPhone
    {
        public string Name()
        {
            return "Lumia";
        }
    }
}