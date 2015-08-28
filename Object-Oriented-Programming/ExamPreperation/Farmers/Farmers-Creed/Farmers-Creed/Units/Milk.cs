namespace FarmersCreed.Units
{
    public class Milk : Food
    {
        public Milk(string id, ProductType productType, FoodType foodType, int quantity, int healthEffect)
            : base(id, productType, foodType, quantity, healthEffect)
        {
        }
    }
}
