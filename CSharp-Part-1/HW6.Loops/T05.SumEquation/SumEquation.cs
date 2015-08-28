namespace T05.SumEquation
{
    using Common;
    using System;
    using System.Linq;

    /// <summary>
    /// 5. Write a program that, for a given two integer numbers n and x, calculates the sum S = 1 + 1!/x + 2!/x2 + … + n!/x^n.
    ///    Use only one loop. Print the result with 5 digits after the decimal point.
    /// </summary>
    public class SumEquation
    {
        private static void Main()
        {
            Console.WriteLine("Please enter values between 1 and 20");
            uint n = Helpers.ValidateInputAsUint("Enter value for N = ");
            uint x = Helpers.ValidateInputAsUint("Enter value for X = ");

            // I made this restriction, because of decimal overflow
            while ((n < 0 || n > 20) || (x < 0 || x > 20))
            {
                n = Helpers.ValidateInputAsUint("Enter value for N = ");
                x = Helpers.ValidateInputAsUint("Enter value for X = ");
            }

            decimal s = 1;

            /*
             * S = 1 + 1!/X + 2!/X2 + … + N!/XN
             * S = 1 + 1! / 3 + 2! / (3*3) + 3! / (3*3*3) + 4! / (3*3*3*3)
             */

            for (uint i = 1; i <= n; i++)
            {
                s += Helpers.CalcFactorial(i) / Helpers.NumberToPower((int)x, (int)i);
            }

            Console.WriteLine("Sum is = {0:F5}", s);
        }
    }
}