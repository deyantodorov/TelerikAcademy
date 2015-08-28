namespace T23.RemoveIdentical
{
    using System;
    using System.Text;

    /// <summary>
    /// 23. Write a program that reads a string from the console and replaces all series of consecutive identical letters with a single one. 
    ///     Example: "aaaaabbbbbcdddeeeedssaa" -> "abcdedsa".
    /// </summary>
    public class RemoveIdentical
    {
        public static string RemoveDuplicateChars(string input)
        {
            StringBuilder result = new StringBuilder();

            result.Append(input[0]);

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i - 1] != input[i])
                {
                    result.Append(input[i]);
                }
            }

            return result.ToString();
        }

        private static void Main()
        {
            Console.Write("Write string of letters: ");
            string input = Console.ReadLine();

            Console.WriteLine("Result is: {0}", RemoveDuplicateChars(input));
        }
    }
}
