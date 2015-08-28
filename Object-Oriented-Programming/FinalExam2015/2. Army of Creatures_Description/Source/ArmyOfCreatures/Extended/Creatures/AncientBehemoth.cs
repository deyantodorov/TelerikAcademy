namespace ArmyOfCreatures.Extended.Creatures
{
    using ArmyOfCreatures.Logic.Creatures;
    using ArmyOfCreatures.Logic.Specialties;

    public class AncientBehemoth : Creature
    {
        private const int BaseDefense = 19;
        private const int BaseAttack = 19;
        private const int BaseHealthPoints = 300;
        private const int BaseDamage = 40;
        private const int BaseReduceEnemyDefenseByPercentage = 80;
        private const int BaseDoubleDefenseWhenDefending = 5;

        // with attack 19, defense 19, damage 40, health points 300 and has the following specialties
        public AncientBehemoth()
            : base(AncientBehemoth.BaseAttack, AncientBehemoth.BaseDefense, AncientBehemoth.BaseHealthPoints, AncientBehemoth.BaseDamage)
        {
            this.AddSpecialty(new ReduceEnemyDefenseByPercentage(AncientBehemoth.BaseReduceEnemyDefenseByPercentage));
            this.AddSpecialty(new DoubleDefenseWhenDefending(AncientBehemoth.BaseDoubleDefenseWhenDefending));
        }
    }
}
