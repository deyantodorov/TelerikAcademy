namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Interfaces;

    public abstract class Machine : IMachine
    {
        private string name;
        private IPilot pilot;
        private double healthPoints;
        private double attackPoints;
        private double defensePoints;
        private IList<string> targets;

        protected Machine(string name, double attackPoints, double defensePoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.targets = new List<string>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                Validation.StringIsNullOrEmpty(value, "Name");
                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }
            set
            {
                Validation.IsNull(value, "Pilot");
                this.pilot = value;
            }
        }

        public double HealthPoints
        {
            get
            {
                return this.healthPoints;
            }

            set
            {
                Validation.LessThan(value, 0d, "HealthPoints");
                this.healthPoints = value;
            }
        }

        public double AttackPoints
        {
            get
            {
                return this.attackPoints;
            }

            protected set
            {
                Validation.LessThan(value, 0d, "AttackPoints");
                this.attackPoints = value;
            }
        }

        public double DefensePoints
        {
            get
            {
                return this.defensePoints;
            }

            protected set
            {
                Validation.LessThan(value, 0d, "DefensePoints");
                this.defensePoints = value;
            }
        }

        public IList<string> Targets
        {
            get
            {
                return this.targets;
            }

            private set
            {
                Validation.IsNull<string>(value, "Targets");
                this.targets = value;
            }
        }

        public void Attack(string target)
        {
            this.Targets.Add(target);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("- {0}", this.Name));
            sb.AppendLine(string.Format(" *Type: {0}", this.GetType().Name));
            sb.AppendLine(string.Format(" *Health: {0}", this.HealthPoints));
            sb.AppendLine(string.Format(" *Attack: {0}", this.AttackPoints));
            sb.AppendLine(string.Format(" *Defense: {0}", this.DefensePoints));
            sb.Append(string.Format(" *Targets: {0}", this.GetTargets()));

            return sb.ToString();
        }

        private string GetTargets()
        {
            return this.targets.Count != 0 ? string.Join(", ", this.targets) : "None";
        }
    }
}
