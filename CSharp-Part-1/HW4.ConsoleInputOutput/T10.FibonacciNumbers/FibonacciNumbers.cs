namespace T10.FibonacciNumbers
{
    using System;
    using System.Linq;
    using System.Numerics;

    /// <summary>
    /// 10. Write a program that reads a number n and prints on the console the first n members of the Fibonacci sequence (at a single line, separated by comma and space - ,): 
    ///     0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, ….
    /// </summary>
    public class FibonacciNumbers
    {
        private static void Main()
        {
            Console.Write("N: ");
            BigInteger n = BigInteger.Parse(Console.ReadLine());

            BigInteger fn;
            BigInteger f1 = -1;
            BigInteger f2 = 1;

            for (BigInteger i = 0; i < n; i++)
            {
                fn = f1 + f2;
                f1 = f2;
                f2 = fn;

                if (i == n - 1)
                {
                    Console.Write("{0}", fn);
                }
                else
                {
                    Console.Write("{0}, ", fn);
                }
            }

            Console.WriteLine();
        }
    }
}