namespace Infestation
{
    public class AggressionCatalyst : Catalist
    {
        private const int AggressionCatalystPower = 0;
        private const int AggressionCatalystHealth = 0;
        private const int AggressionCatalystAggression = 3;

        public AggressionCatalyst()
            : base(AggressionCatalyst.AggressionCatalystPower, AggressionCatalyst.AggressionCatalystHealth, AggressionCatalyst.AggressionCatalystAggression)
        {
        }
    }
}