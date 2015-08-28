namespace WarMachines.Machines
{
    using System;
    using System.Linq;
    using WarMachines.Interfaces;

    public class Fighter : Machine, IMachine, IFighter
    {
        private const double FighterInitialHealthPoints = 200d;

        private bool stealthMode;

        public Fighter(string name, double attackPoints, double defensePoints, bool stealthMode)
            : base(name, attackPoints, defensePoints)
        {
            this.StealthMode = stealthMode;
            this.HealthPoints = FighterInitialHealthPoints;
        }

        public bool StealthMode
        {
            get { return this.stealthMode; }
            private set { this.stealthMode = value; }
        }

        public void ToggleStealthMode()
        {
            if (!this.stealthMode)
            {
                this.stealthMode = true;
            }
            else 
            {
                this.stealthMode = false;
            }
        }

        public override string ToString()
        {
            string result = base.ToString();
            result += string.Format("{0} *Stealth: {1}", Environment.NewLine, this.StealthMode ? "ON" : "OFF");

            return result;
        }
    }
}
