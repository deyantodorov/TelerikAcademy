using System;
using AbstractFactory.Htc;
using AbstractFactory.Interfaces;
using AbstractFactory.Nokia;
using AbstractFactory.Samsung;

namespace AbstractFactory
{
    /// <summary>
    /// This is Client for comunication
    /// </summary>
    public class PhoneTypeChecker
    {
        private IPhoneFactory factory;
        private readonly Manufacturer manufacturer;

        public PhoneTypeChecker(Manufacturer chosenManufacturer)
        {
            this.manufacturer = chosenManufacturer;
        }

        public void CheckProducts()
        {
            switch (this.manufacturer)
            {
                case Manufacturer.Samsung:
                    this.factory = new SamsungFactory();
                    break;
                case Manufacturer.Htc:
                    this.factory = new HtcFactory();
                    break;
                case Manufacturer.Nokia:
                    this.factory = new NokiaFactory();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Unsupported type of Factory");
            }

            Console.WriteLine(this.manufacturer.ToString());
            Console.WriteLine($"Smart Phone: {this.factory.GetSmartPhone().Name()}");
            Console.WriteLine($"Simple Phone: {this.factory.GetSimplePhone().Name()}");
        }
    }
}