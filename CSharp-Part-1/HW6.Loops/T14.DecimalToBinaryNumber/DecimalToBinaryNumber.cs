namespace T14.DecimalToBinaryNumber
{
    using System;
    using System.Linq;
    using Common;

    /// <summary>
    /// 14. Using loops write a program that converts an integer number to its binary representation.
    ///     The input is entered as long. The output should be a variable of type string.
    ///     Do not use the built-in .NET functionality.
    /// </summary>
    public class DecimalToBinaryNumber
    {
        private static void Main()
        {
            long input = Helpers.ValidateInputAsLong("Enter decimal number to 64-bit value: ");
            Console.WriteLine(NumericalSystems.DecToBin(input));
        }
    }
}