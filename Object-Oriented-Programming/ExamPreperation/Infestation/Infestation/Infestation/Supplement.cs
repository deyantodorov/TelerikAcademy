﻿namespace Infestation
{
    using System;

    public abstract class Supplement : ISupplement
    {
        protected Supplement(int powerEffect, int healthEffect, int aggressionEffect)
        {
            this.PowerEffect = powerEffect;
            this.HealthEffect = healthEffect;
            this.AggressionEffect = aggressionEffect;
        }

        public int PowerEffect { get; set; }

        public int HealthEffect { get; set; }

        public int AggressionEffect { get; set; }

        public virtual void ReactTo(ISupplement otherSupplement)
        {
        }
    }
}
