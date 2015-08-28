namespace T04.InsensitiveSearch
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// 4. Write a program that finds how many times a substring is contained in a given text (perform case insensitive search).
    ///    Example: The target substring is "in". The text is as follows:
    ///    
    ///    We are living in an yellow submarine. We don't have anything else. 
    ///    Inside the submarine is very tight. So we are drinking all the day. 
    ///    We will move out of it in 5 days.
    ///    
    ///    The result is: 9.
    /// </summary>
    public class InsensitiveSearch
    {
        public static int FindMatch(string text, string pattern)
        {
            Match match = Regex.Match(text, pattern, RegexOptions.IgnoreCase);

            int counter = 0;

            while (match.Success)
            {
                counter++;
                match = match.NextMatch();
            }

            return counter;
        }

        private static void Main()
        {
            string text = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
            string pattern = @"in";

            Console.WriteLine("The result is: {0}", FindMatch(text, pattern));
        }
    }
}
