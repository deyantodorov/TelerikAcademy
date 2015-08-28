namespace T17.GreatestCommonDivisor
{
    using System;
    using System.Linq;
    using Common;

    /// <summary>
    /// 17. Write a program that calculates the greatest common divisor (GCD) of given two integers a and b.
    ///     Use the Euclidean algorithm (find it in Internet).
    /// </summary>
    public class GreatestCommonDivisor
    {
        private static void Main()
        {
            int a = Helpers.ValidateInputAsInt("Enter value for a = ");
            int b = Helpers.ValidateInputAsInt("Enter value for b = ");

            if (a != 0 && b != 0)
            {
                //// I have to find bigger and smaller number to use Eucleadian algorithm to find GCD
                int gcd1 = Math.Max(a, b);
                int gcd2 = Math.Min(a, b);
                int gcd = 0;

                int remainder = gcd1 % gcd2;

                while (remainder != 0)
                {
                    gcd = gcd2 % remainder;
                    gcd2 = remainder;
                    remainder = gcd;
                }

                gcd = gcd2;

                Console.WriteLine("GCD = {0}", gcd);
            }

            if (a == 0 && b != 0)
            {
                Console.WriteLine("GCD is equal to b = {0}", b);
            }

            if (b == 0 && a != 0)
            {
                Console.WriteLine("GCD is equal to a = {0}", a);
            }

            if (a == 0 && b == 0)
            {
                Console.WriteLine("Can't find GCD ({0}, {1})", a, b);
            }
        }
    }
}