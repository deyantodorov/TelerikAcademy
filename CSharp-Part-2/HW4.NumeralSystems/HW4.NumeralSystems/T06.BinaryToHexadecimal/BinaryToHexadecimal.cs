namespace T06.BinaryToHexadecimal
{
    using System;
    using Helper;

    /// <summary>
    /// 6. Write a program to convert binary numbers to hexadecimal numbers (directly).
    /// </summary>
    public class BinaryToHexadecimal
    {
        private static void Main()
        {
            Console.Write("Enter binary value: ");
            string input = Console.ReadLine();
            Console.WriteLine("Hexadecimal value is: {0}", NumSys.BinToHex(input));
        }
    }
}
