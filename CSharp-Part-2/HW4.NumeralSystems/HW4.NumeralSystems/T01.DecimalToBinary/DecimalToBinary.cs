namespace T01.DecimalToBinary
{
    using System;
    using Helper;

    /// <summary>
    /// 1. Write a program to convert decimal numbers to their binary representation.
    /// </summary>
    public class DecimalToBinary
    {
        private static void Main()
        {
            long input = InputValidators.AsLong("Enter decimal number to 64-bit value: ");
            Console.WriteLine(NumSys.DecToBin(input));
        }
    }
}