namespace T10.OddAndEvenProduct
{
    using System;
    using System.Linq;

    /// <summary>
    /// 10. You are given n integers (given in a single line, separated by a space).
    ///     Write a program that checks whether the product of the odd elements is equal to the product of the even elements. 
    ///     Elements are counted from 1 to n, so the first element is odd, the second is even, etc.
    /// </summary>
    public class OddAndEvenProduct
    {
        private static void Main()
        {
            var input = new string[] {
                "2 1 1 6 3",
                "3 10 4 6 5 1",
                "4 3 2 5 2",
            };

            for (int i = 0; i < input.Length; i++)
            {
                Console.WriteLine(FindProduct(input[i]));
            }
        }

        private static string FindProduct(string input)
        {
            var numbers = input.Trim().Split(' ');
            var oddProduct = 1;
            var evenProduct = 1;

            for (int i = 0; i < numbers.Length; i++)
            {
                if ((i + 1) % 2 == 0)
                {
                    evenProduct *= int.Parse(numbers[i]);
                }
                else
                {
                    oddProduct *= int.Parse(numbers[i]);
                }
            }

            if (oddProduct == evenProduct)
            {
                return string.Format("Yes, odd product = {0} and even product = {1}", oddProduct, evenProduct);
            }
            else
            {
                return string.Format("No, odd product = {0} and even product = {1}", oddProduct, evenProduct);
            }
        }
    }
}