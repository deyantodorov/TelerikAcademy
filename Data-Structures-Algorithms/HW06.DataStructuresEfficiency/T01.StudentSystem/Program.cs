using System;
using System.IO;

namespace T01.StudentSystem
{
    /// <summary>
    /// 1. A text file students.txt holds information about students and their courses in the following format:
    ///    Using SortedDictionary<K,T> print the courses in alphabetical order and for each of them prints the 
    ///    students ordered by family and then by name:
    /// </summary>
    public class Program
    {
        private const string FilePath = @"../../students.txt";

        private static void Main()
        {   
            var school = ReadStudentsFromFile(FilePath);
            var text = school.PrintOrderedStudentsByCourse();

            Console.WriteLine(text.Trim());
        }

        private static School ReadStudentsFromFile(string path)
        {
            var school = new School();

            using (var reader = new StreamReader(path))
            {
                var line = reader.ReadLine();

                while (line != null)
                {
                    var currentLine = line.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    var student = new Student(currentLine[0].Trim(), currentLine[1].Trim(), currentLine[2].Trim());
                    school.Add(student);

                    line = reader.ReadLine();
                }
            }

            return school;
        }
    }
}