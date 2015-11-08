namespace T07.HowManyTimesEachOccurs
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 7. Write a program that finds in given array of integers (all belonging to the range [0..1000]) how many times each of them occurs.
    /// </summary>
    public class Program
    {
        private static void Main()
        {
            var list = new List<int>() { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
            var dict = FillDictionary(list);

            foreach (var item in dict)
            {
                Console.WriteLine(item.Key + " -> " + item.Value + " times");
            }
        }

        private static SortedDictionary<int, int> FillDictionary(List<int> list)
        {
            var result = new SortedDictionary<int, int>();

            for (int i = 0; i < list.Count; i++)
            {
                var currentValue = list[i];

                if (result.ContainsKey(currentValue))
                {
                    result[currentValue] += 1;
                }
                else
                {
                    result.Add(currentValue, 1);
                }
            }

            return result;
        }
    }
}
