using System;

namespace FacadePattern
{
    public class Mortgage
    {
        private readonly Bank bank = new Bank();
        private readonly Loan loan = new Loan();
        private readonly Credit credit = new Credit();

        public bool IsEligible(Customer customer, int requestAmount)
        {
            Console.WriteLine("{0} applies for {1:C} loan \n", customer.Name, requestAmount);

            bool eligible = true;

            if (!this.bank.HasSufficientSavings(customer, requestAmount))
            {
                eligible = false;
            }
            else if (!this.loan.HasNoBadLoans(customer))
            {
                eligible = false;
            }
            else if (!this.credit.HasGoodCredit(customer))
            {
                eligible = false;
            }

            return eligible;
        }
    }
}