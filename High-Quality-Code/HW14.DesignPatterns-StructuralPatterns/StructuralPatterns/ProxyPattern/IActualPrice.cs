namespace ProxyPattern
{
    public interface IActualPrice
    {
        string GoldPrice { get; }

        string SilverPrice { get; }

        string DollarToRupee { get; }
    }
}
