namespace T08.NumbersFrom1ToN
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    /// <summary>
    /// 8. Write a program that reads an integer number n from the console and prints all the numbers in the interval [1..n], 
    /// </summary>
    public class NumbersFrom1ToN
    {
        private static void Main()
        {
            int numbers = ValidateInput("Enter integer: ");
            for (double i = 1; i <= numbers; i++)
            {
                Console.WriteLine(i);
            }
        }

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
    }
}