namespace T01.DescribeStrings
{
    using System;

    /// <summary>
    /// 1. Describe the strings in C#. What is typical for the string data type? Describe the most important methods of the String class.
    /// </summary>
    public class DescribeStrings
    {
        private static void Main()
        {
            string description = "Strings can be easy explained as array of chars. Strings are immutable and and their value is read-only. Most important methods are: CompareTo, IndexOf, IndexOfAny, Remove, Replace, Split, Substring, ToUpper, ToLower, Trim, Concat, Format. Very good class for strings manipulation is StringBuilder.";
            Console.WriteLine(description);
        }
    }
}
