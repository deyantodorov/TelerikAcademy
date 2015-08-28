namespace ArmyOfCreatures.Extended.Creatures
{
    using ArmyOfCreatures.Logic.Creatures;

    public class Goblin : Creature
    {
        private const int BaseAttack = 4;
        private const int BaseDefense = 2;
        private const int BaseHealthPoints = 5;
        private const decimal BaseDamage = 1.5m;

        // attack 4, defence 2, health points 5 and damage 1.5 
        public Goblin()
            : base(Goblin.BaseAttack, Goblin.BaseDefense, Goblin.BaseHealthPoints, Goblin.BaseDamage)
        {
        }
    }
}
