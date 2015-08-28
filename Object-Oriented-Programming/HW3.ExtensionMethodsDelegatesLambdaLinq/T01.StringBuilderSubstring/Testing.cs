namespace T01.StringBuilderSubstring
{
    using System;
    using System.Text;
    using Common;

    /// <summary>
    /// Problem 1. StringBuilder.Substring
    ///            Implement an extension method Substring(int index, int length) for the class StringBuilder that returns new StringBuilder and has the same functionality as Substring in the class String.
    /// </summary>
    public class Testing
    {
        private static void Main()
        {
            StringBuilder sb = new StringBuilder(GenerateRandom.Text(20));

            Console.WriteLine("Before: " + sb);
            sb = sb.Substring(0, 10);
            Console.WriteLine("After: " + sb);
        }
    }
}