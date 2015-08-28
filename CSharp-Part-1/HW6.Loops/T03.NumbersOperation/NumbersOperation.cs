namespace T03.NumbersOperation
{
    using Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// 3. Write a program that reads from the console a sequence of n integer numbers and returns the minimal, the maximal number, the sum and the average of all numbers 
    ///   (displayed with 2 digits after the decimal point).
    ///    The input starts by the number n (alone in a line) followed by n lines, each holding an integer number. The output is like in the examples below.
    /// </summary>
    public class NumbersOperation
    {
        private static void Main()
        {
            int num = Helpers.ValidateInputAsInt("How many numbers you would like to enter: ");
            List<double> numbers = new List<double>();

            // Fill array with numbers
            for (int i = 0; i < num; i++)
            {
                numbers.Add(Helpers.ValidateInputAsDouble("Enter value " + (i + 1) + ": "));
            }

            // Use of List methods
            Console.WriteLine("Minimal number is : {0}", numbers.Min());
            Console.WriteLine("Maximal number is : {0}", numbers.Max());
            Console.WriteLine("Sum number is : {0}", numbers.Sum());
            Console.WriteLine("Average number is : {0}", numbers.Average());
        }
    }
}