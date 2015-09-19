using System;

namespace ObserverPattern
{
    // This example shows observer pattern on simple product where we change product prices
    public class Program
    {
        private static void Main()
        {
            var product = new SomeProduct();

            var shop1 = new Shop("Shop 1", 11.11f);
            var shop2 = new Shop("Shop 2", 22.11f);
            var shop3 = new Shop("Shop 3", 33.11f);
            var shop4 = new Shop("Shop 4", 44.11f);

            Console.WriteLine($"Before update");
            Console.WriteLine(shop1);
            Console.WriteLine(shop2);
            Console.WriteLine(shop3);
            Console.WriteLine(shop4);

            product.Attach(shop1);
            product.Attach(shop2);
            product.Attach(shop3);
            product.Attach(shop4);

            product.ChangePrice(23.0f);

            Console.WriteLine();
            Console.WriteLine($"After update 1");
            Console.WriteLine(shop1);
            Console.WriteLine(shop2);
            Console.WriteLine(shop3);
            Console.WriteLine(shop4);

            product.Detach(shop3);
            product.Detach(shop4);

            Console.WriteLine();
            Console.WriteLine($"After update 2");
            product.ChangePrice(26.0f);
            Console.WriteLine(shop1);
            Console.WriteLine(shop2);
            Console.WriteLine(shop3);
            Console.WriteLine(shop4);
        }
    }
}
