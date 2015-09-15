using System;

namespace ProxyPattern
{
    /// <summary>
    /// Before running this App run ProxyPatternServer and DON'T close it. This will simulate client-server proxy
    /// </summary>
    public class Program
    {
        private static void Main()
        {
            IActualPrice proxy = new ActualPriceProxy();

            Console.WriteLine($"Gold price: {proxy.GoldPrice}");
            Console.WriteLine($"Silver price: {proxy.SilverPrice}");
            Console.WriteLine($"Dollar to Ruppe conversion: {proxy.DollarToRupee}");
        }
    }
}
