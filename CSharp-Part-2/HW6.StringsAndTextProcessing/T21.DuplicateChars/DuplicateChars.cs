namespace T21.DuplicateChars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// 21. Write a program that reads a string from the console and prints all different letters in the string along with information how many times each letter is found. 
    /// </summary>
    public class DuplicateChars
    {
        public static string RemovePunctuation(string text)
        {
            StringBuilder sb = new StringBuilder(text.Length);

            string[] arrayOfText = text.Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in arrayOfText)
            {
                sb.Append(item);
            }

            return sb.ToString();
        }

        private static void Main()
        {
            Console.Write("Write something: ");
            string input = Console.ReadLine().ToLower();

            // Remove punctuation;
            string inputStripped = RemovePunctuation(input);

            // Find similar and different
            var g = from c in inputStripped.ToCharArray()
                    group c by c into m
                    select new { Key = m.Key, Count = m.Count() };

            Dictionary<char, int> letters = new Dictionary<char, int>();

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
