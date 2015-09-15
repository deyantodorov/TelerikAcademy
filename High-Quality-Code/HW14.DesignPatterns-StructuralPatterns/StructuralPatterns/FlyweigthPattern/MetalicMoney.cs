using System;

namespace FlyweigthPattern
{
    public class MetalicMoney : IMoney
    {
        public MoneyType MoneyType => MoneyType.Metalic;

        public void GetDisplayOfMoneyFalling(int moneyValue)
        {
            Console.WriteLine($"Displaying a graphical object of{this.MoneyType} currency of value {moneyValue} falling from sky");
        }        
    }
}
