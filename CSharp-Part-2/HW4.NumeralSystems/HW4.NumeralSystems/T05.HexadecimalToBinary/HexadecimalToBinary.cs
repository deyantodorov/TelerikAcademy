namespace T05.HexadecimalToBinary
{
    using System;
    using Helper;

    /// <summary>
    /// 5. Write a program to convert hexadecimal numbers to binary numbers (directly).
    /// </summary>
    public class HexadecimalToBinary
    {
        private static void Main()
        {
            Console.Write("Enter hexadecimal value: ");
            string input = Console.ReadLine().ToUpper();
            Console.WriteLine("Binary value is: {0}", NumSys.HexToBin(input));
        }
    }
}