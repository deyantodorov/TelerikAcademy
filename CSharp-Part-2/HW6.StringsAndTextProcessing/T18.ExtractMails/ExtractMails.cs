namespace T18.ExtractMails
{
    using System;
    using Helper;

    /// <summary>
    /// 18. Write a program for extracting all email addresses from given text. All substrings that match the format <identifier>@<host>…<domain> should be recognized as emails.
    /// </summary>
    public class ExtractMails
    {
        private static void Main()
        {
            string input = "Lorem pesho_peshev@vsgb.bg Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled misho_pishev@agb.bg it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, rambo@abv.bs.bg.co remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum pipi@yahoo.co.uk.";
            string pattern = @"([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})";
            Console.WriteLine(RegEx.Extractor(input, pattern));
        }
    }
}