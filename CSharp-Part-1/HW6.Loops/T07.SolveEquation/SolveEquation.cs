namespace T07.SolveEquation
{
    using System;
    using System.Linq;
    using Common;
    using System.Numerics;

    /// <summary>
    /// 7. In combinatorics, the number of ways to choose k different members out of a group of n different elements (also known as the number of combinations) is calculated by the following formula: 
    ///    formula For example, there are 2598960 ways to withdraw 5 cards out of a standard deck of 52 cards.
    ///    Your task is to write a program that calculates n! / (k! * (n-k)!) for given n and k (1 < k < n < 100). Try to use only two loops.
    /// </summary>
    public class SolveEquation
    {
        private static void Main()
        {
            uint n = Helpers.ValidateInputAsUint("Enter value for N = ");
            uint k = Helpers.ValidateInputAsUint("Enter value for K = ");

            while (1 > k && k > n && n > 100)
            {
                Console.WriteLine("Invalid input");
                n = Helpers.ValidateInputAsUint("Enter value for N = ");
                k = Helpers.ValidateInputAsUint("Enter value for K = ");
            }

            // Calculate factorial, expression and print result
            BigInteger result = Helpers.CalcFactorialBigInteger(n) / (Helpers.CalcFactorialBigInteger(k) * Helpers.CalcFactorialBigInteger((n-k)));
            Console.WriteLine("n! / (k! * (n-k)!) = {0}", result);
        }
    }
}