namespace T11.RandomNumbersRange
{
    using System;
    using System.Linq;
    using Common;

    /// <summary>
    /// 11. Write a program that enters 3 integers n, min and max (min != max) and prints n random numbers in the range [min...max].
    /// </summary>
    public class RandomNumbersRange
    {
        private static readonly Random rand = new Random();

        private static void Main()
        {
            var n = Helpers.ValidateInputAsInt("How many numbers: ");
            var min = Helpers.ValidateInputAsInt("Min value: ");
            var max = Helpers.ValidateInputAsInt("Max value: ");

            for (int i = 0; i < n; i++)
            {
                Console.Write(rand.Next(min, max + 1) + " ");
            }

            Console.WriteLine();
        }
    }
}