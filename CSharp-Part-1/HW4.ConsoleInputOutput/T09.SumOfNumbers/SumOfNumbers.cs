namespace T09.SumOfNumbers
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    /// <summary>
    /// 9. Write a program that enters a number n and after that enters more n numbers and calculates and prints their sum. Note: You may need to use a for-loop.
    /// </summary>
    public class SumOfNumbers
    {
        private static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            double numbers = ValidateInput("How many numbers you would like to sum: ");
            double sum = 0;
            for (double i = 1; i <= numbers; i++)
            {
                double num = ValidateInput("Enter number " + i + ": ");
                sum += num;
            }

            Console.WriteLine("The sum is: {0}", sum);
        }

        private static double ValidateInput(string message)
        {
            double number;

            Console.Write(message);
            bool isValid = double.TryParse(Console.ReadLine().ToString().Replace(',', '.'), out number);
            while (isValid == false)
            {
                Console.Write("Invalid number! {0}", message);
                isValid = double.TryParse(Console.ReadLine().ToString().Replace(',', '.'), out number);
            }

            return number;
        }
    }
}