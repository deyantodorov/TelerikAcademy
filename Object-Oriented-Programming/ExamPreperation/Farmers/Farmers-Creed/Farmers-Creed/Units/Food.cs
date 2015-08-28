namespace FarmersCreed.Units
{
    using FarmersCreed.Interfaces;

    public class Food : Product, IEdible
    {
        private FoodType foodType;
        private int healthEffect;

        public Food(string id, ProductType productType, FoodType foodType, int quantity, int healthEffect)
            : base(id, productType, quantity)
        {
            this.HealthEffect = healthEffect;
            this.FoodType = foodType;
        }

        public FoodType FoodType
        {
            get { return this.foodType; }
            set { this.foodType = value; }
        }

        public int HealthEffect
        {
            get { return this.healthEffect; }
            set { this.healthEffect = value; }
        }

        public override string ToString()
        {

            //--Food GovedoProduct, Quantity: 3, Product Type: Milk, Food Type: Organic, Health Effect: 4
            return string.Format("--Food {0}, Quantity: {1}, Product Type: {2}, Food Type: {3}, Health Effect: {4}", this.Id, this.Quantity, this.ProductType, this.FoodType, this.HealthEffect);
        }
    }
}
