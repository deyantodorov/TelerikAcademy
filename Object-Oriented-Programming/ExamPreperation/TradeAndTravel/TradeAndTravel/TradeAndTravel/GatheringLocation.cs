namespace TradeAndTravel
{
    public abstract class GatheringLocation : Location, IGatheringLocation
    {
        protected GatheringLocation(string name, LocationType locType, ItemType gatheredType, ItemType requiredItem)
            : base(name, locType)
        {
            this.GatheredType = gatheredType;
            this.RequiredItem = requiredItem;
        }

        public ItemType GatheredType { get; private set; }

        public ItemType RequiredItem { get; private set; }

        public abstract Item ProduceItem(string name);
    }
}
