namespace T15.SieveOfEratosthenes
{
    using System;
    using System.Collections;

    /// <summary>
    /// 15. Write a program that finds all prime numbers in the range [1...10 000 000]. Use the sieve of Eratosthenes algorithm (find it in Wikipedia).
    /// </summary>
    public class SieveOfEratosthenes
    {
        public static ArrayList Sieve(int maxPrime)
        {
            BitArray allNumbers = new BitArray(maxPrime, true);

            int lastPrime = 1;
            int lastPrimeSquare = 1;

            while (lastPrimeSquare <= maxPrime)
            {
                lastPrime++;

                while (!allNumbers[lastPrime])
                {
                    lastPrime++;
                }

                lastPrimeSquare = lastPrime * lastPrime;

                for (int i = lastPrimeSquare; i < maxPrime; i += lastPrime)
                {
                    if (i > 0)
                    {
                        allNumbers[i] = false;
                    }
                }
            }

            ArrayList result = new ArrayList();

            for (int i = 2; i < maxPrime; i++)
            {
                if (allNumbers[i])
                {
                    result.Add(i);
                }
            }

            return result;
        }

        private static void Main()
        {
            int n = 10000000;

            // Just check how much time it takes
            string start = "We started at: " + DateTime.Now.ToString();

            // Fill list with algorithm results
            ArrayList myArray = Sieve(n);

            //// Print results if you want it takes really long time
            //foreach (var item in myArray)
            //{
            //    Console.Write(item + " ");
            //}

            // Just check how much time it takes
            string finish = "We finished at: " + DateTime.Now.ToString();

            // Print test results
            Console.WriteLine(start);
            Console.WriteLine(finish);
        }
    }
}
