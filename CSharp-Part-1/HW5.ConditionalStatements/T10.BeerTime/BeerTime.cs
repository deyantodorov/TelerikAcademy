namespace T10.BeerTime
{
    using System;
    using System.Linq;

    /// <summary>
    /// 10. A beer time is after 1:00 PM and before 3:00 AM.
    ///     Write a program that enters a time in format “hh:mm tt” (an hour in range [01...12], a minute in range [00…59] and AM / PM designator) and 
    ///     prints beer time or non-beer time according to the definition above or invalid time if the time cannot be parsed. Note: You may need to learn how to parse dates and times.
    /// </summary>
    public class BeerTime
    {
        private const string DateFormat = "hh:mm tt";

        private static readonly DateTime start = DateTime.ParseExact("01:00 PM", DateFormat, null);
        private static readonly DateTime end = DateTime.ParseExact("03:00 AM", DateFormat, null);

        private static void Main()
        {
            Console.Write("Enter time in format (hh:mm tt): ");
            string input = Console.ReadLine();

            try
            {
                DateTime inputTime = DateTime.ParseExact(input, DateFormat, null);

                if (inputTime >= start && inputTime >= end)
                {
                    Console.WriteLine("beer time - the time is {0}", inputTime);
                    //Console.WriteLine(start + " start");
                    //Console.WriteLine(end + " end");
                    //Console.WriteLine(inputTime + " input");
                }
                else
                {
                    Console.WriteLine("non-beer - the time is {0}", inputTime);
                    //Console.WriteLine(start + " start");
                    //Console.WriteLine(end + " end");
                    //Console.WriteLine(inputTime + " input");
                }
            }
            catch (Exception)
            {

                Console.WriteLine("invalid time");
            }
        }
    }
}