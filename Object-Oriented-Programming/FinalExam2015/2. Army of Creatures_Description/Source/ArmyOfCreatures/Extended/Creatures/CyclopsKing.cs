namespace ArmyOfCreatures.Extended.Creatures
{
    using ArmyOfCreatures.Extended.Specialties;
    using ArmyOfCreatures.Logic.Creatures;

    public class CyclopsKing : Creature
    {
        private const int BaseDamage = 18;
        private const int BaseHealthPoints = 70;
        private const int BaseDefense = 13;
        private const int BaseAttack = 17;
        private const int BaseAddAttackWhenSkip = 3;
        private const int BaseDoubleAttackWhenAttackingRounds = 4;
        private const int BaseDoubleDamageRounds = 1;

        // attack 17, defense 13, damage 18, health points 70 
        public CyclopsKing()
            : base(BaseAttack, BaseDefense, BaseHealthPoints, BaseDamage)
        {
            this.AddSpecialty(new AddAttackWhenSkip(CyclopsKing.BaseAddAttackWhenSkip));
            this.AddSpecialty(new DoubleAttackWhenAttacking(CyclopsKing.BaseDoubleAttackWhenAttackingRounds));
            this.AddSpecialty(new DoubleDamage(CyclopsKing.BaseDoubleDamageRounds));
        }
    }
}