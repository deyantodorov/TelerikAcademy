namespace TradeAndTravel
{
    using System;

    public class Wood : Item
    {
        private const int GeneralWoodValue = 2;

        public Wood(string name, Location location = null)
            : base(name, GeneralWoodValue, ItemType.Wood, location)
        {
        }

        public override void UpdateWithInteraction(string interaction)
        {
            if (interaction == null)
            {
                throw new ArgumentNullException("interaction");
            }

            if (interaction.Equals("drop") && this.Value > 0)
            {
                this.Value--;
            }

            base.UpdateWithInteraction(interaction);
        }
    }
}