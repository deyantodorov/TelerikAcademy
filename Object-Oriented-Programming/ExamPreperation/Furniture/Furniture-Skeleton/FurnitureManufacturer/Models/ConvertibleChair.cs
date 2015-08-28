namespace FurnitureManufacturer.Models
{
    using Interfaces;

    public class ConvertibleChair : Chair, IConvertibleChair
    {
        private const decimal ConvertSize = 0.10m;
        private decimal initialHeight;

        public ConvertibleChair(string model, MaterialType materialType, decimal price, decimal height, int numberOfLegs)
            : base(model, materialType, price, height, numberOfLegs)
        {
            // Normal state
            this.IsConverted = false;
        }

        public bool IsConverted { get; private set; }

        public void Convert()
        {
            if (!this.IsConverted)
            {
                // Converted
                this.IsConverted = true;
                this.initialHeight = this.Height;
                this.Height = ConvertibleChair.ConvertSize;
            }
            else
            {
                // Normal
                this.IsConverted = false;
                this.Height = this.initialHeight;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}, State: {1}", base.ToString(), this.IsConverted ? "Converted" : "Normal");
        }
    }
}