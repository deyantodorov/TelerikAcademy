namespace T02.Bank.Models.Accounts
{
    using System;
    using System.Linq;
    using T02.Bank.Contracts;

    public class Deposit : Account, IAccount
    {
        private const decimal MinBalance = 1000m;

        public Deposit(int id, ICustomer customer, DateTime creatDate)
            : base(id, customer, creatDate)
        {
        }

        public override decimal CalculateInterest()
        {
            if (this.Balance < MinBalance)
            {
                return 0;
            }
            else
            {
                int numberOfMonths = AccountPeriod();
                decimal currentRate = CalculateCurrentRate(numberOfMonths);
                return currentRate;
            }
        }
    }
}