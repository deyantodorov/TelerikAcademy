namespace T04.HexadecimalToDecimal
{
    using System;
    using Helper;

    /// <summary>
    /// 4. Write a program to convert hexadecimal numbers to their decimal representation.
    /// </summary>
    public class HexadecimalToDecimal
    {
        private static void Main()
        {
            Console.Write("Enter hexadecimal value: ");
            string input = Console.ReadLine().ToUpper();
            Console.WriteLine("Decimal value is: {0}", NumSys.BinToUDec(NumSys.HexToBin(input)));
        }
    }
}