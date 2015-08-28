namespace Estates.Data
{
    using Interfaces;

    public abstract class BuildingEstate : Estate, IBuildingEstate
    {
        private const int MinRooms = 0;
        private const int MaxRooms = 20;

        private int rooms;

        protected BuildingEstate()
        {
        }

        protected BuildingEstate(string name, EstateType type, double area, string location, bool isFurnished)
            : base(name, type, area, location, isFurnished)
        {
        }

        /// <summary>
        /// Office / apartment rooms should be in range [0…20].
        /// </summary>
        public int Rooms
        {
            get
            {
                return this.rooms;
            }

            set
            {
                this.ValidationInRange(value, MinRooms, MaxRooms);
                this.rooms = value;
            }
        }

        public bool HasElevator { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, Rooms: {1}, Elevator: {2}", base.ToString(), this.Rooms, this.HasElevator ? "Yes" : "No");
        }
    }
}
