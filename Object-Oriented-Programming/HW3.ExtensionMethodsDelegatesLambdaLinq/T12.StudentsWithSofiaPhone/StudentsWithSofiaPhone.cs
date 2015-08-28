namespace T12.StudentsWithSofiaPhone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;

    /// <summary>
    /// Problem 12. Extract students by phone
    ///             Extract all students with phones in Sofia
    ///             Use LINQ.
    ///             
    /// https://github.com/TelerikAcademy/Object-Oriented-Programming/blob/master/03.%20Extension-Methods-Delegates-Lambda-LINQ/README.md#problem-12-extract-students-by-phone
    /// </summary>
    public class StudentsWithSofiaPhone
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
            List<Student> selectedStudents = students.Where(s => s.Tel.Substring(0, s.Tel.IndexOf('/')) == "02").ToList();
            selectedStudents.ForEach(student => Console.WriteLine("{0} {1} {2}", student.FirstName, student.LastName, student.Tel));
        }

        private static void Linq(List<Student> students)
        {
            var selectedStudents = from s in students
                              where s.Tel.Substring(0, s.Tel.IndexOf('/')) == "02"
                              select s;

            foreach (var student in selectedStudents)
            {
                Console.WriteLine("{0} {1} {2}", student.FirstName, student.LastName, student.Tel);
            }
        }
    }
}