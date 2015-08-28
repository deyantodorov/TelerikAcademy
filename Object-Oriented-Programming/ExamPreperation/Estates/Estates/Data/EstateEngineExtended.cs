namespace Estates.Data
{
    using System.Linq;
    using Engine;
    using Interfaces;

    public class EstateEngineExtended : EstateEngine, IEstateEngine
    {
        public EstateEngineExtended()
            : base()
        {
        }

        public string ExecuteCommand(string cmdName, string[] cmdArgs)
        {

            switch (cmdName)
            {
                case "find-rents-by-location":
                    return this.ExecuteFindRentsByLocationCommand(cmdArgs[0]);
                case "find-rents-by-price":
                    return this.ExecuteFindRentsByPriceCommand(cmdArgs);
                default:
                    return base.ExecuteCommand(cmdName, cmdArgs);
            }
        }

        private string ExecuteFindRentsByPriceCommand(string[] cmdArgs)
        {
            decimal minPrice = decimal.Parse(cmdArgs[0]);
            decimal maxPrice = decimal.Parse(cmdArgs[1]);

            var offers = this.Offers
                .Where(x => x.Type == OfferType.Rent)
                .Select(x => x as IRentOffer)
                .Where(x => x.PricePerMonth >= minPrice && x.PricePerMonth <= maxPrice)
                .OrderBy(x => x.PricePerMonth)
                .ThenBy(x => x.Estate.Name);

            return this.FormatQueryResults(offers);
        }

        private string ExecuteFindRentsByLocationCommand(string location)
        {
            var offers = this.Offers
                .Where(o => o.Estate.Location == location && o.Type == OfferType.Rent)
                .OrderBy(o => o.Estate.Name);

            return this.FormatQueryResults(offers);
        }
    }
}
