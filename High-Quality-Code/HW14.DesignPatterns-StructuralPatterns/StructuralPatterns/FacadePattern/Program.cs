using System;

namespace FacadePattern
{
    /// <summary>
    /// Facade pattern example:
    /// 
    /// Participants:
    /// MorgageApplication - knows which subsystem of classes are responsible for a request
    /// 
    /// Subsystem classes:
    /// Bank
    /// Credit
    /// Loan
    /// 
    /// implement subsystem functionality
    /// handle work assigned by the Fascade object
    /// have no knowledge of the facade and keep no reference to it
    /// </summary>
    public class Program
    {
        private static void Main()
        {
            var morgage = new Mortgage();
            var customer = new Customer("Ivan Peshov Geshov");

            bool eligible = morgage.IsEligible(customer, 125000);
            Console.WriteLine("{0} has been {1}", customer.Name, (eligible ? "Approved" : "Rejected"));
        }
    }
}
