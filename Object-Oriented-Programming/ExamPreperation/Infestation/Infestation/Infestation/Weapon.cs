namespace Infestation
{
    public class Weapon : Supplement
    {
        private const int WeaponPowerEffect = 10;
        private const int WeaponHealthEffect = 0;
        private const int WeaponAggressionEffect = 3;

        public Weapon()
            : base(Weapon.WeaponPowerEffect, Weapon.WeaponHealthEffect, Weapon.WeaponAggressionEffect)
        {
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is WeaponrySkill)
            {
                this.PowerEffect = Weapon.WeaponPowerEffect;
                this.HealthEffect = Weapon.WeaponHealthEffect;
                this.AggressionEffect = Weapon.WeaponAggressionEffect;
            }
            else
            {
                // Weapon.ReactTo(WeaponrySkill);
                this.PowerEffect = 0;
                this.HealthEffect = 0;
                this.AggressionEffect = 0;
            }
        }
    }
}
