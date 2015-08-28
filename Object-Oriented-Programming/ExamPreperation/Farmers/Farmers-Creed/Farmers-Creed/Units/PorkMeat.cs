namespace FarmersCreed.Units
{
    public class PorkMeat : Food
    {
        public PorkMeat(string id, ProductType productType, FoodType foodType, int quantity, int healthEffect)
            : base(id, productType, foodType, quantity, healthEffect)
        {
        }
    }
}
