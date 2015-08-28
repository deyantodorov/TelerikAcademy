namespace T05.Workdays
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    /// <summary>
    /// 5. Write a method that calculates the number of workdays between today and given date, passed as parameter. 
    ///    Consider that workdays are all days from Monday to Friday except a fixed list of public holidays specified preliminary as array.
    /// </summary>
    public class Workdays
    {
        public static int WorkingDays(DateTime todayDate, DateTime endDate)
        {
            int dayCount = 0;
            List<DateTime> holidays = GetHolidays();

            while (endDate.CompareTo(todayDate) > 0)
            {
                // Check if the day is not weekend day
                if ((todayDate.DayOfWeek != DayOfWeek.Saturday) && (todayDate.DayOfWeek != DayOfWeek.Sunday) && (!holidays.Contains(todayDate)))
                {
                    dayCount++;
                }

                // Go to next day
                todayDate = todayDate.AddDays(1);
            }

            return dayCount;
        }

        public static List<DateTime> GetHolidays()
        {
            // Bulgarian holidays
            List<DateTime> holidays = new List<DateTime>();
            holidays.Add(new DateTime(DateTime.Now.Year, 1, 1));
            holidays.Add(new DateTime(DateTime.Now.Year, 5, 1));
            holidays.Add(new DateTime(DateTime.Now.Year, 5, 2));
            holidays.Add(new DateTime(DateTime.Now.Year, 5, 3));
            holidays.Add(new DateTime(DateTime.Now.Year, 5, 6));
            holidays.Add(new DateTime(DateTime.Now.Year, 5, 24));
            holidays.Add(new DateTime(DateTime.Now.Year, 9, 6));
            holidays.Add(new DateTime(DateTime.Now.Year, 12, 24));
            holidays.Add(new DateTime(DateTime.Now.Year, 12, 25));
            holidays.Add(new DateTime(DateTime.Now.Year, 12, 26));
            holidays.Add(new DateTime(DateTime.Now.Year, 12, 31));
            return holidays;
        }

        public static DateTime ReadDate(string message)
        {
            Console.Write(message);

            string text = Console.ReadLine();
            string format = "dd.MM.yyyy";
            DateTime inputDate = DateTime.ParseExact(text, format, CultureInfo.InvariantCulture);
            return inputDate;
        }

        private static void Main()
        {
            DateTime todayDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            DateTime endDate = ReadDate("Write end date (dd.mm.yyyy): ");

            int dayCount = WorkingDays(todayDate, endDate);

            if (dayCount == 0)
            {
                Console.WriteLine("Get some beers you don't have to work anymore :)");
            }
            else
            {
                Console.WriteLine(dayCount + " workdays");
            }
        }
    }
}
