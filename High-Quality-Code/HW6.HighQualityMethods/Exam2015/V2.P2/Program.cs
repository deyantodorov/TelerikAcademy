namespace V2.P2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static void Main()
        {
            List<long> numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => long.Parse(x))
                .ToList();

            long sumAllAbsDiff = 0;

            for (int i = 1; i < numbers.Count; i++)
            {
                long prev = numbers[i - 1];
                long curr = numbers[i];
                long absDiff = Math.Abs(prev - curr);

                if (absDiff % 2 == 0)
                {
                    sumAllAbsDiff += absDiff;
                    i++;
                }
            }

            Console.WriteLine(sumAllAbsDiff);
        }
    }
}