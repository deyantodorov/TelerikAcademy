namespace T15.HexadecimalToDecimal
{
    using Common;
    using System;
    using System.Linq;

    /// <summary>
    /// 15. Using loops write a program that converts a hexadecimal integer number to its decimal form.
    ///     The input is entered as string. The output should be a variable of type long. 
    ///     Do not use the built-in .NET functionality.
    /// </summary>
    public class HexadecimalToDecimal
    {
        private static void Main()
        {
            Console.Write("Enter hexadecimal value: ");
            string input = Console.ReadLine().ToUpper();
            Console.WriteLine("Decimal value is: {0}", NumericalSystems.BinToUDec(NumericalSystems.HexToBin(input)));
        }
    }
}