namespace T03.Exceptions
{
    using System;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// https://github.com/TelerikAcademy/Object-Oriented-Programming/blob/master/05.%20OOP%20Principles%20-%20Part%202/README.md#problem-3-range-exceptions
    /// </summary>
    public class MainProgram
    {
        private static void Main()
        {
            IntExample();
            DateTimeExample();
        }

        private static void DateTimeExample()
        {
            DateTime startDate = new DateTime(1980, 1, 1);
            DateTime endDate = new DateTime(2013, 12, 31);

            // DateTime example:
            InvalidRangeException<DateTime> invalidDateTimeException = new InvalidRangeException<DateTime>("Date isn't in correct range from 1.1.1980 to 31.12.2013", startDate, endDate);
            Console.Write("Enter some date in format d.m.yyyy from 1.1.1980 to 31.12.2013: ");

            string datePattern = "m.d.yyyy";
            string input = Console.ReadLine();

            DateTime yourDate;

            DateTime.TryParseExact(input, datePattern, CultureInfo.InvariantCulture, DateTimeStyles.None, out yourDate);

            if (yourDate < invalidDateTimeException.Start || yourDate > invalidDateTimeException.End)
            {
                throw invalidDateTimeException;
            }
            else
            {
                Console.WriteLine("Your date is in correct format!");
            }
        }

        private static void IntExample()
        {
            // Int Example:
            InvalidRangeException<int> invalidIntException = new InvalidRangeException<int>("Enter number in the range from 0 to 100!", 0, 100);
            Console.Write("Enter some number in range from 0 to 100: ");
            int number = int.Parse(Console.ReadLine());

            if (number < invalidIntException.Start || number > invalidIntException.End)
            {
                throw invalidIntException;
            }
            else
            {
                Console.WriteLine("Your number is in correct format.");
            }
        }
    }
}
