namespace SuperSum
{
    using System;
    using System.Linq;

    /// <summary>
    /// http://bgcoder.com/Contests/Practice/Index/123#1
    /// </summary>
    public class Program
    {
        private static void Main()
        {
            var nums = Console.ReadLine()
                .Split(' ')
                .Select(long.Parse)
                .ToArray();

            long k = nums[0];
            long n = nums[1];

            Console.WriteLine(SuperSum(k, n));
        }

        public static long SuperSum(long k, long n)
        {
            long result = 0;
            
            if (k == 0)
            {
                return n;
            }

            for (int i = 1; i <= n; i++)
            {
                result += SuperSum(k - 1, i);
            }

            return result;
        }
    }
}
