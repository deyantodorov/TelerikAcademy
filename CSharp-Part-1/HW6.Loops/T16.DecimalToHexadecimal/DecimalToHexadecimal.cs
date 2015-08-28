namespace T16.DecimalToHexadecimal
{
    using System;
    using System.Linq;
    using Common;

    /// <summary>
    /// 16. Using loops write a program that converts an integer number to its hexadecimal representation.
    ///     The input is entered as long. The output should be a variable of type string. 
    ///     Do not use the built-in .NET functionality.
    /// </summary>
    public class DecimalToHexadecimal
    {
        private static void Main()
        {
            long input = Helpers.ValidateInputAsLong("Enter decimal value: ");
            string inputAsBinary = NumericalSystems.DecToBinExact(input);
            string inputAsHex = NumericalSystems.BinToHex(inputAsBinary);
            Console.WriteLine("Values in hexadecimal is: {0}", inputAsHex);
        }
    }
}