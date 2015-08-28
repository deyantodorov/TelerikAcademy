namespace Infestation
{
    using System.Collections.Generic;
    using System.Linq;

    public class Marine : Human
    {
        public Marine(string id)
            : base(id)
        {
            // TODO: It's potential problem to call virtual method in constructor. Can't figure out how to deal with this one.
            this.AddSupplement(new WeaponrySkill());
        }

        public override Interaction DecideInteraction(IEnumerable<UnitInfo> units)
        {
            var attackableUnits = units.Where(this.CanAttackUnit);
            var optimalAttackableUnit = this.GetOptimalAttackableUnit(attackableUnits);
            return optimalAttackableUnit.Id == null ? Interaction.PassiveInteraction : new Interaction(new UnitInfo(this), optimalAttackableUnit, InteractionType.Attack);
        }

        protected override bool CanAttackUnit(UnitInfo unit)
        {
            return this.Id != unit.Id;
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            var targetUnit = attackableUnits.Where(x => x.Power <= this.Aggression).ToList();
            var singleTarget = targetUnit.OrderByDescending(x => x.Health).FirstOrDefault();
            return singleTarget;
        }
    }
}