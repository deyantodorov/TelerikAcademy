namespace T02.BinaryToDecimal
{
    using System;
    using Helper;

    /// <summary>
    /// 2. Write a program to convert binary numbers to their decimal representation.
    /// </summary>
    public class BinaryToDecimal
    {
        private static void Main()
        {
            Console.Write("Enter some binary value: ");
            string input = Console.ReadLine();

            Console.WriteLine("To unsigned decimal: {0}", NumSys.BinToUDec(input));
            Console.WriteLine("To signed decimal: {0}", NumSys.BinToSDec(input));
        }
    }
}