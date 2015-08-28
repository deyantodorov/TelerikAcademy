namespace T06.NKFactorial
{
    using System;
    using System.Linq;
    using Common;

    /// <summary>
    /// 6. Write a program that calculates n! / k! for given n and k (1 < k < n < 100).
    ///    Use only one loop.
    /// </summary>
    public class NKFactorial
    {
        private static void Main()
        {
            uint n = Helpers.ValidateInputAsUint("Enter value for N = ");
            uint k = Helpers.ValidateInputAsUint("Enter value for K = ");

            decimal result = Helpers.CalcFactorial(n) / Helpers.CalcFactorial(k);
            Console.WriteLine("N!/K! = {0}", result);
        }
    }
}