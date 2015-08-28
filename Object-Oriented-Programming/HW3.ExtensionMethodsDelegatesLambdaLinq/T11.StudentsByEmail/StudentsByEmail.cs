namespace T11.StudentsByEmail
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;

    /// <summary>
    /// Problem 11. Extract students by email
    ///             Extract all students that have email in abv.bg
    ///             Use string methods and LINQ
    ///             
    /// https://github.com/TelerikAcademy/Object-Oriented-Programming/blob/master/03.%20Extension-Methods-Delegates-Lambda-LINQ/README.md#problem-11-extract-students-by-email
    /// </summary>
    public class StudentsByEmail
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
            List<Student> selectedStudents = students.Where(s => s.Email.Substring(s.Email.IndexOf('@') + 1, s.Email.Length - 1 - s.Email.IndexOf('@')) == "abv.bg").ToList();
            selectedStudents.ForEach(student => Console.WriteLine("{0} {1} {2}", student.FirstName, student.LastName, student.Email));
        }

        private static void Linq(List<Student> students)
        {
            var selectedStudents = from s in students
                              where s.Email.Substring(s.Email.IndexOf('@') + 1, s.Email.Length - 1 - s.Email.IndexOf('@')) == "abv.bg"
                              select s;

            foreach (var student in selectedStudents)
            {
                Console.WriteLine("{0} {1} {2}", student.FirstName, student.LastName, student.Email);
            }
        }
    }
}