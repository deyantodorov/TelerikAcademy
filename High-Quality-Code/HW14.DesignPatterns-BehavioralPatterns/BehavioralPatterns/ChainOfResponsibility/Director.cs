using System;

namespace ChainOfResponsibility
{
    public class Director : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 10000)
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