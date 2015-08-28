namespace Infestation
{
    public abstract class Catalist : Supplement
    {
        protected Catalist(int powerEffect, int healthEffect, int aggressionEffect)
            : base(powerEffect, healthEffect, aggressionEffect)
        {
        }
    }
}
