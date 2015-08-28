namespace FurnitureManufacturer.Models
{
    using Interfaces;

    public class Chair : Furniture, IChair
    {
        private const int MinNumberOfLegs = 0;

        private int numberOfLegs;

        public Chair(string model, MaterialType materialType, decimal price, decimal height, int numberOfLegs)
            : base(model, materialType, price, height)
        {
            this.NumberOfLegs = numberOfLegs;
        }

        public int NumberOfLegs
        {
            get
            {
                return this.numberOfLegs;
            }

            private set
            {
                Validation.LessThanOrEqual(value, Chair.MinNumberOfLegs, "NumberOfLegs");
                this.numberOfLegs = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}, Legs: {1}", base.ToString(), this.NumberOfLegs);
        }
    }
}