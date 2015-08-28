namespace T03.DecimalToHexadecimal
{
    using System;
    using Helper;

    /// <summary>
    /// 3. Write a program to convert decimal numbers to their hexadecimal representation.
    /// </summary>
    public class DecimalToHexadecimal
    {
        private static void Main()
        {
            long input = InputValidators.AsLong("Enter decimal value: ");
            string inputAsBinary = NumSys.DecToBinExact(input);
            string inputAsHex = NumSys.BinToHex(inputAsBinary);
            Console.WriteLine("Values in hexadecimal is: {0}", inputAsHex);
        }
    }
}
