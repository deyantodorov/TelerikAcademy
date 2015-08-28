namespace Cosmetics.Products
{
    using System;
    using System.Text;

    using Cosmetics.Common;
    using Cosmetics.Contracts;

    public abstract class Product : IProduct
    {
        private const int MaxNameLength = 10;
        private const int MinNameLength = 3;
        private const int MaxBrandLength = 10;
        private const int MinBrandLength = 2;
        private const string InvalidPrice = "Invalid price";
        private const string BrandNamePrintFormat = " - {0} - {1}:";
        private const string PricePrintFormat = "  * Price: ${0}";
        private const string GenderPrintFormat = "  * For gender: {0}";
        private const string PrintName = "Product name";
        private const string PrintBrand = "Product brand";

        private string name;
        private string brand;
        private decimal price;

        protected Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, Product.PrintName));
                Validator.CheckIfStringLengthIsValid(value, Product.MaxNameLength, Product.MinNameLength, string.Format(GlobalErrorMessages.InvalidStringLength, Product.PrintName, Product.MinNameLength, Product.MaxNameLength));
                this.name = value;
            }
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }

            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, Product.PrintBrand));
                Validator.CheckIfStringLengthIsValid(value, Product.MaxBrandLength, Product.MinBrandLength, string.Format(GlobalErrorMessages.InvalidStringLength, Product.PrintBrand, Product.MinBrandLength, Product.MaxBrandLength));
                this.brand = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", Product.InvalidPrice);
                }

                this.price = value;
            }
        }

        public GenderType Gender { get; private set; }

        public virtual string Print()
        {
            var sb = new StringBuilder();

            sb.AppendLine(string.Format(Product.BrandNamePrintFormat, this.Brand, this.Name));
            sb.AppendLine(string.Format(Product.PricePrintFormat, this.Price)); // TODO: Fix currency symbol
            sb.AppendLine(string.Format(Product.GenderPrintFormat, this.Gender));

            return sb.ToString();
        }

        public override string ToString()
        {
            return this.Print();
        }
    }
}