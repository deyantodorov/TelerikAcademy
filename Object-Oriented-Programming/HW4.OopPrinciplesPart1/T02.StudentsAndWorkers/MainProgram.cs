namespace T02.StudentsAndWorkers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using T02.StudentsAndWorkers.Contracts;

    /// <summary>
    /// https://github.com/TelerikAcademy/Object-Oriented-Programming/blob/master/04.%20OOP%20Principles%20-%20Part%201/README.md#problem-2-students-and-workers
    /// </summary>
    public class MainProgram
    {
        private static void Main()
        {
            List<Student> students = GenerateStudents(10);
            List<Worker> workers = GenerateWorkers(10);

            Console.WriteLine("Students");

            // Order students by grade
            List<Student> studentsByGrade = students.OrderByDescending(x => x.Grade).ToList();
            studentsByGrade.ForEach(x => Console.WriteLine(x));

            Console.WriteLine(Environment.NewLine + "Workers");
            
            // Order workers by money per hour
            List<Worker> workersByMoneyPerHour = workers.OrderByDescending(x => x.MoneyPerHour()).ToList();
            workersByMoneyPerHour.ForEach(x => Console.WriteLine(x));

            Console.WriteLine(Environment.NewLine + "Merged and sorted by first and last name");
            
            // Merge students and workers
            List<IHuman> allHummans = students.Concat<IHuman>(workers).ToList();
            List<IHuman> sortedAllHumans = allHummans.OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToList();
            sortedAllHumans.ForEach(x => Console.WriteLine(x.FirstName + " " + x.LastName));
        }

        private static List<Worker> GenerateWorkers(int count)
        {
            List<Worker> workers = new List<Worker>();

            for (int i = 0; i < count; i++)
            {
                string firstName = GenerateRandom.Text(GenerateRandom.Number(5, 15));
                string lastName = GenerateRandom.Text(GenerateRandom.Number(5, 15));

                Worker worker = new Worker(firstName, lastName);
                worker.WeekSalary = GenerateRandom.Number(100, 2000);
                worker.WorkHoursPerDay = GenerateRandom.Number(6, 12);

                workers.Add(worker);
            }

            return workers;
        }

        private static List<Student> GenerateStudents(int count)
        {
            List<Student> students = new List<Student>();

            for (int i = 0; i < count; i++)
            {
                string firstName = GenerateRandom.Text(GenerateRandom.Number(5, 15));
                string lastName = GenerateRandom.Text(GenerateRandom.Number(5, 15));

                Student student = new Student(firstName, lastName);
                student.Grade = (Grade)GenerateRandom.Number(0, 5);

                students.Add(student);
            }

            return students;
        }
    }
}