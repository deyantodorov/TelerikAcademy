namespace T02.Bank.Models.Customers
{
    using System;
    using System.Linq;
    using Common;
    using T02.Bank.Contracts;

    public class Individual : Customer, ICustomer
    {
        private string ucn;

        public Individual(int id, string name, string address, string phone, string country, string city, string ucn)
            : base(id, name, address, phone, country, city)
        {
            this.Ucn = ucn;
        }

        public string Ucn
        {
            get
            {
                return this.ucn;
            }

            set
            {
                Validation.StringIsNullOrEmpty(value, "Ucn");
                Validation.IsInRange(value.ToString().Length, "Ucn", 10, 10);
                this.ucn = value;
            }
        }
    }
}
