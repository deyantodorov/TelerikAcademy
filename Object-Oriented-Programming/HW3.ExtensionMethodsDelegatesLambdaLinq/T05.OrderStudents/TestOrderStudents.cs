namespace T05.OrderStudents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;

    /// <summary>
    /// https://github.com/TelerikAcademy/Object-Oriented-Programming/blob/master/03.%20Extension-Methods-Delegates-Lambda-LINQ/README.md#problem-5-order-students
    /// </summary>
    public class TestOrderStudents
    {
        private static void Main()
        {
            List<Student> list = new List<Student>();

            for (int i = 0; i < 5; i++)
            {
                Student student = new Student(GenerateRandom.Text(10), GenerateRandom.Text(10));
                list.Add(student);
            }

            Expression(list);
            Linq(list);
        }
 
        private static void Linq(List<Student> list)
        {
            Console.WriteLine("\nDescending order with Linq\n");
            var sort2 = from x in list
                        orderby x.FirstName descending, x.LastName descending
                        select x;

            foreach (var item in sort2)
            {
                Console.WriteLine(item);
            }
        }
 
        private static void Expression(List<Student> list)
        {
            Console.WriteLine("\nInitial state:\n");
            list.ForEach(x => Console.WriteLine(x));

            Console.WriteLine("\nDescending order with expression\n");
            List<Student> sort1 = list.OrderByDescending(x => x.FirstName)
                                      .ThenByDescending(x => x.LastName)
                                      .ToList();

            sort1.ForEach(x => Console.WriteLine(x));
        }
    }
}