namespace T07.Replacer
{
    using System;
    using System.Diagnostics;
    using System.IO;

    /// <summary>
    /// 7. Write a program that replaces all occurrences of the substring "start" with the substring "finish" in a text file. 
    ///    Ensure it will work with large files (e.g. 100 MB).
    /// </summary>
    public class Replacer
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
                        output.WriteLine(line.Replace("start", "finish"));
                        line = input.ReadLine();
                    }
                }
            }
        }

        public static void ReplaceFile(string inputFile, string outputFile, string backupFile)
        {
            File.Replace(outputFile, inputFile, backupFile, false);
        }

        private static void Main()
        {
            // File paths
            string input = @"..\..\..\Files\07.input.txt";
            string inputBackUp = @"..\..\..\Files\07.input.txt.bac";
            
            // Unzip 07.inputBig.txt.zip for test big files
            // string input = @"..\..\..\Files\07.inputBig.txt";
            string output = @"..\..\..\Files\07.output.txt";

            Stopwatch sw = new Stopwatch();

            sw.Start();

            ReadWriteReplace(input, output);
            ReplaceFile(input, output, inputBackUp);

            sw.Stop();
            Console.WriteLine("Time for operation {0}", sw.Elapsed);
            Console.WriteLine("Result is in \"Files\" folder.");
        }
    }
}