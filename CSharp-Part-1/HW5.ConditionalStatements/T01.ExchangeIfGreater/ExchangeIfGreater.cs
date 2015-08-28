namespace T01.ExchangeIfGreater
{
    using System;
    using System.Linq;

    /// <summary>
    /// 1. Write an if-statement that takes two double variables a and b and exchanges their values if the first one is greater than the second one. 
    ///    As a result print the values a and b, separated by a space.
    /// </summary>
    public class ExchangeIfGreater
    {
        private static void Main()
        {
            double first = ValidateInput("Enter first value: ");
            double second = ValidateInput("Enter second value: ");

            if (first > second)
            {
                double temp = second;
                second = first;
                first = temp;
            }

            Console.WriteLine("{0} {1}", first, second);
        }

        private static double ValidateInput(string message)
        {
            double number;

            Console.Write(message);
            bool isValid = double.TryParse(Console.ReadLine().Replace(',', '.'), out number);
            while (isValid == false)
            {
                Console.Write("Invalid number! {0}", message);
                isValid = double.TryParse(Console.ReadLine().Replace(',', '.'), out number);
            }

            return number;
        }
    }
}