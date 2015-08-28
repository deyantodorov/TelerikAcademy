namespace T10.FactorialCalculator
{
    using System;
    using System.Numerics;

    /// <summary>
    /// 10. Write a program to calculate n! for each n in the range [1..100]. 
    ///     Hint: Implement first a method that multiplies a number represented as array of digits by given integer number. 
    /// </summary>
    public class FactorialCalculator
    {
        private static void Main()
        {
            CalcFac(100);
        }

        private static void CalcFac(int end)
        {
            BigInteger result = 1;

            for (int i = 1; i <= end; i++)
            {
                result *= i;
                Console.WriteLine(result);
            }
        }
    }
}
