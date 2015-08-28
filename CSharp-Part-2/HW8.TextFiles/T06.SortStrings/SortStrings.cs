namespace T06.SortStrings
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    /// <summary>
    /// 6. Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file. 
    ///    Example:
    ///    Ivan      George
    ///    Peter     Ivan
    ///    Maria     Maria
    ///    George    Peter
    /// </summary>
    public class SortStrings
    {
        public static List<string> ReadFile(string path)
        {
            StreamReader reader = new StreamReader(path);
            List<string> result = new List<string>();

            using (reader)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    result.Add(line);
                    line = reader.ReadLine();
                }
            }

            return result;
        }

        public static void WriteFile(string path, List<string> list)
        {
            StreamWriter writer = new StreamWriter(path, false, Encoding.GetEncoding("utf-8"));

            using (writer)
            {
                foreach (var item in list)
                {
                    if (list != null)
                    {
                        writer.WriteLine(item);
                    }
                }
            }
        }

        private static void Main()
        {
            string input = @"..\..\..\Files\06.input.txt";
            string output = @"..\..\..\Files\06.output.txt";

            List<string> myList = ReadFile(input);
            myList.Sort();
            WriteFile(output, myList);

            Console.WriteLine("Mission Completed. See folder \"Files\"");
        }
    }
}
