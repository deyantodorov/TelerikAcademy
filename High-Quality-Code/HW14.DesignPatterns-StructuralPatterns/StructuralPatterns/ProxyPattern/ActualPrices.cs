namespace ProxyPattern
{
    public class ActualPrices : IActualPrice
    {
        // set some hardcode values
        public string GoldPrice => "123";
        public string SilverPrice => "321";
        public string DollarToRupee => "12";
    }
}
