using AbstractFactory.Interfaces;

namespace AbstractFactory.Samsung
{
    public class Primo : ISimplePhone
    {
        public string Name()
        {
            return "Guru";
        }
    }
}