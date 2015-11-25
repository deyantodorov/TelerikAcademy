using System;
using System.Linq;

namespace Tribonachi
{
    /// <summary>
    /// http://bgcoder.com/Contests/Practice/Index/123#0
    /// </summary>
    public class Program
    {
        private static void Main()
        {
            var nums = Console.ReadLine()
                .Split(' ')
                .Select(long.Parse)
                .ToArray();


            var t1 = nums[0];
            var t2 = nums[1];
            var t3 = nums[2];
            var n = nums[3];

            if (n == 1)
            {
                Console.WriteLine(t1);
            }
            else if (n == 2)
            {
                Console.WriteLine(t2);
            }
            else if (n == 3)
            {
                Console.WriteLine(t3);
            }
            else
            {
                for (int i = 4; i <= n; i++)
                {
                    long tribNew = t1 + t2 + t3;
                    t1 = t2;
                    t2 = t3;
                    t3 = tribNew;
                }
                Console.WriteLine(t3);
            }
        }
    }
}
