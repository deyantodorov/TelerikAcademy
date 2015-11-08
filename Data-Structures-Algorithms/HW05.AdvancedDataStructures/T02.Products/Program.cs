namespace T02.Products
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// 2. Write a program to read a large collection of products (name + price) and efficiently find the first 20 products in 
    ///    the price range [a…b].
    ///    Test for 500 000 products and 10 000 price searches.
    ///    Hint: you may use OrderedBag<T> and sub-ranges.
    /// </summary>
    public class Program
    {
        private static RandomGenerator generator = new RandomGenerator();

        private static void Main()
        {
            var sw = new Stopwatch();
            sw.Start();

            Console.WriteLine("Products creation start " + sw.Elapsed);
            
            var catalog = MakeCatalog(500000);
            sw.Stop();

            Console.WriteLine("Products creation end " + sw.Elapsed);

            sw.Reset();
            sw.Start();
            Console.WriteLine("Search start " + sw.Elapsed);

            ProcessPriceSearches(catalog, 100000);

            sw.Stop();
            Console.WriteLine("Search end " + sw.Elapsed);
        }

        private static void ProcessPriceSearches(Catalog catalog, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var products = catalog.GetProductsInPriceRange(generator.GetRandomNumber(1, 5), generator.GetRandomNumber(6, 25));

                // TODO: If you have free time uncomment this code :)
                //foreach (var product in products)
                //{
                //    Console.WriteLine(product);
                //}
            }
        }

        private static Catalog MakeCatalog(int count)
        {
            var result = new Catalog();

            for (int i = 0; i < count; i++)
            {
                var product = new Product()
                {
                    Name = generator.GetRandomString(5, 20),
                    Price = generator.GetRandomNumber(1, 50)
                };

                result.Add(product);
            }

            return result;
        }
    }
}
