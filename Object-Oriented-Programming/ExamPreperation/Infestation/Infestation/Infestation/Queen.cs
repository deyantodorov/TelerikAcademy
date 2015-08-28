namespace Infestation
{
    using System.Collections.Generic;
    using System.Linq;

    public class Queen : Unit
    {
        private const int QueenPower = 1;
        private const int QueenAggression = 1;
        private const int QueenHealth = 30;

        public Queen(string id)
            : base(id, UnitClassification.Psionic, Queen.QueenHealth, Queen.QueenPower, Queen.QueenAggression)
        {
        }

        public override Interaction DecideInteraction(IEnumerable<UnitInfo> units)
        {
            var attackableUnits = units.Where(this.CanAttackUnit);
            var optimalAttackableUnit = this.GetOptimalAttackableUnit(attackableUnits);
            return optimalAttackableUnit.Id == null ? Interaction.PassiveInteraction : new Interaction(new UnitInfo(this), optimalAttackableUnit, InteractionType.Infest);
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