namespace ProxyPatternServer
{
    interface IActualPrices
    {
        string GoldPrice
        {
            get;
        }

        string SilverPrice
        {
            get;
        }

        string DollarToRupee
        {
            get;
        }
    }
}
