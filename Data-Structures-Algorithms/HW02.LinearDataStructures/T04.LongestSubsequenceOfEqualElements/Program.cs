namespace T04.LongestSubsequenceOfEqualElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// 4. Write a method that finds the longest subsequence of equal numbers in given List and returns the result as new List<int>.
    ///    Write a program to test whether the method works correctly.
    /// </summary>
    public class Program
    {
        private static void Main()
        {
            var list = new List<int>() { 1, 1, 1, 1, 2, 1, 3, 1, 2, 2, 2, 2, 2, 3, 3, 3, 1, 4, 4, 1 };

            var result = FindLongestSubsequence(list);

            Console.WriteLine("The longest subsequence of equal numbers: " + string.Join(", ", result));
        }

        private static List<int> FindLongestSubsequence(List<int> list)
        {
            var top = new List<int>();
            var current = new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                current.Add(list[i]);

                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[i] != list[j])
                    {
                        break;
                    }

                    current.Add(list[j]);
                }

                if (current.Count > top.Count)
                {
                    top = new List<int>(current);
                }

                current.Clear();
            }

            return top.ToList();
        }
    }
}