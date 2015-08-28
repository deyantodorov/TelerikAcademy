namespace T01.IsLeap
{
    using System;

    /// <summary>
    /// 1. Write a program that reads a year from the console and checks whether it is a leap. Use DateTime.
    /// </summary>
    public class IsLeap
    {
        private static void Main()
        {
            CheckYear("Enter year: ");
        }

        private static void CheckYear(string message)
        {
            int year;
            Console.Write(message);
            bool isValid = int.TryParse(Console.ReadLine(), out year);
            while (!isValid || (year < 1 || year > 9999))
            {
                Console.Write("Invalid year! " + message);
                isValid = int.TryParse(Console.ReadLine(), out year);
            }

            Leap(year);
        }

        private static void Leap(int year)
        {
            if (DateTime.IsLeapYear(year))
            {
                Console.WriteLine("{0} is leap year", year);
            }
            else
            {
                Console.WriteLine("{0} is not leap year", year);
            }
        }
    }
}
