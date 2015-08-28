namespace Estates.Data
{
    using System;
    using Interfaces;

    public abstract class Estate : IEstate
    {
        private const string ErrorStringIsNullOrEmpty = "Value can't be null or empty";
        private const string ErrorAreaOutOfRange = " value must be in range ";

        private const int AreaMinValue = 0;
        private const int AreaMaxValue = 10000;

        private string name;
        private double area;
        private string location;

        protected Estate()
        {
        }

        protected Estate(string name, EstateType type, double area, string location, bool isFurnished)
            : this()
        {
            this.Name = name;
            this.Type = type;
            this.Area = area;
            this.Location = location;
            this.IsFurnished = isFurnished;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.ValidateStringIsNullOrEmpty(value);
                this.name = value;
            }
        }

        public EstateType Type { get; set; }

        /// <summary>
        /// Estate area should be in range [0…10000].
        /// </summary>
        public double Area
        {
            get
            {
                return this.area;
            }
            set
            {
                this.ValidationInRange(value, Estate.AreaMinValue, Estate.AreaMaxValue);
                this.area = value;
            }
        }

        public string Location
        {
            get
            {
                return this.location;
            }

            set
            {
                this.ValidateStringIsNullOrEmpty(value);
                this.location = value;
            }

        }

        public bool IsFurnished { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: Name = {1}, Area = {2}, Location = {3}, Furnitured = {4}",
                this.GetType().Name, this.Name, this.Area, this.Location, this.IsFurnished ? "Yes" : "No");
        }

        protected void ValidateStringIsNullOrEmpty(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(value, Estate.ErrorStringIsNullOrEmpty);
            }
        }

        protected void ValidationInRange<T>(T value, T minValue, T maxValue) where T : IComparable
        {
            if (value.CompareTo(minValue) < 0 || value.CompareTo(maxValue) > 0)
            {
                throw new ArgumentOutOfRangeException(value + Estate.ErrorAreaOutOfRange + minValue + " - " + maxValue);
            }
        }
    }
}
