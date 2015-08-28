namespace T12.ParseUrl
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// 12. Write a program that parses an URL address given in the format:
    ///     and extracts from it the [protocol], [server] and [resource] elements. 
    ///     For example from the URL http://telerikacademy.com/Courses/Courses/Details/212 the following information should be extracted:
    ///     
    ///     [protocol] = "http"
    ///     [server] = "telerikacademy.com"
    ///     [resource] = "/Courses/Courses/Details/212"
    /// </summary>
    public class ParseUrl
    {
        public static string UrlExtractor(string input)
        {
            StringBuilder sb = new StringBuilder();

            // Lets start with crazzy Regular expressions:
            // Limit to the ":"
            string protocol = Regex.Match(input, @"([^:])+").ToString();
            sb.Append("Protocol: ");
            sb.Append(protocol);
            sb.Append(Environment.NewLine);

            // Start from here "://" and exclude it and take [a-zA-Z0-9.] this will grab "domain.com" only
            string server = Regex.Match(input, @"(?<=://)[a-zA-Z0-9.]+").ToString();
            sb.Append("Server: ");
            sb.Append(server);
            sb.Append(Environment.NewLine);

            // Start from domain, exclude it and take the rest
            string resource = Regex.Match(input, @"(?<=((?<=://)[a-zA-Z0-9.]+))/.*").ToString();
            sb.Append("Resource: ");
            sb.Append(resource);

            return sb.ToString();
        }

        private static void Main()
        {
            Console.Write("Place some URL: ");
            string input = Console.ReadLine();
            Console.WriteLine(UrlExtractor(input));
        }
    }
}
