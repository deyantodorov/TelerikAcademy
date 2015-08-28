namespace T14.StudentsWithTwoMarksTwo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;

    /// <summary>
    /// Problem 14. Extract students with two marks
    ///             Write down a similar program that extracts the students with exactly two marks "2".
    ///             Use extension methods.
    /// </summary>
    public class StudentsWithTwoMarksTwo
    {
        private static void Main()
        {
            // Bacause students information is random generated there are option to see zero result. I tried to reduce this cases, but you know what is random data :)
            List<Student> students = RandomData.Students(50, 10, 10, 10000, 99999, 2, 7, 1, 5);

            Linq(students);

            Console.WriteLine();

            Expression(students);
        }

        private static void Expression(List<Student> students)
        {
            var selectedStudents = students.Where(s => s.Marks.Count > 0 && MarksMatch(s.Marks, 2, 2))
                                    .Select(s => new
                                    {
                                        FullName = s.FirstName + " " + s.LastName,
                                        Marks = s.MarksPrint()
                                    });

            foreach (var student in selectedStudents)
            {
                Console.WriteLine("{0} {1}", student.FullName, student.Marks);
            }
        }

        private static void Linq(List<Student> students)
        {
            var selectedStudents = from s in students
                                   where s.Marks.Count > 0 && MarksMatch(s.Marks, 2, 2)
                                   select new
                                   {
                                       FullName = s.FirstName + " " + s.LastName,
                                       Marks = s.MarksPrint()
                                   };

            foreach (var student in selectedStudents)
            {
                Console.WriteLine("{0} {1}", student.FullName, student.Marks);
            }
        }

        private static bool MarksMatch(List<int> marks, int mark, int occurences)
        {
            int foundMark = 0;
            int foundOccurences = 0;

            for (int i = 0; i < marks.Count; i++)
            {
                if (marks[i] == mark)
                {
                    foundMark++;
                    foundOccurences++;
                }
            }

            return foundMark == mark && foundOccurences == occurences;
        }
    }
}