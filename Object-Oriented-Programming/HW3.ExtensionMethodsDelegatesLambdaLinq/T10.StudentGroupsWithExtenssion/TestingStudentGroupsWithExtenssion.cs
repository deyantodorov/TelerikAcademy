namespace T10.StudentGroupsWithExtenssion
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;

    /// <summary>
    /// https://github.com/TelerikAcademy/Object-Oriented-Programming/blob/master/03.%20Extension-Methods-Delegates-Lambda-LINQ/README.md#problem-10-student-groups-extensions
    /// </summary>
    public class TestingStudentGroupsWithExtenssion
    {
        private static void Main()
        {
            // Bacause students information is random generated there are option to see zero result. I tried to reduce this cases, but you know what is random data :)
            List<Student> students = RandomData.Students(50, 10, 10, 10000, 99999, 2, 7, 1, 5);

            LambdaExpression(students);
        }

        private static void LambdaExpression(List<Student> students)
        {
            List<Student> selectedStudents = students.Where(s => s.GroupNumber == 2)
                                                   .OrderBy(s => s.FirstName)
                                                   .ToList();

            selectedStudents.ForEach(s => Console.WriteLine("First name: {0}, Group number: {1}", s.FirstName, s.GroupNumber));
        }
    }
}