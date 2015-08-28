namespace ArmyOfCreatures.Extended.Specialties
{
    using System;
    using System.Globalization;
    using ArmyOfCreatures.Logic.Battles;
    using ArmyOfCreatures.Logic.Specialties;

    public class DoubleAttackWhenAttacking : Specialty
    {
        private int rounds;

        public DoubleAttackWhenAttacking(int rounds)
        {
            this.Rounds = rounds;
        }

        public int Rounds
        {
            get
            {
                return this.rounds; 
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("rounds", "rounds should should be greater than 0");
                }

                this.rounds = value;
            }
        }

        public override void ApplyWhenAttacking(ICreaturesInBattle attackerWithSpecialty, ICreaturesInBattle defender)
        {
            if (attackerWithSpecialty == null)
            {
                throw new ArgumentNullException("attackerWithSpecialty");
            }

            if (defender == null)
            {
                throw new ArgumentNullException("defender");
            }

            if (this.rounds <= 0)
            {
                // Effect expires after fixed number of rounds
                return;
            }

            attackerWithSpecialty.CurrentAttack *= 2;
            this.Rounds--;
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}({1})", base.ToString(), this.Rounds);
        }
    }
}
