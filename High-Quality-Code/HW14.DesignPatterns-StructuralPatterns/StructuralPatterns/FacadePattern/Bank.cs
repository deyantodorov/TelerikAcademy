using System;

namespace FacadePattern
{
    public class Bank
    {
        public bool HasSufficientSavings(Customer customer, int amout)
        {
            Console.WriteLine("Check bank for " + customer.Name);
            return true;
        }
    }
}
