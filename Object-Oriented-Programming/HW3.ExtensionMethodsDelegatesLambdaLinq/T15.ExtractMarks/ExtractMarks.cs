namespace T15.ExtractMarks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;

    /// <summary>
    /// Problem 15. Extract marks
    ///             Extract all Marks of the students that enrolled in 2006. (The students from 2006 have 06 as their 5-th and 6-th digit in the FN).
    /// </summary>
    public class ExtractMarks
    {
        private static void Main()
        {
            // Bacause students information is random generated there are option to see zero result. I tried to reduce this cases, but you know what is random data :)
            List<Student> students = RandomData.Students(50, 10, 10, 100000, 999999, 2, 7, 1, 5);

            Linq(students);

            Console.WriteLine();

            Expression(students);
        }

        private static void Expression(List<Student> students)
        {
            var selectedStudents = students.Where(s => s.Fn.ToString().Substring(s.Fn.ToString().Length - 2, 2) == "06")
                                    .Select(s => new
                                    {
                                        Fn = s.Fn,
                                        Marks = s.Marks
                                    });

            foreach (var student in selectedStudents)
            {
                Console.Write(student.Fn + ": ");

                foreach (var mark in student.Marks)
                {
                    Console.Write("{0} ", mark);    
                }

                Console.WriteLine();
            }
        }

        private static void Linq(List<Student> students)
        {
            var selectedStudents = from s in students
                                   where s.Fn.ToString().Substring(s.Fn.ToString().Length - 2, 2) == "06"
                                   select new
                                   {
                                       Fn = s.Fn,
                                       Marks = s.Marks
                                   };

            foreach (var student in selectedStudents)
            {
                Console.Write(student.Fn + ": ");

                foreach (var mark in student.Marks)
                {
                    Console.Write("{0} ", mark);
                }

                Console.WriteLine();
            }
        }
    }
}