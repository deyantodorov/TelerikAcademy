namespace T01.ReadOddLines
{
    using System;
    using System.IO;

    /// <summary>
    /// 1. Write a program that reads a text file and prints on the console its odd lines.
    /// </summary>
    public class ReadOddLines
    {
        public static void ReadPrintFile(string path)
        {
            StreamReader reader = new StreamReader(path);
            using (reader)
            {
                string line = reader.ReadLine();
                int row = 0;
                if (line != null)
                {
                    while (line != null)
                    {
                        if (row % 2 == 0)
                        {
                            Console.WriteLine(line);
                        }

                        line = reader.ReadLine();
                        row++;
                    }
                }
            }
        }

        private static void Main()
        {
            string filePath = @"..\..\..\Files\01.lines.txt";
            ReadPrintFile(filePath);
        }
    }
}
