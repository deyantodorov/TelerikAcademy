namespace T13.FindCountWords
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// 13. Write a program that reads a list of words from a file words.txt and finds how many times each of the words is contained in another file test.txt. 
    ///     The result should be written in the file result.txt and the words should be sorted by the number of their occurrences in descending order. 
    ///     Handle all possible exceptions in your methods.
    /// </summary>
    public class FindCountWords
    {
        public static void ReadCount(string inputFile, List<string> words, string wordsToRemove)
        {
            try
            {
                StreamReader input = new StreamReader(inputFile);

                string pattern = MakePattern(wordsToRemove);

                using (input)
                {
                    string line = input.ReadLine();

                    Match match = Regex.Match(line, pattern, RegexOptions.IgnoreCase);

                    while (line != null)
                    {
                        while (match.Success)
                        {
                            words.Add(match.Value);
                            match = match.NextMatch();
                        }

                        line = input.ReadLine();

                        if (line != null)
                        {
                            match = Regex.Match(line, pattern, RegexOptions.IgnoreCase);
                        }
                    }
                }
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Invalid argument");
            }
            catch (IOException)
            {
                throw new IOException("File or directory not found");
            }
        }

        public static void Write(string outputFile, List<string> words)
        {
            StreamWriter writer = new StreamWriter(outputFile);
            try
            {
                using (writer)
                {
                    var wordsResult = words;
                    var q = from x in wordsResult
                            group x by x into g
                            let count = g.Count()
                            orderby count descending
                            select new { Value = g.Key, Count = count };
                    foreach (var x in q)
                    {
                        writer.WriteLine("Word \"{0}\" found {1} times", x.Value, x.Count);
                    }
                }
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Invalid argument");
            }
            catch (IOException)
            {
                throw new IOException("File or directory not found");
            }
        }

        public static string MakePattern(string wordsToRemove)
        {
            try
            {
                StreamReader words = new StreamReader(wordsToRemove);
                StringBuilder sb = new StringBuilder();

                ////Start pattern creation (?:word|word|word)

                sb.Append("(?:");

                using (words)
                {
                    string line = words.ReadLine();
                    while (line != null)
                    {
                        sb.Append(line.Replace("#", @"\#").Replace(".", @"\.").Replace("+", @"\+"));
                        sb.Append("|");
                        line = words.ReadLine();
                    }

                    sb.Remove(sb.Length - 1, 1);
                    sb.Append(")");
                }

                ////End pattern creation (?:word|word|word)

                return sb.ToString();
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Invalid argument");
            }
            catch (IOException)
            {
                throw new IOException("File or directory not found");
            }
        }

        private static void Main()
        {
            // File paths
            string inputFile = @"..\..\..\Files\13.input.txt";
            string outputFile = @"..\..\..\Files\13.output.txt";
            string wordsToRemove = @"..\..\..\Files\13.words.txt";

            List<string> words = new List<string>();

            // Just testing performance
            Stopwatch sw = new Stopwatch();
            sw.Start();

            try
            {
                ReadCount(inputFile, words, wordsToRemove);
                Write(outputFile, words);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (IOException io)
            {
                Console.WriteLine(io.Message);
            }

            // Display performance results
            sw.Stop();
            Console.WriteLine("Time for operation {0}", sw.Elapsed);
            Console.WriteLine("Result is in \"Files\" folder.");
        }
    }
}