namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Cosmetics.Common;
    using Cosmetics.Contracts;

    public class Category : ICategory
    {
        private const string CategoryNamePrintName = "Category name";
        private const int CategoryNameMaxLength = 15;
        private const int CategoryNameMinLength = 2;
        private const string IproductPrintName = "IProduct";
        private const string ProductDoesNotExistInCategory = "Product {0} does not exist in category {1}!";
        private const string CategoryProductsInTotalNone = "{0} category - 0 products in total";
        private const string CategoryInTotalPrint = "{0} category - {1} {2} in total";
        private const string ProductsPrintName = "products";
        private const string ProductPrintName = "product";
        
        private readonly IList<IProduct> products;
        private string name;

        public Category(string name)
        {
            this.Name = name;
            this.products = new List<IProduct>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, string.Format(GlobalErrorMessages.ObjectCannotBeNull, Category.CategoryNamePrintName));
                Validator.CheckIfStringLengthIsValid(value, Category.CategoryNameMaxLength, Category.CategoryNameMinLength, string.Format(GlobalErrorMessages.InvalidStringLength, Category.CategoryNamePrintName, Category.CategoryNameMinLength, Category.CategoryNameMaxLength));
                this.name = value;
            }
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            this.ValidateInputCosmetics(cosmetics);
            this.products.Add(cosmetics);
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            this.ValidateInputCosmetics(cosmetics);

            if (!this.products.Remove(cosmetics))
            {
                throw new ArgumentOutOfRangeException(string.Format(Category.ProductDoesNotExistInCategory, cosmetics.Name, this.Name));
            }
        }

        public string Print()
        {
            var sb = new StringBuilder();

            // Products in category should be sorted by brand in ascending order and then by price in descending order. 
            var sortProducts = this.products.OrderBy(x => x.Brand).ThenByDescending(x => x.Price);

            if (sortProducts.Any())
            {
                // ForMale category - 1 product in total
                // ForMale category - 2 products in total
                sb.AppendLine(string.Format(Category.CategoryInTotalPrint, this.Name, sortProducts.Count(), sortProducts.Count() > 1 ? Category.ProductsPrintName : Category.ProductPrintName));

                foreach (var sortProduct in sortProducts)
                {
                    sb.AppendLine(sortProduct.ToString());
                }
            }
            else
            {
                sb.AppendLine(string.Format(Category.CategoryProductsInTotalNone, this.Name));
            }

            return sb.ToString().Trim();
        }

        public override string ToString()
        {
            return this.Print();
        }

        private void ValidateInputCosmetics(IProduct cosmetics)
        {
            Validator.CheckIfNull(cosmetics, string.Format(GlobalErrorMessages.ObjectCannotBeNull, Category.IproductPrintName));
        }
    }
}
