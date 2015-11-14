using System;

namespace T05.CompareStringsConsoleClient
{
    /// <summary>
    /// 5. Create a console client for the WCF service above.
    ///    Use the svcutil.exe tool to generate the proxy classes.
    /// </summary>
    public class Program
    {
        private static void Main()
        {
            var stupidClient = new StringCompareClient();

            var result = stupidClient.NumberOfContains("lud", "ne ne si lud, ne si lud mnogo si izmoren ... legni si da ne si lud");
            Console.WriteLine(result);
        }
    }
}
