namespace T14.ModifyBitAtGivenPosition
{
    using System;
    using System.Linq;

    /// <summary>
    /// 14.  Ware given an integer number n, a bit value v (v=0 or 1) and a position p.
    ///      Write a sequence of operators (a few lines of C# code) that modifies n to hold the value v at the position p from the binary representation of n while preserving all other bits in n.
    /// </summary>
    public class ModifyBitAtGivenPosition
    {
        private static void Main()
        {
            int n = ReadAndValidateInput("Enter integer number: ");
            int p = ReadAndValidateInput("Which bit need to be changed: ");
            byte v = IsValidBit("Choose 0 or 1: ");

            if (v == 1)
            {
                int mask = 1 << p;
                int maskOrN = mask | n;
                Console.WriteLine("Result in decimal is: {0}", maskOrN);
                Console.WriteLine("Result in binary is ({0}): {1}", n, Convert.ToString(n, 2).PadLeft(31, '0'));
                Console.WriteLine("Result in binary is ({0}): {1}", maskOrN, Convert.ToString(maskOrN, 2).PadLeft(31, '0'));
            }
            else
            {
                int mask = ~(1 << p);
                int maskAndN = mask & n;
                Console.WriteLine("Result in decimal is: {0}", maskAndN);
                Console.WriteLine("Result in binary is ({0}): {1}", n, Convert.ToString(n, 2).PadLeft(31, '0'));
                Console.WriteLine("Result in binary is ({0}): {1}", maskAndN, Convert.ToString(maskAndN, 2).PadLeft(31, '0'));
            }
        }

        private static byte IsValidBit(string msg)
        {
            byte v;

            Console.Write(msg);

            bool isValid = byte.TryParse(Console.ReadLine(), out v);

            while (isValid == false || v > 1)
            {
                Console.Write("Invalid value! Choose 0 or 1: ");
                isValid = byte.TryParse(Console.ReadLine(), out v);
                Console.WriteLine(v);
            }

            return v;
        }

        private static int ReadAndValidateInput(string msg)
        {
            int number;

            Console.Write(msg);

            bool isValid = int.TryParse(Console.ReadLine(), out number);
            while (isValid == false)
            {
                Console.Write("Invalid number! {0}", msg);
                isValid = int.TryParse(Console.ReadLine(), out number);
            }

            return number;
        }
    }
}