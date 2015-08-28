namespace T18.TrailingZeroes
{
    using Common;
    using System;
    using System.Linq;

    /// <summary>
    /// 18. Write a program that calculates with how many zeroes the factorial of a given number n has at its end.
    ///     Your program should work well for very big numbers, e.g. n = 100000.
    ///     
    ///     Eeasy explanations: http://www.purplemath.com/modules/factzero.htm
    /// </summary>
    public class TrailingZeroes
    {
        private static void Main()
        {
            uint n = Helpers.ValidateInputAsUint("Please enter positive intiger: ");
            uint count = 0;
            uint divider = 5;

            // I use this method just for check if everythink works correctly:
            Console.WriteLine(Helpers.CalcFactorialBigInteger(n));

            // Here is zero counter program
            while ((n / divider) >= 1)
            {
                count = count + (n / divider);
                divider *= divider;
            }

            Console.WriteLine(count);
        }
    }
}