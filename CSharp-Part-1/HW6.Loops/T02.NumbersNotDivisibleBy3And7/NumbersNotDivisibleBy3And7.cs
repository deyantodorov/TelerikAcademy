namespace T02.NumbersNotDivisibleBy3And7
{
    using Common;
    using System;
    using System.Linq;

    /// <summary>
    /// 2. Write a program that enters from the console a positive integer n and prints all the numbers from 1 to n not divisible by 3 and 7, on a single line, separated by a space.
    /// </summary>
    public class NumbersNotDivisibleBy3And7
    {
        private static void Main()
        {
            int n = Helpers.ValidateInputAsInt("Enter positive integer for N = ");
            int count = 0;

            for (int i = 1; i <= n; i++)
            {
                if (i % 3 == 0 || i % 7 == 0)
                {
                    continue;
                }

                count++;
                Console.Write(i + " ");
            }

            Console.WriteLine();
        }
    }
}