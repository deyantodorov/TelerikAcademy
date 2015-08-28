namespace T14.CurrentDateAndTime
{
    using System;
    using System.Threading;
    using System.Globalization;

    /// <summary>
    /// 14. Create a console application that prints the current date and time. Find out how in Internet.
    /// </summary>
    public class CurrentDateAndTime
    {
        private static void Main()
        {
            // Setting date and time to invariant culture
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            Console.WriteLine(DateTime.Now);
        }
    }
}