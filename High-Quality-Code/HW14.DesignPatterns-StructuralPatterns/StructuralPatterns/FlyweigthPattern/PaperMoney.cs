using System;

namespace FlyweigthPattern
{
    public class PaperMoney : IMoney
    {
        public MoneyType MoneyType => MoneyType.Paper;

        public void GetDisplayOfMoneyFalling(int moneyValue)
        {
            Console.WriteLine($"Displaying a graphical object of{this.MoneyType} currency of value {moneyValue} falling from sky");
        }
    }
}
