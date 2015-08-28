namespace T02.Bank.Models.Accounts
{
    using System;
    using System.Linq;
    using T02.Bank.Contracts;
    using T02.Bank.Models.Customers;

    public class Loan : Account, IAccount
    {
        public Loan(int id, ICustomer customer, DateTime creatDate)
            : base(id, customer, creatDate)
        {
        }

        public override void Draw(decimal drawMoney)
        {
            // TODO: Stupid, but I'm sure there is design patter for this
        }

        public override decimal CalculateInterest()
        {
            if (this.Customer.GetType() == typeof(Company))
            {
                return this.CalcInterestNoPromo(2);
            }

            if (this.Customer.GetType() == typeof(Individual))
            {
                return this.CalcInterestNoPromo(3);
            }

            return 0;
        }
    }
}
