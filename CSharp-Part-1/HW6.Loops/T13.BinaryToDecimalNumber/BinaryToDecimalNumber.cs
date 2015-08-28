namespace T13.BinaryToDecimalNumber
{
    using System;
    using System.Linq;
    using Common;

    public class BinaryToDecimalNumber
    {
        private static void Main()
        {
            Console.Write("Enter some binary value: ");
            string input = Console.ReadLine();

            Console.WriteLine("To unsigned decimal: {0}", NumericalSystems.BinToUDec(input));
            Console.WriteLine("To signed decimal: {0}", NumericalSystems.BinToSDec(input));
        }
    }
}