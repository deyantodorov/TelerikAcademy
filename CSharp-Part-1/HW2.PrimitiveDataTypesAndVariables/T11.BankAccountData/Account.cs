namespace T11.BankAccountData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Account
    {
        public Account()
        {
            this.CreditCardNumbers = new List<string>();
        }

        public Person HolderName { get; set; }

        public decimal Balance { get; set; }

        public string BankName { get; set; }

        public string Iban { get; set; }

        public IList<string> CreditCardNumbers { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("Holder name: {0}", this.HolderName));
            sb.AppendLine(string.Format("Balance: {0:C}", this.Balance));
            sb.AppendLine(string.Format("Bank name: {0}", this.BankName));
            sb.AppendLine(string.Format("IBAN: {0}", this.Iban));

            for (int i = 0; i < this.CreditCardNumbers.Count(); i++)
            {
                sb.AppendLine(string.Format("Credit card number: {0}", this.CreditCardNumbers[i]));    
            }

            return sb.ToString();
        }
    }
}
