namespace FarmersCreed.Units
{
    using FarmersCreed.Interfaces;

    public class Cherry : Food, IEdible
    {
        public Cherry(string id, ProductType productType, FoodType foodType, int quantity, int healthEffect)
            : base(id, productType, foodType, quantity, healthEffect)
        {
        }
    }
}
