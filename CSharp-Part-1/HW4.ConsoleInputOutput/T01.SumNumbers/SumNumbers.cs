namespace T01.SumNumbers
{
    using System;

    /// <summary>
    /// 1. Write a program that reads 3 integer numbers from the console and prints their sum.
    /// </summary>
    public class SumNumbers
    {
        private static void Main()
        {
            int a = ReadAndValidateInput("Enter value for \"a\" = ");
            int b = ReadAndValidateInput("Enter value for \"b\" = ");
            int c = ReadAndValidateInput("Enter value for \"c\" = ");

            Console.WriteLine("The sum of {0} + {1} + {2} = {3}", a, b, c, a + b + c);
        }

        private static int ReadAndValidateInput(string msg)
        {
            int number;

            Console.Write(msg);

            bool isValid = int.TryParse(Console.ReadLine(), out number);
            while (isValid == false)
            {
                Console.Write("Invalid number! {0}", msg);
                isValid = int.TryParse(Console.ReadLine(), out number);
            }

            return number;
        }
    }
}
