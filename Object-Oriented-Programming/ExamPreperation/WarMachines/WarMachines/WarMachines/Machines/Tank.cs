namespace WarMachines.Machines
{
    using System;
    using System.Linq;
    using WarMachines.Interfaces;

    public class Tank : Machine, IMachine, ITank
    {
        private const double TankInitialHealthPoints = 100d;
        private const double TankAddPointsToDefense = 30d;
        private const double TankRemovePointsFromAttack = 40d;

        private bool defenseMode;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints)
        {
            this.HealthPoints = TankInitialHealthPoints;

            this.DefenseMode = true;
            this.DefensePoints += TankAddPointsToDefense;
            this.AttackPoints -= TankRemovePointsFromAttack;
        }

        public bool DefenseMode
        {
            get { return this.defenseMode; }
            private set { this.defenseMode = value; }
        }

        public void ToggleDefenseMode()
        {
            if (!this.defenseMode)
            {
                this.defenseMode = true;
                this.DefensePoints += TankAddPointsToDefense;
                this.AttackPoints -= TankRemovePointsFromAttack;
            }
            else if (this.defenseMode)
            {
                this.defenseMode = false;
                this.DefensePoints -= TankAddPointsToDefense;
                this.AttackPoints += TankRemovePointsFromAttack;
            }
        }

        public override string ToString()
        {
            string result = base.ToString();
            result += string.Format("{0} *Defense: {1}", Environment.NewLine, this.DefenseMode ? "ON" : "OFF");

            return result;
        }
    }
}
