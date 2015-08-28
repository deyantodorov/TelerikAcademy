namespace FurnitureManufacturer.Models
{
    using Interfaces;

    public class Table : Furniture, ITable
    {
        private const decimal LengthMinValue = 0.00m;
        private const decimal WidthMinValue = 0.00m;

        private decimal width;
        private decimal length;

        public Table(string model, MaterialType materialType, decimal price, decimal height, decimal width, decimal length)
            : base(model, materialType, price, height)
        {
            this.Width = width;
            this.Length = length;
        }

        public decimal Length
        {
            get
            {
                return this.length;
            }

            private set
            {
                Validation.LessThanOrEqual(value, Table.LengthMinValue, "Length");
                this.length = value;
            }
        }

        public decimal Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                Validation.LessThanOrEqual(value, Table.WidthMinValue, "Length");
                this.width = value;
            }
        }

        public decimal Area
        {
            get { return this.Length * this.Width; }
        }

        public override string ToString()
        {
            return string.Format("{0}, Length: {1}, Width: {2}, Area: {3}", base.ToString(), this.Length, this.Width, this.Area);
        }
    }
}