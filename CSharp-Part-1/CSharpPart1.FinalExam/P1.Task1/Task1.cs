namespace P1.Task1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Task1
    {
        private static void Main()
        {
            var list = new List<long>();

            for (int i = 0; i < 3; i++)
            {
                list.Add(long.Parse(Console.ReadLine()));
            }

            list.Sort();

            Console.WriteLine(list[2]);
            Console.WriteLine(list[0]);

            Console.WriteLine("{0:F3}", list.Average());

        }
    }
}