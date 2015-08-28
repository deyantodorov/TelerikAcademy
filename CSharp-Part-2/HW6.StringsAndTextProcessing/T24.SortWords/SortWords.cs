namespace T24.SortWords
{
    using System;

    /// <summary>
    /// 24. Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.
    /// </summary>
    public class SortWords
    {
        private static void Main()
        {
            Console.Write("Write some words: ");
            string input = Console.ReadLine();
            string[] words = input.Split(' ');

            Array.Sort(words);

            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
