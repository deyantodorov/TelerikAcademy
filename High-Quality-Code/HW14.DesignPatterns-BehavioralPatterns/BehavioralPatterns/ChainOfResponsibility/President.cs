using System;

namespace ChainOfResponsibility
{
    public class President : Director
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 100000)
            {
                Console.WriteLine($"{this.GetType().Name} approved request {purchase.Number}");
            }
            else if (this.Successor != null)
            {
                this.Successor.ProcessRequest(purchase);
            }
        }
    }
}