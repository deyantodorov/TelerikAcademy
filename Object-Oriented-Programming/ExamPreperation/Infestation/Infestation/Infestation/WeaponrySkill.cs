namespace Infestation
{
    public class WeaponrySkill : Supplement
    {
        private const int WeaponrySkillPowerEffect = 0;
        private const int WeaponrySkillHealthEffect = 0;
        private const int WeaponrySkillAggressionEffect = 0;

        public WeaponrySkill()
            : base(WeaponrySkill.WeaponrySkillPowerEffect, WeaponrySkill.WeaponrySkillHealthEffect, WeaponrySkill.WeaponrySkillAggressionEffect)
        {
        }
    }
}