namespace FurnitureManufacturer.Models
{
    using Interfaces;

    public abstract class Furniture : IFurniture
    {
        private const int ModelMinLength = 3;
        private const decimal PriceMinValue = 0.00m;
        private const decimal HeightMinValue = 0.00m;

        private string model;
        private decimal price;
        private decimal height;

        protected Furniture(string model, MaterialType materialType, decimal price, decimal height)
        {
            this.Model = model;
            this.Price = price;
            this.Height = height;
            this.Material = materialType.ToString();
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            protected set
            {
                Validation.StringIsNullOrEmpty(value, "Name");
                Validation.LessThan(value.Length, Furniture.ModelMinLength, "Name");
                this.model = value;
            }
        }

        public string Material { get; protected set; }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                Validation.LessThanOrEqual(value, Furniture.PriceMinValue, "Price");
                this.price = value;
            }
        }

        public decimal Height
        {
            get
            {
                return this.height;
            }

            protected set
            {
                Validation.LessThanOrEqual(value, Furniture.HeightMinValue, "Height");
                this.height = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}", this.GetType().Name, this.Model, this.Material, this.Price, this.Height);
        }
    }
}