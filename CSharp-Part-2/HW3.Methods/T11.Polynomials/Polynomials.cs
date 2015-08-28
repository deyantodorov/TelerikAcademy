namespace T11.Polynomials
{
    using System;
    using Helper;

    /// <summary>
    /// 11. Write a method that adds two polynomials. Represent them as arrays of their coefficients as in the 
    ///     example below: x2 + 5 = 1x2 + 0x + 5 -> 501
    /// </summary>
    public class Polynomials
    {
        /// <summary>
        /// Method for addition and substraction of polynomials
        /// </summary>
        /// <param name="first">first polynomial</param>
        /// <param name="second">second polynomial</param>
        /// <param name="operation">minus (-) or plus (+) sign</param>
        /// <returns></returns>
        public static decimal[] PolynomialsSumOrSub(decimal[] first, decimal[] second, char operation)
        {
            if (!operation.Equals('-') && !operation.Equals('+'))
            {
                throw new ArgumentException("Sorry. I know how to add or substract, nothing else!");
            }

            bool addition = false;
            if (operation == '+')
            {
                addition = true;
            }

            int max = Math.Max(first.Length, second.Length);
            int min = Math.Min(first.Length, second.Length);

            bool firstIsMax = false;
            bool secondIsMax = false;
            if (max == first.Length)
            {
                firstIsMax = true;
            }
            else
            {
                secondIsMax = true;
            }

            decimal[] result = new decimal[max];

            if (addition)
            {
                for (int i = 0; i < min; i++)
                {
                    result[i] = first[i] + second[i];
                }
            }
            else
            {
                for (int i = 0; i < min; i++)
                {
                    result[i] = first[i] - second[i];
                }
            }

            if (firstIsMax)
            {
                for (int i = min; i < max; i++)
                {
                    result[i] += first[i];
                }
            }

            if (secondIsMax)
            {
                for (int i = min; i < max; i++)
                {
                    result[i] += second[i];
                }
            }

            return result;
        }

        public static void PrintPolinomial(decimal[] polinomial)
        {
            for (int i = polinomial.Length - 1; i >= 0; i--)
            {
                if (polinomial[i] != 0 && i != 0)
                {
                    if (polinomial[i - 1] >= 0)
                    {
                        Console.Write("{0}x^{1} + ", polinomial[i], i);
                    }
                    else
                    {
                        Console.Write("{0}x^{1} ", polinomial[i], i);
                    }
                }
                else if (i == 0)
                {
                    Console.Write("{0}", polinomial[i]);
                }
            }

            Console.WriteLine();
        }

        private static void Main()
        {
            decimal[] first = { 5, 0, 1 };
            decimal[] second = { 6, -2, 1, 3, 2 };
            decimal[] result = PolynomialsSumOrSub(first, second, '-');

            Console.Write("First is: ");
            Helper.PrintArray<decimal>(first);
            PrintPolinomial(first);

            Console.Write("Second is: ");
            Helper.PrintArray<decimal>(second);
            PrintPolinomial(second);

            Console.Write("Result is: ");
            Helper.PrintArray<decimal>(result);
            PrintPolinomial(result);
        }
    }
}