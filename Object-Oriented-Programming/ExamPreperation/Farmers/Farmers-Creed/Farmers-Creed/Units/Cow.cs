namespace FarmersCreed.Units
{
    using FarmersCreed.Interfaces;

    public class Cow : Animal
    {
        public Cow(string id, int health, int productionQuantity, int productionHealthEffect)
            : base(id, health, productionQuantity, productionHealthEffect)
        {
        }

        public override void Eat(IEdible food, int quantity)
        {
            var eat = food.HealthEffect * quantity;

            switch (food.FoodType)
            {
                case FoodType.Organic:
                    this.Health += eat;
                    break;
                case FoodType.Meat:
                    this.Health -= eat;
                    break;
            }
        }

        public override Product GetProduct()
        {
            if (!this.IsAlive)
            {
                return base.GetProduct();
            }

            this.Health -= 2;
            return new Milk(this.GetProducetItemName(this.Id), ProductType.Milk, FoodType.Organic, this.ProductionQuantity, this.ProductionHealthEffect);
        }
    }
}
