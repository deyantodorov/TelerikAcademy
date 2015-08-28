namespace Cosmetics.Products
{
    using System.Collections.Generic;
    using System.Linq;

    using Cosmetics.Common;
    using Cosmetics.Contracts;

    public class ShoppingCart : IShoppingCart
    {
        private readonly IList<IProduct> products;

        public ShoppingCart()
        {
            this.products = new List<IProduct>();
        }

        public void AddProduct(IProduct product)
        {
            this.ValidateInputProduct(product);
            this.products.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            this.ValidateInputProduct(product);
            this.products.Remove(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            this.ValidateInputProduct(product);
            return this.products.Contains(product);
        }

        public decimal TotalPrice()
        {
            return this.products.Sum(product => product.Price);
        }

        private void ValidateInputProduct(IProduct product)
        {
            Validator.CheckIfNull(product, string.Format(GlobalErrorMessages.ObjectCannotBeNull, product.Name));
        }
    }
}
