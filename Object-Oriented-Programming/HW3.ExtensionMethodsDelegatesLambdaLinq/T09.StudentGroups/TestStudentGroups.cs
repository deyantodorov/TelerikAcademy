namespace T09.StudentGroups
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;

    /// <summary>
    /// https://github.com/TelerikAcademy/Object-Oriented-Programming/blob/master/03.%20Extension-Methods-Delegates-Lambda-LINQ/README.md#problem-9-student-groups
    /// </summary>
    public class TestStudentGroups
    {
        private static void Main()
        {
            // Bacause students information is random generated there are option to see zero result. I tried to reduce this cases, but you know what is random data :)
            List<Student> students = RandomData.Students(50, 10, 10, 10000, 99999, 2, 7, 1, 5);

            LinqQuery(students);
        }

        private static void LinqQuery(List<Student> students)
        {
            var selectedStudents = from s in students
                                 where s.GroupNumber == 2
                                 orderby s.FirstName
                                 select s;

            foreach (var student in selectedStudents)
            {
                Console.WriteLine("First name: {0}, Group number: {1}", student.FirstName, student.GroupNumber);
            }
        }
    }
}