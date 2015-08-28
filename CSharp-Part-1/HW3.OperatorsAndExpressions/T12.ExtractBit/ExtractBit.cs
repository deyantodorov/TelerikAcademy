namespace T12.ExtractBit
{
    using System;
    using System.Linq;

    /// <summary>
    /// 12. Write an expression that extracts from given integer n the value of given bit at index p.
    /// </summary>
    public class ExtractBit
    {
        private static void Main()
        {
            int i = ReadAndValidateInput("Number: ");
            int b = ReadAndValidateInput("Bit position: ");
            
            int bit = (i >> b) & 1;

            Console.WriteLine("Bit in position {0} of number {1} is {2}", b, i, bit);
            Console.WriteLine(i + " in binary is " + Convert.ToString(i, 2).PadLeft(31, '0'));
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