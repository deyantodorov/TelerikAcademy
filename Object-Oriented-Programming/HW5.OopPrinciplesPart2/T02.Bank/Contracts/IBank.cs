namespace T02.Bank.Contracts
{
    using System.Collections.Generic;

    public interface IBank
    {
        string Name { get; set; }

        string Address { get; set; }

        IList<IAccount> Accounts { get; }

        void AddAccount(IAccount account);

        void RemoveAccount(IAccount account);
    }
}
