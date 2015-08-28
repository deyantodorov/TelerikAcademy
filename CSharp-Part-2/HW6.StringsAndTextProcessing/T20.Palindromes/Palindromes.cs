namespace T20.Palindromes
{
    using System;

    /// <summary>
    /// 20. Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".
    /// </summary>
    public class Palindromes
    {
        public static string ReverseWord(string word)
        {
            char[] arrayOfWord = word.ToCharArray();
            Array.Reverse(arrayOfWord);

            return new string(arrayOfWord);
        }

        public static bool IsPalindrom(string word)
        {
            return ReverseWord(word) == word;
        }

        private static void Main()
        {
            string input = "Lorem Ipsum is lamal simply dummy bob text of the printing rur and typesetting industry. Lorem Ipsum sos has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a ABBA galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but lamal also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in ABBA the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software exe like Aldus PageMaker including versions of Lorem Ipsum exe";

            string[] inputWords = input.Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < inputWords.Length; i++)
            {
                // I don't need single chars
                if (inputWords[i].Length > 1)
                {
                    if (IsPalindrom(inputWords[i]))
                    {
                        Console.WriteLine("Word \"{0}\" is palindrome.", inputWords[i]);
                    }
                }
            }
        }
    }
}