namespace T07.QuotesInStrings
{
    using System;

    /// <summary>
    /// 8. Declare two string variables and assign them with following value:
    ///    The \"use\" of quotations causes difficulties.
    ///    Do the above in two different ways: with and without using quoted strings.
    /// </summary>
    public class QuotesInStrings
    {
        private static void Main()
        {
            string a = "The \"use\" of quotations causes difficulties.";
            string b = @"The ""use"" of quotations causes difficulties.";

            Console.WriteLine(a);
            Console.WriteLine(b);
        }
    }
}