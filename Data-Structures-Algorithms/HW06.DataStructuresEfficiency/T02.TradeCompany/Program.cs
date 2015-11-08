using System;
using System.Diagnostics;

namespace T02.TradeCompany
{
    /// <summary>
    /// 2. A large trade company has millions of articles, each described by barcode, vendor, title and price.
    /// Implement a data structure to store them that allows fast retrieval of all articles in given price range [x…y].
    /// Hint: use OrderedMultiDictionary<K,T> from Wintellect's Power Collections for .NET.
    /// </summary>
    public class Program
    {
        private static RandomGenerator generator = new RandomGenerator();

        private static void Main()
        {
            var products = 5000;
            var searches = 10000;

            var sw = new Stopwatch();
            sw.Start();

            Console.WriteLine("Article creation START of {0} products in {1}", products, sw.Elapsed);

            var store = MakeStore(products);
            sw.Stop();

            Console.WriteLine("Article creation END of {0} products in {1}", products, sw.Elapsed);

            sw.Reset();
            sw.Start();
            Console.WriteLine("Search START of {0} queries in {1}", searches, sw.Elapsed);

            ProcessPriceSearches(store, 1000);

            sw.Stop();
            Console.WriteLine("Search END of {0} queries in {1}", searches, sw.Elapsed);
        }

        private static void ProcessPriceSearches(Store catalog, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var products = catalog.FilterByPriceRange(generator.GetRandomNumber(1, 5), generator.GetRandomNumber(6, 25));

                // TODO: If you have free time uncomment this code :)
                //foreach (var product in products)
                //{
                //    Console.WriteLine(product);
                //}
            }
        }

        private static Store MakeStore(int count)
        {
            var result = new Store();

            for (int i = 0; i < count; i++)
            {
                var article = new Article()
                {
                    Barcode = generator.GetRandomString(30, 50),
                    Vendor = generator.GetRandomString(20, 80),
                    Title = generator.GetRandomString(20, 80),
                    Price = generator.GetRandomNumber(1, 50),
                };

                result.Add(article);
            }

            return result;
        }
    }
}
