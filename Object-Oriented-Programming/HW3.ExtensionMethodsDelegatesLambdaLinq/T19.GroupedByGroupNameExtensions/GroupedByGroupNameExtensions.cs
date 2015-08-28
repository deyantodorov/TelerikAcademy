namespace T19.GroupedByGroupNameExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;

    /// <summary>
    /// Problem 19. Grouped by GroupName extensions
    ///             Rewrite the previous using extension methods.
    ///             
    /// https://github.com/TelerikAcademy/Object-Oriented-Programming/blob/master/03.%20Extension-Methods-Delegates-Lambda-LINQ/README.md#problem-19-grouped-by-groupname-extensions
    /// </summary>
    public class GroupedByGroupNameExtensions
    {
        private static void Main()
        {
            // Bacause students information is random generated there are option to see zero result. I tried to reduce this cases, but you know what is random data :)
            List<Student> students = RandomData.Students(50, 10, 10, 100000, 999999, 2, 7, 1, 5);
            Expression(students);
        }

        private static void Expression(List<Student> students)
        {
            var selectedStudents = students.OrderBy(x => x.GroupNumber).GroupBy(x => x.GroupNumber);

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