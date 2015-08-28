namespace T03.InsertsLineNumbers
{
    using System;
    using System.IO;
    using System.Text;

    /// <summary>
    /// 3. Write a program that reads a text file and inserts line numbers in front of each of its lines. The result should be written to another text file.    
    /// </summary>
    public class InsertsLineNumbers
    {
        public static string ReadFile(string path, string fileNew)
        {
            StreamReader reader = new StreamReader(path);
            StringBuilder sb = new StringBuilder();
            using (reader)
            {
                int row = 1;
                string line = reader.ReadLine();

                while (line != null)
                {
                    sb.Append(row.ToString());
                    sb.Append(". ");
                    sb.Append(line);
                    sb.Append("\r\n");

                    WriteFile(fileNew, sb.ToString());

                    row++;
                    line = reader.ReadLine();
                }
            }

            return sb.ToString();
        }

        public static void WriteFile(string path, string newText)
        {
            StreamWriter writer = new StreamWriter(path, false, Encoding.GetEncoding("utf-8"));
            using (writer)
            {
                writer.Write(newText);
            }
        }

        private static void Main()
        {
            string fileOne = @"..\..\..\Files\03.fileOne.txt";
            string fileNew = @"..\..\..\Files\03.fileFinall.txt";

            ReadFile(fileOne, fileNew);
            Console.WriteLine("Mission Completed. See folder \"Files\"");
        }
    }
}
