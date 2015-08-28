namespace T13.StudentsByMarks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;

    /// <summary>
    /// Problem 13. Extract students by marks
    ///             Select all students that have at least one mark Excellent (6) into a new anonymous class that has properties – FullName and Marks.
    ///             Use LINQ.
    ///             
    /// https://github.com/TelerikAcademy/Object-Oriented-Programming/blob/master/03.%20Extension-Methods-Delegates-Lambda-LINQ/README.md#problem-13-extract-students-by-marks
    /// </summary>
    public class StudentsByMarks
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
            var selectedStudents = students.Where(s => s.Marks.Count > 0 && s.Marks.Contains(6))
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
                              where s.Marks.Count > 0 && s.Marks.Contains(6)
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
    }
}