namespace TradeAndTravel
{
    using System;

    public class Forest : GatheringLocation
    {
        public Forest(string name)
            : base(name, LocationType.Forest, ItemType.Wood, ItemType.Weapon)
        {
        }

        public override Item ProduceItem(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(name, "Can't be null or empty");
            }

            return new Wood(name);
        }
    }
}
