namespace T02.Bank.Contracts
{
    using System;

    public interface IAccount
    {
        int Id { get; }

        ICustomer Customer { get; }

        DateTime CreatedOn { get; }

        decimal Balance { get; set; }

        decimal InterestRate { get; set; }

        decimal CalculateInterest();

        void Deposit(decimal depositMoney);

        void Draw(decimal drawMoney);
    }
}
