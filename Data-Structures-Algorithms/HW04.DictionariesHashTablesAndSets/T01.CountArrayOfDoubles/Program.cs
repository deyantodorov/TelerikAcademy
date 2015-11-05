namespace T01.CountArrayOfDoubles
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 1. Write a program that counts in a given array of double values the number of occurrences of each value. Use Dictionary.
    ///    Example: array = {3, 4, 4, -2.5, 3, 3, 4, 3, -2.5}
    ///    -2.5 -> 2 times
    ///    3 -> 4 times
    ///    4 -> 3 times
    /// </summary>
    public class Program
    {

        private static void Main()
        {
            var array = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };
            CountRepeatedValues(array);
        }

        private static void CountRepeatedValues(double[] array)
        {
            var dict = new SortedDictionary<double, int>();

            foreach (double value in array)
            {
                if (!dict.ContainsKey(value))
                {
                    dict.Add(value, 1);
                }
                else
                {
                    dict[value] += 1;
                }
            }

            foreach (var pair in dict)
            {
                Console.WriteLine("{0} -> {1} times", pair.Key, pair.Value);
            }
        }
    }
}
