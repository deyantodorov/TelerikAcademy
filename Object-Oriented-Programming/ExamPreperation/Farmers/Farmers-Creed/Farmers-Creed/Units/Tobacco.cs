namespace FarmersCreed.Units
{

    public class Tobacco : Product
    {
        public Tobacco(string id, ProductType productType, int quantity)
            : base(id, productType, quantity)
        {
        }

        public override string ToString()
        {
            //--Product TutunProduct, Quantity: 10, Product Type: Tobacco
            return string.Format("--Product {0}, Quantity: {1}, Product Type: {2}", this.Id, this.Quantity, this.ProductType);
        }
    }
}
