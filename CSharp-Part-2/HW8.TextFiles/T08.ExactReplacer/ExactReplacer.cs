namespace T08.ExactReplacer
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Text.RegularExpressions;

    /// <summary>
    /// 8. Modify the solution of the previous problem to replace only whole words (not substrings).
    /// </summary>
    public class ExactReplacer
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
                        output.WriteLine(Regex.Replace(line, @"\bstart\b", "finish"));
                        line = input.ReadLine();
                    }
                }
            }
        }

        private static void Main()
        {
            string input = @"..\..\..\Files\08.input.txt";
            string output = @"..\..\..\Files\08.1output.txt";

            Stopwatch sw = new Stopwatch();

            sw.Start();

            ReadWriteReplace(input, output);

            sw.Stop();
            Console.WriteLine("Time for operation {0}", sw.Elapsed);
            Console.WriteLine("Result is in \"Files\" folder.");
        }
    }
}
