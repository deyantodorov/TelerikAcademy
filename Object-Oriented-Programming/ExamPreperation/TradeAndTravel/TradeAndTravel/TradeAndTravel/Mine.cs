namespace TradeAndTravel
{
    using System;

    public class Mine : GatheringLocation
    {
        public Mine(string name)
            : base(name, LocationType.Mine, ItemType.Iron, ItemType.Armor)
        {
        }

        public override Item ProduceItem(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(name, "Can't be null or empty");
            }

            return new Iron(name);
        }
    }
}