using System.Collections.Generic;

namespace AdapterPattern
{
    public class VendorAdaptee : ITarget
    {
        public List<string> GetProducts()
        {
            var products = new List<string>()
            {
                "Gaming consoles",
                "Television",
                "Books",
                "Musical instruments",
                "CD",
            };

            return products;
        }
    }
}
