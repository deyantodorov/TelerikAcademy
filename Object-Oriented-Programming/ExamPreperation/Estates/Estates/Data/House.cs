namespace Estates.Data
{
    using Interfaces;

    public class House : Estate, IHouse
    {
        private const int HouseMinFloors = 0;
        private const int HouseMaxFloors = 10;

        private int floors;

        public House()
        {
        }

        public House(string name, EstateType type, double area, string location, bool isFurnished, int floors)
            : base(name, type, area, location, isFurnished)
        {
            this.Floors = floors;
        }

        /// <summary>
        /// House floors should be in range [0…10].
        /// </summary>
        public int Floors
        {
            get
            {
                return this.floors;
            }

            set
            {
                this.ValidationInRange(value, HouseMinFloors, HouseMaxFloors);
                this.floors = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}, Floors: {1}", base.ToString(), this.Floors);
        }
    }
}
