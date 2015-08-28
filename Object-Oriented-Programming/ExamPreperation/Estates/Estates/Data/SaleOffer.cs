namespace Estates.Data
{
    using Interfaces;

    public class SaleOffer : Offer, ISaleOffer
    {
        public SaleOffer(OfferType type)
            : base(type)
        {
        }

        public decimal Price { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, Price = {1}", base.ToString(), this.Price);
        }
    }
}
