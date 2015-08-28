namespace T01.NumbersFrom1toN
{
    using System;
    using System.Linq;
    using Common;

    /// <summary>
    /// 1. Write a program that enters from the console a positive integer n and prints all the numbers from 1 to n, on a single line, separated by a space.
    /// </summary>
    public class NumbersFrom1toN
    {
        private static void Main()
        {
            int n = Helpers.ValidateInputAsInt("Enter positive integer for N = ");
            int count = 1;

            while (count <= n)
            {
                Console.Write(count + " ");
                count++;
            }

            Console.WriteLine();
        }
    }
}