namespace T02.Bank.Models.Customers
{
    using System;
    using System.Linq;
    using Common;
    using T02.Bank.Contracts;

    public class Company : Customer, ICustomer
    {
        private string vat;

        public Company(int id, string name, string address, string phone, string country, string city, string vat)
            : base(id, name, address, phone, country, city)
        {
            this.Vat = vat;
        }

        public string Vat
        {
            get
            {
                return this.vat;
            }

            set
            {
                Validation.StringIsNullOrEmpty(value, "Vat");
                Validation.IsInRange(value.ToString().Length, "Vat", 9, 9);
                this.vat = value;
            }
        }
    }
}
