using System;

namespace AdapterPattern
{
    public class Program
    {
        private static void Main()
        {
            ITarget adapter = new VendorAdapter();

            foreach (var product in adapter.GetProducts())
            {
                Console.WriteLine(product);
            }
        }
    }
}
