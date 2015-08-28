namespace Estates.Data
{
    using Interfaces;

    public class Apartment : BuildingEstate, IApartment
    {
        public Apartment()
        {
        }

        public Apartment(string name, EstateType type, double area, string location, bool isFurnished)
            : base(name, type, area, location, isFurnished)
        {
        }
    }
}