namespace T07.SumOf5Numbers
{
    using System;
    using System.Linq;

    /// <summary>
    /// 7. Write a program that enters 5 numbers (given in a single line, separated by a space), calculates and prints their sum.
    /// </summary>
    public class SumOf5Numbers
    {
        private static void Main()
        {
            Console.Write("Enter 5 integers separated with space: ");
            string input = Console.ReadLine();

            string[] inputArray = input.Split(' ');

            long sum = 0;
            
            for (int i = 0; i < inputArray.Length; i++)
            {
                sum += long.Parse(inputArray[i]);
            }

            Console.WriteLine(sum);
        }
    }
}