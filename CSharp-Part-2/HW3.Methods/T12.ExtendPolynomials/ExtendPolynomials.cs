namespace T12.ExtendPolynomials
{
    using System;
    using Helper;
    using T11.Polynomials;

    /// <summary>
    /// 12. Extend the program to support also subtraction and multiplication of polynomials.
    /// </summary>
    public class ExtendPolynomials
    {
        private static void Main()
        {
            decimal[] first = { 5, 0, 1 };
            decimal[] second = { 6, -2, 1, 3, 2 };

            // Substraction and Addition are combined in single method which change operations with parameter - or +
            decimal[] substraction = Polynomials.PolynomialsSumOrSub(first, second, '-');

            Console.Write("First is: ");
            Helper.PrintArray<decimal>(first);
            Polynomials.PrintPolinomial(first);

            Console.Write("Second is: ");
            Helper.PrintArray<decimal>(second);
            Polynomials.PrintPolinomial(second);

            Console.Write("Result of substraction: ");
            Helper.PrintArray<decimal>(substraction);
            Polynomials.PrintPolinomial(substraction);

            decimal[] multiplication = MultiplyPolinomials(first, second);

            Console.Write("Result of multiplication: ");
            Helper.PrintArray<decimal>(multiplication);
            Polynomials.PrintPolinomial(multiplication);
        }

        private static decimal[] MultiplyPolinomials(decimal[] first, decimal[] second)
        {
            decimal[] result = new decimal[first.Length + second.Length];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = 0;
            }

            for (int i = 0; i < first.Length; i++)
            {
                for (int j = 0; j < second.Length; j++)
                {
                    int position = i + j;
                    result[position] += (first[i] * second[j]);
                }
            }

            return result;
        }
    }
}
