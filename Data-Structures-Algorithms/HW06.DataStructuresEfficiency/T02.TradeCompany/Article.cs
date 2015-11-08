using System;

namespace T02.TradeCompany
{
    public class Article : IComparable
    {
        public string Barcode { get; set; }

        public string Vendor { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", this.Barcode, this.Vendor, this.Title, this.Price);
        }

        public int CompareTo(object obj)
        {
            var other = obj as Article;

            if (other == null)
            {
                throw new ArgumentNullException("obj", "Can't be null");
            }

            if (string.Compare(this.Barcode, other.Barcode, StringComparison.Ordinal) == 0 &&
                string.Compare(this.Vendor, other.Vendor, StringComparison.Ordinal) == 0 &&
                string.Compare(this.Title, other.Title, StringComparison.Ordinal) == 0 &&
                this.Price.CompareTo(other.Price) == 0)
            {
                return 0;
            }

            if (string.Compare(this.Barcode, other.Barcode, StringComparison.Ordinal) > 0 &&
                string.Compare(this.Vendor, other.Vendor, StringComparison.Ordinal) > 0 &&
                string.Compare(this.Title, other.Title, StringComparison.Ordinal) > 0 &&
                this.Price.CompareTo(other.Price) > 0)
            {
                return 1;
            }

            if (string.Compare(this.Barcode, other.Barcode, StringComparison.Ordinal) < 0 &&
                string.Compare(this.Vendor, other.Vendor, StringComparison.Ordinal) < 0 &&
                string.Compare(this.Title, other.Title, StringComparison.Ordinal) < 0 &&
                this.Price.CompareTo(other.Price) < 0)
            {
                return -1;
            }

            return -1;
        }
    }
}
