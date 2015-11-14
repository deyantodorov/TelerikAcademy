using System;

namespace DayService
{
    /// <summary>
    /// 1. Create a simple WCF service. It should have a method that accepts a DateTime parameter and returns the day of week 
    ///    (in Bulgarian) as string.
    ///    Test it with the integrated WCF client.
    /// </summary>
    public class GetDayOfWeek : IGetDayOfWeek
    {
        public string DayOfWeekInBulgarian(DateTime date)
        {
            var passedDate = DateTime.Parse(date.ToLongDateString());

            switch (passedDate.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    return "Понеделник";
                case DayOfWeek.Tuesday:
                    return "Вторник";
                case DayOfWeek.Wednesday:
                    return "Сряда";
                case DayOfWeek.Thursday:
                    return "Четвъртък";
                case DayOfWeek.Friday:
                    return "Петък";
                case DayOfWeek.Saturday:
                    return "Събота";
                case DayOfWeek.Sunday:
                    return "Неделя";
                default:
                    throw new ArgumentOutOfRangeException("date", "Invalid date");
            }
        }
    }
}
