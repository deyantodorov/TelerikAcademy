namespace T05.ToUpperCase
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// 5. You are given a text. Write a program that changes the text in all regions surrounded by the tags 
    ///    <upcase> and </upcase> to uppercase. The tags cannot be nested. 
    ///    
    ///    Example:
    ///    We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.
    ///    The expected result:
    ///    We are living in a YELLOW SUBMARINE. We don't have ANYTHING else.
    ///    
    /// </summary>
    public class ToUpperCase
    {
        public static string ToUpperRemoveTags(Match match)
        {
            string result = match.Value.Replace("<upcase>", string.Empty).Replace("</upcase>", string.Empty).ToUpper();

            return result;
        }

        private static void Main()
        {
            string input = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";

            string pattern = @"\<upcase\>(.*?)\<\/upcase\>";

            string newText = Regex.Replace(input, pattern, new MatchEvaluator(ToUpperRemoveTags));

            Console.WriteLine(newText);
        }
    }
}
