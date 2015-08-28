namespace Estates.Data
{
    using Interfaces;

    public class Garage : Estate, IGarage
    {
        private const int GarageMinValue = 0;
        private const int GarageMaxValue = 500;

        private int width;
        private int height;

        public Garage()
        {
        }

        public Garage(string name, EstateType type, double area, string location, bool isFurnished, int width, int height)
            : base(name, type, area, location, isFurnished)
        {
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        /// •	Garage widths and heights should be in range [0…500].
        /// </summary>
        public int Width
        {
            get
            {
                return this.width;
            }

            set
            {
                this.ValidationInRange(value, GarageMinValue, GarageMaxValue);
                this.width = value;
            }
        }

        /// <summary>
        /// •	Garage widths and heights should be in range [0…500].
        /// </summary>
        public int Height
        {
            get
            {
                return this.height;
            }

            set
            {
                this.ValidationInRange(value, GarageMinValue, GarageMaxValue);
                this.height = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}, Width: {1}, Height: {2}", base.ToString(), this.Width, this.Height);
        }
    }
}
