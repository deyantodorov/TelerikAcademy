namespace T08.CatalanNumbers
{
    using System;
    using System.Linq;
    using Common;
    using System.Numerics;

    /// <summary>
    /// 8. In combinatorics, the Catalan numbers are calculated by the following formula: catalan-formula
    ///    
    ///    Cn = (2 * n)! / (n+1)! * n! n >= 0;
    ///     
    ///    Write a program to calculate the nth Catalan number by given n (1 <= n <= 100).
    /// </summary>
    public class CatalanNumbers
    {
        private static void Main()
        {
            uint n = Helpers.ValidateInputAsUint("Inter positive integer: ");

            while (n < 0)
            {
                n = Helpers.ValidateInputAsUint("Inter positive integer: ");
            }

            BigInteger catalanNumbers = 0;

            //// I don't have to calculate when n = 0
            if (n != 0)
            {
                catalanNumbers = Helpers.CalcFactorialBigInteger(2 * n) / (Helpers.CalcFactorialBigInteger(n + 1) * Helpers.CalcFactorialBigInteger(n));
            }

            Console.WriteLine("Cn = {0}", catalanNumbers);
        }
    }
}