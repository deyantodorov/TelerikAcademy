namespace T02.Bank.Models.Accounts
{
    using System;
    using System.Linq;
    using System.Text;
    using Common;
    using T02.Bank.Contracts;

    public abstract class Account : IAccount
    {
        private const int MonthsPerYear = 12;
        private int id;
        private ICustomer customer;
        private decimal balance;
        private decimal interestRate;

        public Account(int id, ICustomer customer, DateTime creatDate)
        {
            this.Id = id;
            this.Customer = customer;
            this.CreatedOn = creatDate;
        }

        public Account(int id, ICustomer customer, decimal balance, decimal interestRate, DateTime creatDate)
            : this(id, customer, creatDate)
        {
            this.Balance = balance;
            this.InterestRate = interestRate;
            this.CreatedOn = DateTime.Now;
        }

        public int Id
        {
            get
            {
                return this.id;
            }

            protected set
            {
                Validation.LessThanZero<int>(value, 0, "Id");
                this.id = value;
            }
        }

        public ICustomer Customer
        {
            get
            {
                return this.customer;
            }

            protected set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Customer can't be null");
                }

                this.customer = value;
            }
        }

        public DateTime CreatedOn { get; protected set; }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }

            set
            {
                Validation.LessThanZero<decimal>(value, 0, "Balance");
                this.balance = value;
            }
        }

        public decimal InterestRate
        {
            get
            {
                return this.interestRate;
            }

            set
            {
                Validation.LessThanZero<decimal>(value, 0, "Interest Rate");
                this.interestRate = value;
            }
        }

        public void Deposit(decimal depositMoney)
        {
            this.Balance += depositMoney;
        }

        public virtual void Draw(decimal drawMoney)
        {
            if (drawMoney > this.Balance)
            {
                throw new ArgumentException("Nor enogh money");
            }

            this.Balance -= drawMoney;
        }

        public abstract decimal CalculateInterest();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Id: {0}, ", this.Id);
            sb.AppendFormat("Type: {0}, ", this.GetType().Name);

            if (this.Balance != 0)
            {
                sb.AppendFormat("Balance: {0}, ", this.Balance);
            }

            if (this.InterestRate != 0)
            {
                sb.AppendFormat("Interest Rate: {0}, ", this.InterestRate);
            }

            return sb.ToString();
        }

        protected decimal CalcInterestWithPromoRate(int companyPromoMonths, int companyPromoRate)
        {
            int numberOfMonths = this.AccountPeriod();

            if (numberOfMonths > companyPromoMonths)
            {
                numberOfMonths -= companyPromoMonths;
                decimal currentRate = this.CalculateCurrentRate(numberOfMonths);
                currentRate += this.CalculateCurrentRateWithPromo(numberOfMonths, companyPromoRate);
                return currentRate;
            }
            else
            {
                decimal currentBalance = this.CalculateCurrentRateWithPromo(numberOfMonths, companyPromoRate);
                return currentBalance;
            }
        }

        protected decimal CalcInterestNoPromo(int individualPromoMonths)
        {
            int numberOfMonths = this.AccountPeriod();

            if (numberOfMonths <= individualPromoMonths)
            {
                return 0;
            }
            else
            {
                decimal currentRate = this.CalculateCurrentRate(numberOfMonths - individualPromoMonths);
                return currentRate;
            }
        }

        protected int AccountPeriod()
        {
            return ((DateTime.Today.Year - this.CreatedOn.Year) * MonthsPerYear) + (DateTime.Today.Month - this.CreatedOn.Month);
        }

        protected decimal CalculateCurrentRate(int numberOfMonths)
        {
            return numberOfMonths * ((this.Balance * this.InterestRate) / 100);
        }

        protected decimal CalculateCurrentRateWithPromo(int numberOfMonths, int promo)
        {
            return numberOfMonths * ((this.Balance * this.InterestRate / promo) / 100);
        }
    }
}
