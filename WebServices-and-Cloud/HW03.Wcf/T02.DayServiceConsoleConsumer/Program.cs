using System;
using DayServiceConsoleConsumer.DayOfWeekService;

namespace DayServiceConsoleConsumer
{
    /// <summary>
    /// 2. Create a console-based client for the WCF service above. Use the "Add Service Reference" in Visual Studio.
    /// 
    /// README: First start service from T01.DayService to be able to test this service
    /// </summary>
    public class Program
    {
        private static void Main()
        {
            var client = new GetDayOfWeekClient();
            
            // With Async
            for (int i = 0; i < 10; i++)
            {
                client.DayOfWeekInBulgarianAsync(DateTime.Now.AddDays(i)).ContinueWith(day =>
                {
                    var responseDay = day.Result;
                    Console.WriteLine(responseDay);
                });
            }

            // With Simple
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(client.DayOfWeekInBulgarian(DateTime.Now.AddDays(i)));
            }
        }
    }
}
