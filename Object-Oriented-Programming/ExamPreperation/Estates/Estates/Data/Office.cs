namespace Estates.Data
{
    using Interfaces;

    public class Office : BuildingEstate, IOffice
    {

        public Office()
        {
        }

        public Office(string name, EstateType type, double area, string location, bool isFurnished)
            : base(name, type, area, location, isFurnished)
        {
        }
    }
}