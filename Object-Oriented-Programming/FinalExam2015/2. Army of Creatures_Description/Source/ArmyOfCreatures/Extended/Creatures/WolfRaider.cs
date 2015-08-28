namespace ArmyOfCreatures.Extended.Creatures
{
    using ArmyOfCreatures.Extended.Specialties;
    using ArmyOfCreatures.Logic.Creatures;

    public class WolfRaider : Creature
    {
        private const decimal BaseDamage = 3.5m;
        private const int BaseHealthPoints = 10;
        private const int BaseDefense = 5;
        private const int BaseAttack = 8;
        private const int BaseDoubleDamage = 7;

        // with attack 8, defense 5, health points 10, damage 3.5
        public WolfRaider()
            : base(WolfRaider.BaseAttack, WolfRaider.BaseDefense, WolfRaider.BaseHealthPoints, WolfRaider.BaseDamage)
        {
            this.AddSpecialty(new DoubleDamage(WolfRaider.BaseDoubleDamage));
        }
    }
}
