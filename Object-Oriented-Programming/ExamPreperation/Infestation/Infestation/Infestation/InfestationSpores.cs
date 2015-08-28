namespace Infestation
{
    public class InfestationSpores : Supplement
    {
        private const int InfestationSporesPowerEffect = -1;
        private const int InfestationSporesHealthEffect = 0;
        private const int InfestationSporesAggressionEffect = 20;

        public InfestationSpores()
            : base(InfestationSpores.InfestationSporesPowerEffect, InfestationSpores.InfestationSporesHealthEffect, InfestationSpores.InfestationSporesAggressionEffect)
        {
        }

        /* TODO: o	The InfestationSpores Supplement does not accumulate like the other Supplements –
         * even if two or more Infestations are added, the total AggressionEffect stays 20 (Edit: the same goes for PowerEffect)
         * o	The InfestationSpores Supplement cannot be added with the supplement command
        */

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is InfestationSpores)
            {
                this.PowerEffect = 0;
                this.HealthEffect = 0;
                this.AggressionEffect = 0;
            }
        }
    }
}
