namespace T09.RemoveOddLines
{
    using System;
    using System.Diagnostics;
    using System.IO;

    /// <summary>
    /// 9. Write a program that deletes from given text file all odd lines. The result should be in the same file.
    /// </summary>
    public class RemoveOddLines
    {
        public static void ReadWriteReplace(string inputFile, string outputFile)
        {
            StreamReader input = new StreamReader(inputFile);
            StreamWriter output = new StreamWriter(outputFile);

            using (input)
            {
                using (output)
                {
                    int lineNumber = 1;
                    string line = input.ReadLine();
                    while (line != null)
                    {
                        if (lineNumber % 2 == 0)
                        {
                            output.WriteLine(line);
                        }

                        lineNumber++;
                        line = input.ReadLine();
                    }
                }
            }
        }

        public static void ReplaceFile(string inputFile, string inputBackUp, string outputFile)
        {
            File.Replace(outputFile, inputFile, inputBackUp, false);
        }

        private static void Main()
        {
            // File paths
            string fileInput = @"..\..\..\Files\09.input.txt";
            string fileInputBackup = @"..\..\..\Files\09.input.txt.bac";
            string fileOutput = @"..\..\..\Files\09.output.txt";

            Stopwatch sw = new Stopwatch();

            sw.Start();

            ReadWriteReplace(fileInput, fileOutput);
            ReplaceFile(fileInput, fileInputBackup, fileOutput);

            sw.Stop();
            Console.WriteLine("Time for operation {0}", sw.Elapsed);
            Console.WriteLine("Result is in \"Files\" folder.");
        }
    }
}
