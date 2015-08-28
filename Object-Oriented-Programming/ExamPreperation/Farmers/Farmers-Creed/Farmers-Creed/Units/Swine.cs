namespace FarmersCreed.Units
{
    using FarmersCreed.Interfaces;

    public class Swine : Animal
    {
        public Swine(string id, int health, int productionQuantity, int productionHealthEffect)
            : base(id, health, productionQuantity, productionHealthEffect)
        {
        }

        public override void Eat(IEdible food, int quantity)
        {
            // TODO: How the fucking pig eats. Not described. Kill the business analyst!
            // Try wit this:
            var eat = food.HealthEffect * 2 * quantity;
            this.Health += eat;
        }

        public override void Starve()
        {
            this.Health -= 3;
        }

        public override Product GetProduct()
        {
            if (this.IsAlive)
            {
                this.IsAlive = false;
                return new PorkMeat(this.GetProducetItemName(this.Id), ProductType.PorkMeat, FoodType.Meat, this.ProductionQuantity, this.ProductionHealthEffect);
            }

            return base.GetProduct();
        }
    }
}
