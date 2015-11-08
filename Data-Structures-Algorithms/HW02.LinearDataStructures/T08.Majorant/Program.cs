namespace T08.Majorant
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 8. The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times.
    ///    Write a program to find the majorant of given array(if exists).
    ///    Example: {2, 2, 3, 3, 2, 3, 4, 3, 3} → 3
    /// </summary>
    public class Program
    {
        private static void Main()
        {
            var numbers = new List<int>() { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
            var texts = new List<string>() { "da", "ne", "da", "da", "ne", "da", "ra", "bo", "da", "da", "da" };

            var majorantForNumber = FindMajorant(numbers);
            var majorantForText = FindMajorant(texts);

            Console.WriteLine("Majorant numbers: " + majorantForNumber);
            Console.WriteLine("Majorant texts: " + majorantForText);
        }

        private static T FindMajorant<T>(List<T> list) where T : IComparable
        {
            var visited = new List<bool>();
            list.ForEach(x => visited.Add(false));

            var count = (list.Count / 2) + 1;
            var found = 0;
            var majorant = default(T);

            for (int i = 0; i < list.Count; i++)
            {
                var current = list[i];

                for (int j = i + 1; j < list.Count; j++)
                {
                    if (current.CompareTo(list[j]) != 0 || visited[j])
                    {
                        continue;
                    }

                    visited[j] = true;
                    found++;
                }

                if (found >= count)
                {
                    majorant = current;
                }
            }

            return majorant;
        }
    }
}
