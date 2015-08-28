namespace T20.InfiniteConvergentSeries
{
    using System;

    /// <summary>
    /// Problem 20.* Infinite convergent series
    ///              By using delegates develop an universal static method to calculate the sum of infinite convergent series with given precision depending on a function of its term. 
    ///              By using proper functions for the term calculate with a 2-digit precision the sum of the infinite series:
    ///              1 + 1/2 + 1/4 + 1/8 + 1/16 + …
    ///              1 + 1/2! + 1/3! + 1/4! + 1/5! + …
    ///              1 + 1/2 - 1/4 + 1/8 - 1/16 + …
    /// </summary>
    public class InfiniteConvergentSeries
    {
        private static void Main()
        {
            double precision = 0.001;

            Console.WriteLine("1 + 1/2 + 1/4 + 1/8 + 1/16 + ... = {0}", Calc(n => 1.0 / Math.Pow(2, n), precision));
            Console.WriteLine("1 + 1/2! + 1/3! + 1/4! + 1/5! + ... = {0}", Calc(n => 1.0 / Fact(n + 1), precision));
            Console.WriteLine("1 + 1/2 - 1/4 + 1/8 - 1/16 + ... = {0}", Calc(n => n == 0 ? 1 : -1.0 / Math.Pow(-2, n), precision));
        }

        private static double Calc(Func<int, double> expresion, double precision)
        {
            double result = 0.0;
            double temp = 1;

            for (int i = 0; Math.Abs(temp) > precision; i++)
            {
                temp = expresion(i);
                result += temp;
            }

            return result;
        }

        private static long Fact(long num)
        {
            long result = 1;

            while (num > 1)
            {
                result *= num;
                num--;
            }

            return result;
        }
    }
}