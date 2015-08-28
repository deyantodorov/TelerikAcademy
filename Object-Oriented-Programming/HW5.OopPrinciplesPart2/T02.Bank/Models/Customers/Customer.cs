namespace T02.Bank.Models.Customers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using T02.Bank.Contracts;

    public abstract class Customer : ICustomer
    {
        private int id;
        private string name;
        private string address;
        private string phone;
        private string country;
        private string city;

        public Customer(int id, string name, string address, string phone, string country, string city)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
            this.Phone = phone;
            this.Country = country;
            this.City = city;
        }

        public int Id
        {
            get
            {
                return this.id;
            }

            private set
            {
                Validation.LessThanZero<int>(value, 0, "Id");
                this.id = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            protected set
            {
                Validation.StringIsNullOrEmpty(value, "Value");
                this.name = value;
            }
        }

        public string Address
        {
            get
            {
                return this.address;
            }

            protected set
            {
                Validation.StringIsNullOrEmpty(value, "Address");
                this.address = value;
            }
        }

        public string Country
        {
            get
            {
                return this.country;
            }

            set
            {
                Validation.StringIsNullOrEmpty(value, "Country");
                this.country = value;
            }
        }

        public string City
        {
            get
            {
                return this.city;
            }

            set
            {
                Validation.StringIsNullOrEmpty(value, "City");
                this.city = value;
            }
        }

        public string Phone
        {
            get
            {
                return this.phone;
            }

            protected set
            {
                Validation.StringIsNullOrEmpty(value, "Phone");
                this.phone = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Id: {0}, Name: {1}, Address: {2}, Phone: {3}, Country: {4}, City: {5}", this.Id, this.Name, this.Address, this.Phone, this.Country, this.City);
        }

        private void ValidateInputAccount(IAccount account)
        {
            if (account == null)
            {
                throw new ArgumentNullException("Account can't be null");
            }
        }
    }
}
