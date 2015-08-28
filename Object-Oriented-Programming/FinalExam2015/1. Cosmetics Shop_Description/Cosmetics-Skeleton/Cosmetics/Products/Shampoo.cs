namespace Cosmetics.Products
{
    using System.Text;

    using Cosmetics.Common;
    using Cosmetics.Contracts;

    public class Shampoo : Product, IShampoo
    {
        private const string MillilitersPrintFormat = "  * Quantity: {0} ml";
        private const string UsagePrintFormat = "  * Usage: {0}";

        public Shampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage)
            : base(name, brand, price, gender)
        {
            this.Milliliters = milliliters;
            this.Usage = usage;

            // TODO: Refactor price calculation ???
            this.Price = price * this.Milliliters; 
        }

        public uint Milliliters { get; private set; }

        public UsageType Usage { get; private set; }

        public override string ToString()
        {
            string print = base.ToString() + this.PrintShampoo();
            return print.Trim();
        }

        // TODO: May be base.Print() ???
        private string PrintShampoo()
        {
            var sb = new StringBuilder();

            sb.AppendLine(string.Format(Shampoo.MillilitersPrintFormat, this.Milliliters));
            sb.AppendLine(string.Format(Shampoo.UsagePrintFormat, this.Usage));

            return sb.ToString();
        }
    }
}
