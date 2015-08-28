namespace T04.UnicodeCharacter
{
    using System;

    /// <summary>
    /// 4. Declare a character variable and assign it with the symbol that has Unicode code 42 (decimal) using the \u00XX syntax, and then print it.
    /// </summary>
    public class UnicodeCharacter
    {
        private static void Main()
        {
            char hex = '\u002A';
            Console.WriteLine(hex);
        }
    }
}