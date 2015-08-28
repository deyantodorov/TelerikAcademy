namespace T16.Groups
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;

    /// <summary>
    /// Problem 16.* Groups
    ///              Create a class Group with properties GroupNumber and DepartmentName.
    ///              Introduce a property GroupNumber in the Student class.
    ///              Extract all students from "Mathematics" department.
    /// https://github.com/TelerikAcademy/Object-Oriented-Programming/blob/master/03.%20Extension-Methods-Delegates-Lambda-LINQ/README.md#problem-16-groups
    /// </summary>
    public class Groups
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
            var selectedStudents = students.Where(s => s.Group.DepartmentName.Equals("Mathematics"))
                                           .ToList();

            foreach (var student in selectedStudents)
            {
                Console.WriteLine("Name: {0}, Department: {1}", student.FirstName + " " + student.LastName, student.Group.DepartmentName);
            }
        }

        private static void Linq(List<Student> students)
        {
            var selectedStudents = from s in students
                                   where s.Group.DepartmentName.Equals("Mathematics")
                                   select s;

            foreach (var student in selectedStudents)
            {
                Console.WriteLine("Name: {0}, Department: {1}", student.FirstName + " " + student.LastName, student.Group.DepartmentName);
            }
        }
    }
}