namespace P3.Task3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;

    public class Task3
    {
        private static List<BigInteger> allNumbers = new List<BigInteger>();

        private static void Main()
        {
            string line = Console.ReadLine();

            while (line != "END")
            {
                allNumbers.Add(BigInteger.Parse(line));
                line = Console.ReadLine();
            }

            if (allNumbers.Count() > 10)
            {
                CalculateWithMore();
            }
            else
            {
                CalculateWithLess();
            }
        }

        private static void CalculateWithMore()
        {
            BigInteger first = 1;
            BigInteger second = 1;

            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    BigInteger product = CalculateProduct(allNumbers[i].ToString());
                    first *= product;
                }
            }

            for (int i = 10; i < allNumbers.Count(); i++)
            {
                if (i % 2 == 0)
                {
                    BigInteger product = CalculateProduct(allNumbers[i].ToString());
                    second *= product;
                }
            }

            Console.WriteLine(first);
            Console.WriteLine(second);
        }

        private static void CalculateWithLess()
        {
            BigInteger result = 1;

            for (int i = 0; i < allNumbers.Count(); i++)
            {
                if (i % 2 == 0)
                {
                    BigInteger product = CalculateProduct(allNumbers[i].ToString());
                    result *= product;
                }
            }

            Console.WriteLine(result);
        }

        private static BigInteger CalculateProduct(string line)
        {
            BigInteger product = 1;

            var lineAsNumber = line.ToArray();

            for (int i = 0; i < lineAsNumber.Length; i++)
            {
                int current = int.Parse(lineAsNumber[i].ToString());

                if (current != 0)
                {
                    product *= current;
                }
            }

            if (product == 0)
            {
                product = 1;
            }

            return product;
        }
    }
}