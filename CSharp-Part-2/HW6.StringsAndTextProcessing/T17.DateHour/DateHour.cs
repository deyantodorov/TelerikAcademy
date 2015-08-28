namespace T17.DateHour
{
    using System;
    using System.Globalization;

    /// <summary>
    /// 17. Write a program that reads a date and time given in the format: day.month.year hour:minute:second and 
    ///     prints the date and time after 6 hours and 30 minutes (in the same format) along with the day of week in Bulgarian.
    /// </summary>
    public class DateHour
    {
        private static void Main()
        {
            Console.Write("Date (dd.mm.yyyy hh:mm:ss): ");
            string input = Console.ReadLine();

            DateTime myDate = DateTime.Parse(input, CultureInfo.CreateSpecificCulture("bg-BG"));

            DateTime newDate = myDate.AddHours(6.00).AddMinutes(30.00);

            Console.WriteLine(string.Format("Plus 6 hours and 30 minutes: {0:dd.MM.yyyy h:m:s} and day \"{1}\"", newDate, newDate.ToString("dddd", CultureInfo.CreateSpecificCulture("bg-BG"))));
        }
    }
}
