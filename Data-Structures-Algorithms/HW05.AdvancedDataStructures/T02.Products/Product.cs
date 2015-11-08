namespace T02.Products
{
    using System;
    public class Product : IComparable
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
        {
            return string.Format("Name: {0}, Price: {1}", this.Name, this.Price);
        }

        public int CompareTo(object obj)
        {
            var other = obj as Product;

            if (other == null)
            {
                throw new ArgumentNullException("obj", "Can't be null");
            }

            int compare = string.Compare(other.Name, this.Name, StringComparison.Ordinal);

            return compare == 0 ? this.Price.CompareTo(other.Price) : compare;
        }

        public override int GetHashCode()
        {
            var rand = new Random();
            var value = rand.Next(1, 100);
            var hash = (this.Name.Length ^ value + (int)this.Price) / 2 * DateTime.Now.Second; ;
            return hash;
        }
    }
}