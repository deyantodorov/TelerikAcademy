namespace T10.ExtractFromXml
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;

    /// <summary>
    /// 10. Write a program that extracts from given XML file all the text without the tags.
    /// </summary>
    public class ExtractFromXml
    {
        public static void ReadExtract(string inputFile, string outputFile)
        {
            StreamReader input = new StreamReader(inputFile);
            StreamWriter output = new StreamWriter(outputFile);

            using (input)
            {
                using (output)
                {
                    string line = input.ReadLine();

                    string pattern = @">(.*)<";
                    Match match = Regex.Match(line, pattern);
                    string result;

                    while (line != null)
                    {
                        Console.WriteLine("Line: {0}", line);
                        if (match.Success)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            result = match.ToString().Replace(">", string.Empty).Replace("<", string.Empty).Trim();
                            Console.WriteLine("Extracted: {0}", result);
                            output.WriteLine(result);
                        }

                        Console.ForegroundColor = ConsoleColor.Gray;

                        line = input.ReadLine();
                        if (line != null)
                        {
                            match = Regex.Match(line, pattern);
                        }
                    }
                }
            }
        }

        private static void Main()
        {
            string inputFile = @"..\..\..\Files\10.input.xml";
            string outputFile = @"..\..\..\Files\10.output.txt";

            ReadExtract(inputFile, outputFile);
            Console.WriteLine("Result is in \"Files\" folder.");
        }
    }
}