namespace Infestation
{
    using System.Collections.Generic;
    using System.Linq;

    public class Parasite : Unit
    {
        private const int ParasitePower = 1;
        private const int ParasiteAggression = 1;
        private const int ParasiteHealth = 1;

        public Parasite(string id)
            : base(id, UnitClassification.Biological, Parasite.ParasiteHealth, Parasite.ParasitePower, Parasite.ParasiteAggression)
        {
        }

        public override Interaction DecideInteraction(IEnumerable<UnitInfo> units)
        {
            var attackableUnits = units.Where(this.CanAttackUnit);
            var optimalAttackableUnit = this.GetOptimalAttackableUnit(attackableUnits);

            if (optimalAttackableUnit.Id == null)
            {
                return Interaction.PassiveInteraction;
            }

            return new Interaction(new UnitInfo(this), optimalAttackableUnit, InteractionType.Infest);
        }

        protected override bool CanAttackUnit(UnitInfo unit)
        {
            return this.Id != unit.Id && (unit.UnitClassification == this.UnitClassification || unit.UnitClassification == UnitClassification.Mechanical);
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            var optimalAttackableUnit = new UnitInfo(null, UnitClassification.Unknown, int.MaxValue, 0, 0);

            foreach (var unit in attackableUnits)
            {
                if (unit.Health < optimalAttackableUnit.Health)
                {
                    optimalAttackableUnit = unit;
                }
            }

            return optimalAttackableUnit;
        }
    }
}
