namespace T02.Bank
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using T02.Bank.Contracts;
    using T02.Bank.Models.Accounts;
    using T02.Bank.Models.Bank;
    using T02.Bank.Models.Customers;

    /// <summary>
    /// https://github.com/TelerikAcademy/Object-Oriented-Programming/blob/master/05.%20OOP%20Principles%20-%20Part%202/README.md#problem-2-bank-accounts
    /// </summary>
    public class MainProgram
    {
        private static void Main()
        {
            List<ICustomer> customers = new List<ICustomer>();
            customers.Add(new Individual(1, "Ivan Ivanov", "Address", "123123123", "Bulgaria", "Sofia", "1231231231"));
            customers.Add(new Company(2, "Ivan Ivanov Company", "Address Company", "123123123", "Bulgaria", "Sofia", "123123123"));

            Console.WriteLine("Customers:");
            customers.ForEach(x => Console.WriteLine(x));

            List<IAccount> accounts = new List<IAccount>();

            // Individuals
            accounts.Add(new Loan(1, customers[0], DateTime.Now.AddDays(GenerateRandom.Number(1, 365) * -1)));
            accounts.Add(new Mortgage(2, customers[0], DateTime.Now.AddDays(GenerateRandom.Number(1, 365) * -1)));
            accounts.Add(new Deposit(3, customers[0], DateTime.Now.AddDays(GenerateRandom.Number(1, 365) * -1)));

            //// Company
            accounts.Add(new Loan(4, customers[1], DateTime.Now.AddDays(GenerateRandom.Number(1, 365) * -1)));
            accounts.Add(new Mortgage(5, customers[1], DateTime.Now.AddDays(GenerateRandom.Number(1, 365) * -1)));
            accounts.Add(new Deposit(6, customers[1], DateTime.Now.AddDays(GenerateRandom.Number(1, 365) * -1)));

            Console.WriteLine("\nInitial accounts");
            accounts.ForEach(x => Console.WriteLine(x));

            // Set some random money and interest rate
            SeedMoney(accounts);

            // Bank
            Bank bank = new Bank("Big Bank", "Bank address");
            AddAccountsToBank(bank, accounts);

            // Calculate interest rate
            foreach (var account in bank.Accounts)
            {
                Console.WriteLine("Balance: {0}, Interrest Rate: {1}, Calculate Interest: {2}", account.Balance, account.InterestRate, account.CalculateInterest());
            }

            // Deposit
            foreach (var account in bank.Accounts)
            {
                account.Deposit(GenerateRandom.Number(100, 1000));
            }

            ShowBank(bank);

            Console.WriteLine("\nDraw:");
            foreach (var account in bank.Accounts)
            {
                account.Draw(GenerateRandom.Number(100, 1000));
            }

            ShowBank(bank);
        }
 
        private static void ShowBank(Bank bank)
        {
            Console.WriteLine("\nBank:");
            foreach (var account in bank.Accounts)
            {
                Console.WriteLine(account);
            }
        }

        private static void AddAccountsToBank(Bank bank, List<IAccount> accounts)
        {
            foreach (var account in accounts)
            {
                bank.AddAccount(account);
            }
        }

        private static void SeedMoney(List<IAccount> accounts)
        {
            for (int i = 0; i < accounts.Count; i++)
            {
                accounts[i].Balance = GenerateRandom.Number(1000, 2000);
                accounts[i].InterestRate = GenerateRandom.Number(1, 10);
            }
        }
    }
}