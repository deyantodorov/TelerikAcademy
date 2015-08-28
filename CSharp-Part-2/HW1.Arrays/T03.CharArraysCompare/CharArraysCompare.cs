namespace T03.CharArraysCompare
{
    using System;

    /// <summary>
    /// 3. Write a program that compares two char arrays lexicographically (letter by letter).
    /// </summary>
    public class CharArraysCompare
    {
        private static void Main()
        {
            char[] firstArray = new char[] { 'm', 'a', 'l', 'l' };
            char[] secondArray = new char[] { 'm', 'a', 'c', 'k', 'a' };

            string first = new string(firstArray);
            string second = new string(secondArray);

            int result = first.CompareTo(second);

            if (result < 0)
            {
                Console.WriteLine("First array is first lexicographically.");
            }
            else if (result > 0)
            {
                Console.WriteLine("Second array is first lexicographically.");
            }
            else
            {
                Console.WriteLine("Both arrays are equal.");
            }
        }
    }
}
