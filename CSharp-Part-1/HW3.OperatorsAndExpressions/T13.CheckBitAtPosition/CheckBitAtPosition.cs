namespace T13.CheckBitAtPosition
{
    using System;
    using System.Linq;

    /// <summary>
    /// 13. Write a Boolean expression that returns if the bit at position p (counting from 0, starting from the right) in given integer number n, has value of 1.
    /// </summary>
    public class CheckBitAtPosition
    {
        private static void Main()
        {
            Console.WriteLine(IsOne(2, 5));
            Console.WriteLine(IsOne(9, 0));
            Console.WriteLine(IsOne(1, 15));
        }

        private static bool IsOne(int position, int number)
        {
            int bit = (number >> position) & 1;

            if (bit == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}