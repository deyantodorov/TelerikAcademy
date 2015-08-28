namespace T11.BankAccountData
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Globalization;

    /// <summary>
    /// 11. A bank account: 
    ///     has a holder name (first name, middle name and last name), 
    ///     available amount of money (balance), 
    ///     bank name, 
    ///     IBAN, 
    ///     3 credit card numbers associated with the account.
    /// 
    /// Declare the variables needed to keep the information for a single bank account using the appropriate data types and descriptive names.
    /// </summary>
    public class BankAccountData
    {
        private static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("bg-BG");

            Account account = new Account();
            account.HolderName = new Person("Ivan", "Petrov", "Goshov");
            account.Balance = 100.123m;
            account.BankName = "KTB";
            account.Iban = "123123123123123123";
            account.CreditCardNumbers.Add("123123asldfkj123123123");
            account.CreditCardNumbers.Add("456123asldfkj123123123");
            account.CreditCardNumbers.Add("789123asldfkj123123123");

            Console.WriteLine(account);
        }
    }
}