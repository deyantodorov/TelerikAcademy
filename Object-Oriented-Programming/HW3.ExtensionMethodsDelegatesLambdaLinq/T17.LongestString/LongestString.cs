namespace T17.LongestString
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;

    /// <summary>
    /// Problem 17. Longest string
    ///             Write a program to return the string with maximum length from an array of strings.
    ///             Use LINQ.
    ///             
    /// https://github.com/TelerikAcademy/Object-Oriented-Programming/blob/master/03.%20Extension-Methods-Delegates-Lambda-LINQ/README.md#problem-17-longest-string
    /// </summary>
    public class LongestString
    {
        private static void Main()
        {
            List<string> array = GenerateRandomStrings();
            Console.WriteLine("Expression result: " + Expression(array));
            Console.WriteLine("Linq result: " + Linq(array));
        }

        private static string Expression(List<string> someStrings)
        {
            var selected = someStrings.OrderByDescending(s => s.Length).FirstOrDefault();
            return selected;
        }

        private static string Linq(List<string> someStrings)
        {
            var selected = from s in someStrings
                           orderby s.Length descending
                           select s;

            return selected.Count() > 0 ? selected.First() : null;
        }

        private static List<string> GenerateRandomStrings()
        {
            List<string> list = new List<string>();
            int count = GenerateRandom.Number(10, 30);

            for (int i = 0; i < count; i++)
            {
                string current = GenerateRandom.Text(GenerateRandom.Number(count, 30));
                list.Add(current);
            }

            return list;
        }
    }
}