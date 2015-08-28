namespace Helper
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class RegEx
    {
        /// <summary>
        /// Extract values by predefined pattern. Example: date, email etc. It depends on pattern. If results not found return string with text "No result".
        /// </summary>
        public static string Extractor(string input, string pattern)
        {
            StringBuilder sb = new StringBuilder();
            Match match = Regex.Match(input, pattern);

            while (match.Success)
            {
                sb.Append(match.Value);
                sb.Append(Environment.NewLine);

                match = match.NextMatch();
            }

            if (sb.Length > 0)
            {
                // Remove last blank line
                sb.Remove(sb.Length - 1, 1);
                return sb.ToString();
            }
            else
            {
                return "No result";
            }
        }
    }
}
