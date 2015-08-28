namespace T06.DivisibleBy7And3
{
    using System;
    using System.Linq;
    using Common;

    /// <summary>
    /// https://github.com/TelerikAcademy/Object-Oriented-Programming/blob/master/03.%20Extension-Methods-Delegates-Lambda-LINQ/README.md#problem-6-divisible-by-7-and-3
    /// </summary>
    public class TestingDevisible
    {
        private static void Main()
        {
            int[] array = new int[50];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = GenerateRandom.Number(1, 1000);
            }

            Console.WriteLine("All");
            array.ToList().ForEach(x => Console.Write(x + ", "));
            Console.WriteLine();

            Console.WriteLine("\nDeletable by 7 and 3");
            
            Console.WriteLine("\nExpression");
            Expression(array);

            Console.WriteLine("\nLinq");
            Linq(array);
        }
 
        private static void Linq(int[] array)
        {
            var deletable = from x in array
                            where x % 7 == 0 && x % 3 == 0
                            select x;

            foreach (var item in deletable)
            {
                Console.WriteLine(item);
            }
        }

        private static void Expression(int[] array)
        {
            array.Where(x => x % 7 == 0 && x % 3 == 0)
                 .ToList()
                 .ForEach(x => Console.WriteLine(x));
        }
    }
}