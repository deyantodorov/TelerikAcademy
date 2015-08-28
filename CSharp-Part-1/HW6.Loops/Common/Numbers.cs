namespace Common
{
    using System;
    using System.Numerics;

    /// <summary>
    /// Helper methods for numbers
    /// </summary>
    public class Numbers
    {
        public static decimal CalcFactorial(uint count)
        {
            decimal factorial = 1;
            for (int i = 1; i <= count; i++)
            {
                factorial *= i;
            }

            return factorial;
        }

        public static BigInteger CalcFactorialBigInteger(uint count)
        {
            BigInteger factorial = 1;
            for (int i = 1; i <= count; i++)
            {
                factorial *= i;
            }

            return factorial;
        }

        public static int NumberToPower(int number, int power)
        {
            int n = number;
            int p = power;
            int result = 1;
            for (int i = 0; i < p; i++)
            {
                result *= n;
            }

            return result;
        }
    }
}
