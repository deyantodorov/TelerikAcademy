namespace T02.ConcatenatesTextFiles
{
    using System;
    using System.IO;
    using System.Text;

    /// <summary>
    /// 2. Write a program that concatenates two text files into another text file.
    /// </summary>
    public class ConcatenatesTextFiles
    {
        public static string ReadFile(string path)
        {
            StreamReader reader = new StreamReader(path);
            StringBuilder sb = new StringBuilder();
            using (reader)
            {
                string line = reader.ReadToEnd();

                if (line != null)
                {
                    sb.Append(line);
                }
            }

            return sb.ToString();
        }

        public static void WriteFile(string path, string newText)
        {
            StreamWriter writer = new StreamWriter(path);
            using (writer)
            {
                writer.Write(newText);
            }
        }

        private static void Main()
        {
            string fileOne = @"..\..\..\Files\02.fileOne.txt";
            string fileTwo = @"..\..\..\Files\02.fileTwo.txt";
            string fileNew = @"..\..\..\Files\02.fileFinall.txt";

            string textOne = ReadFile(fileOne);
            string textTwo = ReadFile(fileTwo);

            StringBuilder newText = new StringBuilder();
            newText.Append(textOne + " " + textTwo);

            WriteFile(fileNew, newText.ToString());

            Console.WriteLine("Mission Completed. See folder \"Files\"");
        }
    }
}