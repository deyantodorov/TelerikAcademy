namespace T25.StripHtmlTags
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;

    /// <summary>
    /// 25. Write a program that extracts from given HTML file its title (if available), and its body text without the HTML tags. 
    ///     Example:
    ///     <html>
    ///         <head><title>News</title></head>
    ///             <body>
    ///                 <p><a href="http://academy.telerik.com">Telerik Academy</a>aims to provide free real-world practical training for young people who want to turn into
    ///             skillful .NET software engineers.</p>
    ///             </body>
    ///    </html>
    /// </summary>
    public class StripHtmlTags
    {
        public static string GrabContent(string input)
        {
            string bodyOnly = Regex.Match(input, @"<body[^>]*>(.*?)<\/body>", RegexOptions.Singleline).Value.ToString();
            string removeTags = Regex.Replace(bodyOnly, @"<.*?>", " ");
            string textOnly = Regex.Replace(removeTags, @"\s*?(\r\n|\n|\r|\t)\s*", " ");
            textOnly = textOnly.Trim();

            return textOnly;
        }

        public static string GrabTitle(string input)
        {
            string title = Regex.Match(input, @"(?<=<title>)(?<title>.*)?(?=</title>)").Value.ToString();

            return title;
        }

        private static void Main()
        {
            StreamReader reader = new StreamReader("file.html");
            string input = string.Empty;

            using (reader)
            {
                input = reader.ReadToEnd();
            }

            string title = GrabTitle(input);

            string content = GrabContent(input);

            if (title != string.Empty)
            {
                Console.WriteLine("Title: {0}", title);
            }

            if (content != string.Empty)
            {
                Console.WriteLine("Content: {0}", content);
            }
        }
    }
}
