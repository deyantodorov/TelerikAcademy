using System;

namespace Brackets
{
    /// <summary>
    /// http://bgcoder.com/Contests/Practice/Index/123#2
    /// </summary>
    public class Program
    {
        private const int MaxNumber = 128;

        private static long[,] dp = new long[MaxNumber, MaxNumber];

        private static void Main()
        {
            for (int i = 0; i < MaxNumber; i++)
            {
                for (int j = 0; j < MaxNumber; j++)
                {
                    dp[i, j] = 0;
                }
            }

            string expr = Console.ReadLine();
            int N = expr.Length;
            dp[0, 0] = 1;
            for (int k = 1; k <= N; k++)
            {
                if (expr[k - 1] == '(')
                {
                    dp[k, 0] = 0;
                }
                else
                {
                    dp[k, 0] = dp[k - 1, 1];
                }
                for (int c = 1; c <= N; c++)
                {
                    if (expr[k - 1] == '(')
                    {
                        dp[k, c] = dp[k - 1, c - 1];
                    }
                    else if (expr[k - 1] == ')')
                    {
                        dp[k, c] = dp[k - 1, c + 1];
                    }
                    else
                    {
                        dp[k, c] = dp[k - 1, c - 1] + dp[k - 1, c + 1];
                    }
                }
            }
            Console.WriteLine(dp[N, 0]);
        }
    }
}
