namespace T02.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Catalog
    {
        private const int NumberOrResults = 20;
        private readonly OrderedBag<Product> products;

        public Catalog()
        {
            this.products = new OrderedBag<Product>();
        }

        public int Count
        {
            get { return this.products.Count; }
        }

        public void Add(Product product)
        {
            CheckForNull(product);
            this.products.Add(product);
        }

        public void Remove(Product product)
        {
            CheckForNull(product);
            this.products.Remove(product);
        }

        public List<Product> GetProductsInPriceRange(decimal minPrice, decimal maxPrice, int number = NumberOrResults)
        {
            var result = this.products
                .Where(x => x.Price >= minPrice && x.Price <= maxPrice)
                .Take(number)
                .ToList();

            return result;
        }

        private static void CheckForNull(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("product", "Product can't be null");
            }
        }
    }
}