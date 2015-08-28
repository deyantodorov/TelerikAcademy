namespace T11.ExtractBit
{
    using System;
    using System.Linq;

    /// <summary>
    /// 11. Using bitwise operators, write an expression for finding the value of the bit #3 of a given unsigned integer.
    //      The bits are counted from right to left, starting from bit #0.
    //      The result of the expression should be either 1 or 0.
    /// </summary>
    public class ExtractBit
    {
        private static void Main()
        {
            int v = ReadAndValidateInput("Find bit in number: ");
            int p = ReadAndValidateInput("Bit position: ");

            int bit = (v >> p) & 1;

            if (bit == 1)
            {
                Console.WriteLine("True. Bit in position {0} of number {1} is 1", p, v);
                Console.WriteLine(v + " in binary is " + Convert.ToString(v, 2).PadLeft(8, '0'));
            }
            else
            {
                Console.WriteLine("False. Bit in position {0} of number {1} is 0", p, v);
                Console.WriteLine(v + " in binary is " + Convert.ToString(v, 2).PadLeft(31, '0'));
            }
        }

        private static int ReadAndValidateInput(string msg)
        {
            int number;

            Console.Write(msg);

            bool isValid = int.TryParse(Console.ReadLine().ToString().Replace('.', ','), out number);
            while (isValid == false)
            {
                Console.Write("Invalid number! {0}", msg);
                isValid = int.TryParse(Console.ReadLine().ToString().Replace('.', ','), out number);
            }

            return number;
        }
    }
}