namespace T01.OddOrEven
{
    using System;
    using System.Linq;

    public class OddOrEven
    {
        private static void Main()
        {
            int[] numbers = { 3, 2, -2, -1, 0 };

            GetOddOrEven(numbers);
        }
        private static void GetOddOrEven(int[] numbers)
        {
            int firstBit;

            for (int i = 0; i < numbers.Length; i++)
            {
                firstBit = (numbers[i] >> 0) & 1;

                if (firstBit == 0)
                {
                    Console.WriteLine("{0} is Even", numbers[i]);
                }
                else if (firstBit == 1)
                {
                    Console.WriteLine("{0} is Odd", numbers[i]);
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
        }
    }
}