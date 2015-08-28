namespace T15.AgeAfter10Years
{
    using System;
    using System.Threading;
    using System.Globalization;

    /// <summary>
    /// 15. Write a program to read your birthday from the console and print how old you are now and how old you will be after 10 years.
    /// </summary>
    public class AgeAfter10Years
    {
        private const int FutureYears = 10;

        private static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            string birthday = ReadInput();
            DateTime date = ReadDate(birthday);
            int years = CalculateCurrentAge(date.Year);

            int futureAge = years + FutureYears;

            Console.WriteLine("After ten years you will be: {0} years old.", futureAge);
        }

        private static int CalculateCurrentAge(int age)
        {
            if (age > DateTime.Now.Year)
            {
                string birthday = ReadInput();
                DateTime date = ReadDate(birthday);
                int years = CalculateCurrentAge(date.Year);

                return years;
            }
            else
            {
                return DateTime.Now.Year - age;
            }
        }

        private static DateTime ReadDate(string date)
        {
            DateTime result;

            // Test if DateTime parse is correct. Repeat until is corrected
            while (!DateTime.TryParse(date, out result))
            {
                Console.Write("Type your birthday (MM/DD/YYYY): ");
                date = Console.ReadLine();
            }

            return result;
        }

        private static string ReadInput()
        {
            Console.Write("Type your birthday (MM/DD/YYYY): ");
            string birthday = Console.ReadLine();

            return birthday;
        }
    }
}