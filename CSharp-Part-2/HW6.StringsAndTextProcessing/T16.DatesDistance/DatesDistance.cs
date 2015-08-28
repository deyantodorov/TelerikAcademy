namespace T16.DatesDistance
{
    using System;
    using System.Globalization;

    /// <summary>
    /// 16. Write a program that reads two dates in the format: day.month.year and calculates the number of days between them. 
    /// 
    /// Example:
    /// Enter the first date: 27.02.2006
    /// Enter the second date: 3.03.2006
    /// Distance: 4 days
    /// </summary>
    public class DatesDistance
    {
        private static void Main()
        {
            string dateFormat = "d.M.yyyy";

            Console.Write("First date (d.M.yyyy): ");
            string firstDate = Console.ReadLine();

            Console.Write("Second date (d.M.yyyy): ");
            string secondDate = Console.ReadLine();

            DateTime myFirstDate = new DateTime();
            myFirstDate = DateTime.ParseExact(firstDate, dateFormat, CultureInfo.InvariantCulture);

            DateTime mySecondDate = new DateTime();
            mySecondDate = DateTime.ParseExact(secondDate, dateFormat, CultureInfo.InvariantCulture);

            string distance = (mySecondDate - myFirstDate).TotalDays.ToString();

            Console.WriteLine("Distance: {0} days", distance);
        }
    }
}
