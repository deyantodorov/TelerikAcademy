using AbstractFactory.Interfaces;

namespace AbstractFactory.Nokia
{
    public class Asha : ISimplePhone
    {
        public string Name()
        {
            return "Asha";
        }
    }
}