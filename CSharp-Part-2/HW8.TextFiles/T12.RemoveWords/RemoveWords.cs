namespace T12.RemoveWords
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// 12. Write a program that removes from a text file all words listed in given another text file. Handle all possible exceptions in your methods.
    /// </summary>
    public class RemoveWords
    {
        public static void ReadWriteReplace(string inputFile, string outputFile, string wordsFile)
        {
            try
            {
                StreamReader input = new StreamReader(inputFile);
                StreamWriter output = new StreamWriter(outputFile);

                string pattern = MakePattern(wordsFile);

                using (input)
                {
                    using (output)
                    {
                        string line = input.ReadLine();

                        Match match = Regex.Match(line, pattern, RegexOptions.IgnoreCase);
                        string newLine = string.Empty;

                        while (line != null)
                        {
                            while (match.Success)
                            {
                                newLine = Regex.Replace(line, pattern, string.Empty, RegexOptions.IgnoreCase);
                                match = match.NextMatch();
                            }

                            if (line != string.Empty)
                            {
                                output.WriteLine(newLine + "\n");
                            }

                            line = input.ReadLine();

                            if (line != null)
                            {
                                match = Regex.Match(line, pattern, RegexOptions.IgnoreCase);
                            }
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

        public static string MakePattern(string wordsFile)
        {
            try
            {
                StreamReader words = new StreamReader(wordsFile);
                StringBuilder sb = new StringBuilder();

                ////Start pattern creation (?:word|word|word)

                sb.Append("(?:");

                using (words)
                {
                    string line = words.ReadLine();
                    while (line != null)
                    {
                        sb.Append(line);
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
            string input = @"..\..\..\Files\12.input.txt";
            string output = @"..\..\..\Files\12.output.txt";
            string words = @"..\..\..\Files\12.remove.txt";

            Stopwatch sw = new Stopwatch();
            sw.Start();

            try
            {
                ReadWriteReplace(input, output, words);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (IOException io)
            {
                Console.WriteLine(io.Message);
            }

            sw.Stop();
            Console.WriteLine("Time for operation {0}", sw.Elapsed);
            Console.WriteLine("Result is in \"Files\" folder.");
        }
    }
}
