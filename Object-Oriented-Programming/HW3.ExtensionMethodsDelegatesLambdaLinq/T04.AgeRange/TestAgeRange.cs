namespace T04.AgeRange
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;

    /// <summary>
    /// https://github.com/TelerikAcademy/Object-Oriented-Programming/blob/master/03.%20Extension-Methods-Delegates-Lambda-LINQ/README.md#problem-4-age-range
    /// </summary>
    public class TestAgeRange
    {
        private static void Main()
        {
            List<Student> list = new List<Student>();

            for (int i = 0; i < 20; i++)
            {
                Student student = new Student(GenerateRandom.Text(10), GenerateRandom.Text(10));
                student.Age = GenerateRandom.Number(15, 35);

                list.Add(student);
            }

            Console.WriteLine("\nAll:\n");
            list.ForEach(x => Console.WriteLine(x));

            Console.WriteLine("\nFilterd 1:\n");
            var sorted1 = list.Where(x => x.Age >= 18 && x.Age <= 24)
                              .Select(x => new
                              {
                                  FirstName = x.FirstName,
                                  LastName = x.LastName,
                                  Age = x.Age
                              }).ToList();

            sorted1.ForEach(x => Console.WriteLine(x.FirstName + " " + x.LastName + " " + x.Age));

            Console.WriteLine("\nFilterd 2:\n");
            var sorted2 = from s in list
                          where s.Age >= 18 && s.Age <= 24
                          select new
                          {
                              FirstName = s.FirstName,
                              LastName = s.LastName,
                              Age = s.Age
                          };

            foreach (var x in sorted2)
            {
                Console.WriteLine(x.FirstName + " " + x.LastName + " " + x.Age);
            }
        }
    }
}