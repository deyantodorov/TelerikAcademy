namespace T22.DuplicateWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// 22. Write a program that reads a string from the console and lists all different words in the string along with information how many times each word is found.
    /// </summary>
    public class DuplicateWords
    {
        private static void Main()
        {
            Console.Write("Write something: ");
            string input = Console.ReadLine().ToLower();

            // Words in array
            string[] words = input.Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            // Find similar and different
            var g = from c in words
                    group c by c into m
                    select new { Key = m.Key, Count = m.Count() };

            Dictionary<string, int> letters = new Dictionary<string, int>();

            foreach (var item in g.OrderBy(i => i.Key))
            {
                letters.Add(item.Key, item.Count);
            }

            Console.WriteLine();

            // Print differnt
            Console.WriteLine("DIFFERENT: ");
            foreach (var item in letters.OrderBy(i => i.Value))
            {
                if (item.Value == 1)
                {
                    Console.WriteLine("Letter: {0} : repeats: {1}", item.Key, item.Value);
                }
            }

            Console.WriteLine();

            // Print same
            Console.WriteLine("SAME: ");
            foreach (var item in letters.OrderBy(i => i.Value))
            {
                if (item.Value > 1)
                {
                    Console.WriteLine("Letter: {0} : repeats: {1}", item.Key, item.Value);
                }
            }
        }
    }
}
