namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WarMachines.Interfaces;

    public class Pilot : IPilot
    {
        private readonly IList<IMachine> machine;
        private string name;

        public Pilot(string name)
        {
            this.Name = name;
            this.machine = new List<IMachine>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validation.StringIsNullOrEmpty(value, "Name");
                this.name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            Validation.IsNull(machine, "AddMachine");
            this.machine.Add(machine);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("{0} - {1}", this.Name, GetNumberOfMachines()));
            var sortByHealthAndName = this.machine.OrderBy(x => x.HealthPoints).ThenBy(x => x.Name);

            foreach (var machine in sortByHealthAndName)
            {
                sb.AppendLine(machine.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public override string ToString()
        {
            return this.Report().Trim();
        }

        private string GetNumberOfMachines()
        {
            StringBuilder sb = new StringBuilder();

            if (this.machine.Count == 0)
            {
                sb.Append("no machines");
            }
            else if (this.machine.Count == 1)
            {
                sb.Append("1 machine");
            }
            else if (this.machine.Count > 1)
            {
                sb.AppendFormat("{0} machines", this.machine.Count);
            }

            return sb.ToString();
        }
    }
}
