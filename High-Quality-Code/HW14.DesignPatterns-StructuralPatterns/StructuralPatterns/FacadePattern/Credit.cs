﻿using System;

namespace FacadePattern
{
    public class Credit
    {
        public bool HasGoodCredit(Customer customer)
        {
            Console.WriteLine("Check credit for " + customer.Name);
            return true;
        }
    }
}
