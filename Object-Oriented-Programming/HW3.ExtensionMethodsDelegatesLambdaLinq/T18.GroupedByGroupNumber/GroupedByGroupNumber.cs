namespace T18.GroupedByGroupNumber
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;

    /// <summary>
    /// Problem 18. Grouped by GroupNumber
    ///             Create a program that extracts all students grouped by GroupNumber and then prints them to the console.
    ///             Use LINQ.
    /// https://github.com/TelerikAcademy/Object-Oriented-Programming/blob/master/03.%20Extension-Methods-Delegates-Lambda-LINQ/README.md#problem-18-grouped-by-groupnumber
    /// </summary>
    public class GroupedByGroupNumber
    {
        private static void Main()
        {
            // Bacause students information is random generated there are option to see zero result. I tried to reduce this cases, but you know what is random data :)
            List<Student> students = RandomData.Students(50, 10, 10, 100000, 999999, 2, 7, 1, 5);

            Linq(students);
        }

        private static void Linq(List<Student> students)
        {
            var selectedStudents = from s in students
                                   orderby s.GroupNumber ascending
                                   group s by s.GroupNumber;

            foreach (var groupedStudents in selectedStudents)
            {
                Console.WriteLine(Environment.NewLine + "Group number " + groupedStudents.Key);

                foreach (var student in groupedStudents)
                {
                    Console.WriteLine("Name: {0}, Group number: {1}", student.FirstName + " " + student.LastName, student.Group.GroupNumber);
                }

            }
        }
    }
}