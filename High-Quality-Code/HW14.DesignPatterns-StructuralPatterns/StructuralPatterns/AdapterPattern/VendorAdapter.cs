using System.Collections.Generic;

namespace AdapterPattern
{
    public class VendorAdapter : ITarget
    {
        public List<string> GetProducts()
        {
            VendorAdaptee adaptee = new VendorAdaptee();
            return adaptee.GetProducts();
        }
    }
}
