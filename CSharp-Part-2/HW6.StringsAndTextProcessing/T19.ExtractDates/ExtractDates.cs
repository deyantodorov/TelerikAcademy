namespace T19.ExtractDates
{
    using System;
    using Helper;

    /// <summary>
    /// Write a program that extracts from a given text all dates that match the format DD.MM.YYYY. Display them in the standard date format for Canada.
    /// </summary>
    public class ExtractDates
    {
        private static void Main()
        {
            string input = "Lorem 12.10.2201 Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled 22.12.1001 it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, 12.12.2001 remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum 12.02.2201.";
            string pattern = @"(?<Month>\d{1,2})\.(?<Day>\d{1,2})\.(?<Year>(?:\d{4}|\d{2}))";
            Console.WriteLine(RegEx.Extractor(input, pattern));
        }
    }
}
