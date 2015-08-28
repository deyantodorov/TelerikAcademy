namespace Estates.Data
{
    using Interfaces;

    public class RentOffer : Offer, IRentOffer
    {
        public RentOffer(OfferType type)
            : base(type)
        {
        }

        public decimal PricePerMonth { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, Price = {1}", base.ToString(), this.PricePerMonth);
        }
    }
}