using System;

namespace FlyweigthPattern
{
    public class Program
    {
        private const int Limit = 1000;
        private static readonly Random random = new Random();

        private static void Main()
        {
            var currencyDenominations = new[] { 1, 5, 10, 20, 50, 100 };
            var moneyFactory = new MoneyFactory();
            int sum = 0;

            while (sum <= Limit)
            {
                IMoney graphicalMoneyObject = null;
                int currencyDisplayValue = currencyDenominations[random.Next(0, currencyDenominations.Length)];

                if (currencyDisplayValue == 1 || currencyDisplayValue == 5)
                {
                    graphicalMoneyObject = moneyFactory.GetMoneyToDisplay((MoneyType.Metalic));
                }
                else
                {
                    graphicalMoneyObject = moneyFactory.GetMoneyToDisplay(MoneyType.Paper);
                }

                graphicalMoneyObject.GetDisplayOfMoneyFalling(currencyDisplayValue);

                sum += currencyDisplayValue;
            }

            Console.WriteLine($"Total objects created {moneyFactory.ObjectCount}");
            Console.WriteLine($"Total objects simulations {Limit}");
            Console.WriteLine($"Total sum {sum}");
        }
    }
}
