namespace T02.Bank.Models.Bank
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using T02.Bank.Contracts;

    public class Bank
    {
        private readonly IList<IAccount> accounts;
        private string name;
        private string address;
        
        public Bank(string name, string address)
        {
            this.Name = name;
            this.Address = address;
            this.accounts = new List<IAccount>();
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

        public string Address
        {
            get
            {
                return this.address;
            }

            set
            {
                Validation.StringIsNullOrEmpty(value, "Address");
                this.address = value;
            }
        }

        public IList<IAccount> Accounts
        {
            get
            {
                return new List<IAccount>(this.accounts);
            }
        }

        public void AddAccount(IAccount account)
        {
            if (account != null)
            {
                this.accounts.Add(account);
            }
        }

        public void RemoveAccount(IAccount account)
        {
            if (account != null)
            {
                this.accounts.Remove(account);
            }
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, Address: {1}", this.Name, this.Address);
        }
    }
}
