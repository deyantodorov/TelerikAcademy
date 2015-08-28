namespace ArmyOfCreatures.Extended.Specialties
{
    using System;
    using System.Globalization;
    using ArmyOfCreatures.Logic.Battles;
    using ArmyOfCreatures.Logic.Specialties;

    public class AddAttackWhenSkip : Specialty
    {
        private int attackToAdd;

        public AddAttackWhenSkip(int attackToAdd)
        {
            this.AttackToAdd = attackToAdd;
        }

        public int AttackToAdd
        {
            get
            {
                return this.attackToAdd;
            }

            private set
            {
                if (value < 1 || value > 10)
                {
                    throw new ArgumentOutOfRangeException("attackToAdd", "attackToAdd should be between 1 and 10, inclusive");
                }

                this.attackToAdd = value;
            }
        }

        public override void ApplyOnSkip(ICreaturesInBattle skipCreature)
        {
            if (skipCreature == null)
            {
                throw new ArgumentNullException("skipCreature");
            }

            skipCreature.PermanentAttack += this.attackToAdd;
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}({1})", base.ToString(), this.attackToAdd);
        }
    }
}
