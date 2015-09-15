namespace FlyweigthPattern
{
    public interface IMoney
    {
        MoneyType MoneyType { get; }

        void GetDisplayOfMoneyFalling(int moneyValue);
    }
}
