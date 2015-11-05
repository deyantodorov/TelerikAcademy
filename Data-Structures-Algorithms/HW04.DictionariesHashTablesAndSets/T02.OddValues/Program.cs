namespace T02.OddValues
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// 2. Write a program that extracts from a given sequence of strings all elements that present in it odd number of times. Example:
    /// {C#, SQL, PHP, PHP, SQL, SQL } -> {C#, SQL}
    /// </summary>
    public class Program
    {
        private static void Main()
        {
            var array = new string[] { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };
            var odd = CountRepeatedValues(array);

            odd.ForEach(x => Console.Write(x + " "));
            Console.WriteLine();
        }

        private static List<string> CountRepeatedValues(string[] array)
        {
            var dict = new Dictionary<string, int>();

            foreach (string value in array)
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

            var result = (from pair in dict
                          where pair.Value % 2 != 0
                          select pair.Key)
                        .ToList();

            return result;
        }
    }
}
