namespace Infestation
{
    public class PowerCatalyst : Catalist
    {
        private const int PowerCatalystPower = 3;
        private const int PowerCatalystHealth = 0;
        private const int PowerCatalystAggression = 0;

        public PowerCatalyst()
            : base(PowerCatalyst.PowerCatalystPower, PowerCatalyst.PowerCatalystHealth, PowerCatalyst.PowerCatalystAggression)
        {
        }
    }
}
