namespace T09.ExchangeVariableValues
{
    using System;

    /// <summary>
    /// 9. Declare two integer variables a and b and assign them with 5 and 10 and after that exchange their values by using some programming logic. Print the variable values before and after the exchange.
    /// </summary>
    public class ExchangeVariableValues
    {
        public class ExchangeValues
        {
            private static void Main()
            {
                int a = 5;
                int b = 10;

                PrintValues(a, b);

                a = a ^ b;
                b = a ^ b;
                a = a ^ b;

                PrintValues(a, b);
            }

            private static void PrintValues(object a, object b)
            {
                Console.WriteLine("a = {0}", a);
                Console.WriteLine("b = {0}", b);
            }
        }
    }
}