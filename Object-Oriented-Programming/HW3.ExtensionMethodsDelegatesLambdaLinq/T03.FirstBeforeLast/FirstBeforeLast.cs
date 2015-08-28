namespace T03.FirstBeforeLast
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;

    /// <summary>
    /// https://github.com/TelerikAcademy/Object-Oriented-Programming/blob/master/03.%20Extension-Methods-Delegates-Lambda-LINQ/README.md#problem-3-first-before-last
    /// </summary>
    public class FirstBeforeLast
    {
        private static void Main()
        {
            //List<Student> collectionOfStudents = new List<Student>();

            //collectionOfStudents[0] = new Student("Ivan", "Petrov");
            //collectionOfStudents[1] = new Student("Misho", "Geshev");
            //collectionOfStudents[2] = new Student("Volen", "Siderov");
            //collectionOfStudents[3] = new Student("Boiko", "Borisov");
            //collectionOfStudents[4] = new Student("Rosen", "Plevneliev");
            //collectionOfStudents[4] = new Student("Atanas", "Zlatanov");

            //FindItLinqAndLambda(collectionOfStudents);

            //Console.WriteLine();

            //FindItLinq(collectionOfStudents);

            List<Student> students = new List<Student>();

            for (int i = 0; i < 10; i++)
            {
                Student student = new Student(GenerateRandom.Text(15), GenerateRandom.Text(15));
                students.Add(student);
            }

            Console.WriteLine("\nUnsorted:\n");
            students.ForEach(x => Console.WriteLine(x));

            Console.WriteLine("\nSorted:\n");
            FindItLinq(students);
            FindItLinqAndLambda(students);
        }

        private static void FindItLinq(IList<Student> students)
        {
            var searchForStudents = students.Where(s => s.FirstName.CompareTo(s.LastName) < 0);

            foreach (var student in searchForStudents)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }
        }

        private static void FindItLinqAndLambda(IList<Student> students)
        {
            var searchForStudents =
                from s in students
                where s.FirstName.CompareTo(s.LastName) < 0
                select s;

            foreach (var student in searchForStudents)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }
        }
    }
}