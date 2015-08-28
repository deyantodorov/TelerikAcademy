namespace T02.IEnumerableExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Problem 2. IEnumerable extensions
    ///            Implement a set of extension methods for IEnumerable<T> that implement the following group functions: sum, product, min, max, average.
    /// </summary>
    public class TestingIEnumerable
    {
        private static void Main()
        {
            List<string> testOfStrings = new List<string>() { "az", "ti", "nie", "te" };
            List<char> testOfChars = new List<char>() { 'a', 'b', 'c' };
            List<int> num = new List<int>() { 1, 2, 3 };
            List<double> num2 = new List<double>() { 1.1, 2.2, 3.3 };

            Console.WriteLine(num.Sum());
            Console.WriteLine(num2.Sum());
            Console.WriteLine(testOfChars.Sum());
            Console.WriteLine(testOfStrings.Sum());

            // Product example
            Console.WriteLine(num.Product());
            Console.WriteLine(num2.Product());

            // Boom can't calculate product of string
            // Console.WriteLine(testOfStrings.Product());

            // Min example
            Console.WriteLine(num.Min());
            Console.WriteLine(num2.Min());

            //// Max example
            Console.WriteLine(num.Max());
            Console.WriteLine(num2.Max());

            //// Average example
            Console.WriteLine(num.Average());
            Console.WriteLine(num2.Average());
        }
    }
}