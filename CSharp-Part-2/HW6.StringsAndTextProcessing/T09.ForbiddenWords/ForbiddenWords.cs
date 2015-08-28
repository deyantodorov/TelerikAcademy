namespace T09.ForbiddenWords
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// 9. We are given a string containing a list of forbidden words and a text containing some of these words. 
    ///    Write a program that replaces the forbidden words with asterisks. 
    ///    
    ///    Example:
    ///    Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.
    ///    Words: "PHP, CLR, Microsoft"
    ///    
    ///    The expected result:
    ///    ********* announced its next generation *** compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in ***.
    /// </summary>
    public class ForbiddenWords
    {
        public static string HideForbiddenWords(Match match)
        {
            string result = match.Value.Replace(match.Value, new string('*', match.Value.Length));

            return result;
        }

        private static void Main()
        {
            string input = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
            string pattern = @"PHP|CLR|Microsoft";

            string result = Regex.Replace(input, pattern, new MatchEvaluator(HideForbiddenWords));

            Console.WriteLine(result);
        }
    }
}
