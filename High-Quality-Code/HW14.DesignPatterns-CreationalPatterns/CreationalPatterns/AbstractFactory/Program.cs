using System;

namespace AbstractFactory
{
    /// <summary>
    /// This example demosnstrate usage of abstract factory pattern
    /// 3 independent factories with independent products
    /// Client class PhoneTypeChecker which get information based on user input 
    /// </summary>
    public class Program
    {
        private static void Main()
        {
            var phoneTypeChecker = new PhoneTypeChecker(Manufacturer.Samsung);
            phoneTypeChecker.CheckProducts();

            Console.WriteLine();

            phoneTypeChecker = new PhoneTypeChecker(Manufacturer.Htc);
            phoneTypeChecker.CheckProducts();

            Console.WriteLine();

            phoneTypeChecker = new PhoneTypeChecker(Manufacturer.Nokia);
            phoneTypeChecker.CheckProducts();
        }
    }
}
