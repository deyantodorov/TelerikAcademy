namespace T12.ZeroSubset
{
    using System;
    using System.Linq;

    /// <summary>
    /// 12. We are given 5 integer numbers. Write a program that finds all subsets of these numbers whose sum is 0. 
    ///     Assume that repeating the same subset several times is not a problem.
    /// </summary>
    public class ZeroSubset
    {
        private static void Main()
        {
            int n = ValidateInput("How many integer numbers: ");
            int sum = ValidateInput("What sum we are looking for: ");

            int[] arrayN = new int[n];
            for (int i = 0; i < arrayN.Length; i++)
            {
                arrayN[i] = ValidateInput("Value for index " + (i + 1) + ": ");
            }

            int count = 0;

            long maxN = PowerOfNumber(n);

            for (int i = 1; i <= maxN; i++)
            {
                int currentSum = 0;
                for (int j = 0; j < n; j++)
                {
                    int mask = 1 << j;
                    int andMask = i & mask;
                    int bit = andMask >> j;
                    if (bit == 1)
                    {
                        currentSum += arrayN[j];
                    }
                }

                if (currentSum == sum)
                {
                    count++;
                }
            }

            if (count == 0)
            {
                Console.WriteLine("No subsets with sum {0}", sum);
            }
            else
            {
                Console.WriteLine("Subsets with sum {0} are {1}", sum, count);
            }
        }

        /// <summary>
        /// Validation method
        /// </summary>
        private static int ValidateInput(string message)
        {
            int number;

            Console.Write(message);
            bool isValid = int.TryParse(Console.ReadLine(), out number);
            while (isValid == false)
            {
                Console.Write("Invalid number! {0}", message);
                isValid = int.TryParse(Console.ReadLine(), out number);
            }

            return number;
        }

        /// <summary>
        /// All combinations 32 - 1; Use for instead of Math.Pow(2,n), because it's faster;
        /// </summary>
        private static long PowerOfNumber(long number)
        {
            long power = 1;
            for (int i = 1; i < number; i++)
            {
                power *= 2;
            }

            return power -= 1;
        }
    }
}