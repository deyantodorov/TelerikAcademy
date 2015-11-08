namespace T06.RemoveOddOccurNumbers
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 6. Write a program that removes from given sequence all numbers that occur odd number of times.
    ///    Example: {4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2} → {5, 3, 3, 5}
    /// 
    ///    I think there is MISTAKE. It should be even number of times.
    /// </summary>
    public class Program
    {
        private static void Main()
        {
            var list = new List<int> { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
            Console.WriteLine("Initial " + string.Join(", ", list));

            List<int> result = RemoveOddNumbers(list);
            Console.WriteLine("Even " + string.Join(", ", result));
        }

        private static List<int> RemoveOddNumbers(List<int> list)
        {
            var result = new List<int>();

            // place in dictionary
            var dict = FillDictionary(list);

            // find even from dictionary
            var even = FindEvenValues(dict);

            // filter odd from default list
            for (int i = 0; i < list.Count; i++)
            {
                var currentValue = list[i];

                if (even.ContainsKey(currentValue))
                {
                    result.Add(currentValue);
                }
            }

            return result;
        }

        private static Dictionary<int, int> FindEvenValues(Dictionary<int, int> dict)
        {
            var result = new Dictionary<int, int>();

            foreach (var item in dict)
            {
                if (item.Value % 2 == 0)
                {
                    result.Add(item.Key, item.Value);
                }
            }

            return result;
        }

        private static Dictionary<int, int> FillDictionary(List<int> list)
        {
            var result = new Dictionary<int, int>();

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
