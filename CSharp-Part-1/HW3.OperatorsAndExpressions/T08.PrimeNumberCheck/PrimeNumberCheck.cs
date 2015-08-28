namespace T08.PrimeNumberCheck
{
    using System;
    using System.Linq;

    /// <summary>
    /// 8. Write an expression that checks if given positive integer number n (n = 100) is prime (i.e. it is divisible without remainder only to itself and 1).
    /// </summary>
    public class PrimeNumberCheck
    {
        private static void Main()
        {
            int[] num = { 1, 2, 3, 4, 9, 97, 51, -3, 0 };

            for (int i = 0; i < num.Length; i++)
            {
                if (CheckPrime(num[i]))
                {
                    Console.WriteLine(num[i] + " is prime");
                }
                else
                {
                    Console.WriteLine(num[i] + " is NOT prime");
                }
            }


        }

        /// <summary>
        /// If number is prime. Don't need to check more than number square root
        /// </summary>
        /// <param name="number">input number</param>
        /// <returns>is number prime true/false</returns>
        private static bool CheckPrime(int number)
        {
            if (number % 2 == 0 || number == 1 || number < 0)
            {
                if (number == 2)
                {
                    return true;
                }

                return false;
            }

            int max = (int)Math.Sqrt(number);

            for (int i = 3; i <= max; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}