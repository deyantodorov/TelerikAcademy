namespace ArmyOfCreatures.Extended.Creatures
{
    using ArmyOfCreatures.Logic.Creatures;
    using ArmyOfCreatures.Logic.Specialties;

    public class Griffin : Creature
    {
        private const int BaseDefenseToAdd = 3;
        private const int BaseDoubleDefenseWhenDefending = 5;
        private const int BaseAttack = 8;
        private const int BaseDefense = 8;
        private const int BaseHealthPoints = 25;
        private const decimal BaseDamage = 4.5m;

        // attack 8, defense 8, damage 4.5 and health points 25
        public Griffin()
            : base(Griffin.BaseAttack, Griffin.BaseDefense, Griffin.BaseHealthPoints, Griffin.BaseDamage)
        {
            this.AddSpecialty(new DoubleDefenseWhenDefending(Griffin.BaseDoubleDefenseWhenDefending));
            this.AddSpecialty(new AddDefenseWhenSkip(Griffin.BaseDefenseToAdd));
            this.AddSpecialty(new Hate(typeof(WolfRaider)));
        }
    }
}
