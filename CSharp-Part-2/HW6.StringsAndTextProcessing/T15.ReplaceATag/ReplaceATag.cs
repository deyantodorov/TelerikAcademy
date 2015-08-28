namespace T15.ReplaceATag
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// 15. Write a program that replaces in a HTML document given as string all the tags <a href="…">…</a> with corresponding tags [URL=…]…[/URL]. 
    /// 
    /// Sample HTML fragment:
    /// <p>Please visit <a href="http://academy.telerik. com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>
    /// 
    /// Example:
    /// <p>Please visit [URL=http://academy.telerik. com]our site[/URL] to choose a training course. Also visit [URL=www.devbg.org]our forum[/URL] to discuss the courses.</p>
    /// </summary>
    public class ReplaceATag
    {
        private static void Main()
        {
            string html = "<p>Please visit <a href=\"http://academy.telerik.com\">our site</a> to choose a training course. Also visit <a href=\"www.devbg.org\">our forum</a> to discuss the courses.</p>";

            string pattern = "<a\\shref=\"(?<url>[^\"\\r\\n]*)\">(?<text>.*?)</a>";
            string newPatt = @"[URL=${url}]${text}[/URL]";

            string newText = Regex.Replace(html, pattern, newPatt);

            Console.WriteLine(html);
            Console.WriteLine();
            Console.WriteLine(newText);
        }
    }
}
