namespace T05.RemoveNegativeNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// 5. Write a program that removes from given sequence all negative numbers.
    /// </summary>
    public class Program
    {
        private static void Main()
        {
            var list = new List<int>() { 1, 1, -1, 1, -2, 1, 3, 1, -2, 2, 2, 2, -2, 3, 3, 3, 1, -4, 4, 1 };
            var positive = list.Where(x => x >= 0).ToList();

            Console.WriteLine("Initial: " + string.Join(", ", list));
            Console.WriteLine("Only positive: " + string.Join(", ", positive));
        }
    }
}
