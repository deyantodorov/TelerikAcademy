namespace T11.DeleteFromText
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Text.RegularExpressions;

    /// <summary>
    /// 11. Write a program that deletes from a text file all words that start with the prefix "test". Words contain only the symbols 0...9, a...z, A…Z, _.
    /// </summary>
    public class DeleteFromText
    {
        public static void ReadWriteReplace(string inputFile, string outputFile)
        {
            StreamReader input = new StreamReader(inputFile);
            StreamWriter output = new StreamWriter(outputFile);

            using (input)
            {
                using (output)
                {
                    string line = input.ReadLine();
                    while (line != null)
                    {
                        output.WriteLine(Regex.Replace(line, @"\btest\w", string.Empty));
                        line = input.ReadLine();
                    }
                }
            }
        }

        private static void Main()
        {
            // Filepath
            string input = @"..\..\..\Files\11.input.txt";
            string output = @"..\..\..\Files\11.output.txt";

            Stopwatch sw = new Stopwatch();

            sw.Start();

            ReadWriteReplace(input, output);

            sw.Stop();
            Console.WriteLine("Time for operation {0}", sw.Elapsed);
            Console.WriteLine("Result is in \"Files\" folder.");
        }
    }
}
