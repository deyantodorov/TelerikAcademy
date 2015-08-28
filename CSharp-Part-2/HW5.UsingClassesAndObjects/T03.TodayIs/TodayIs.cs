namespace T03.TodayIs
{
    using System;

    /// <summary>
    /// 3. Write a program that prints to the console which day of the week is today. Use System.DateTime.
    /// </summary>
    public class TodayIs
    {
        private static void Main()
        {
            DateTime today = new DateTime();
            today = DateTime.Now;
            Console.WriteLine("Today is {0}", today.DayOfWeek);
        }
    }
}
