namespace T11.NumbersIntervalDividableGivenNumber
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// 11. Write a program that reads two positive integer numbers and prints how many numbers p exist between them such that the reminder of the division by 5 is 0.
    /// </summary>
    public class NumbersIntervalDividableGivenNumber
    {
        private static void Main()
        {
            const int Devider = 5;

            int start = ReadAndValidateInput("Enter start = ");
            int end = ReadAndValidateInput("Enter end = ");

            List<int> numbers = new List<int>();

            for (int i = start; i <= end; i++)
            {
                if (i % Devider == 0)
                {
                    numbers.Add(i);
                }
            }

            Console.Write("Numbers: " + numbers.Count());
            Console.WriteLine();

            numbers.ForEach(x => Console.Write(x + " "));
            Console.WriteLine();
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