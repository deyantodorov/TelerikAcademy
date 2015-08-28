namespace FarmersCreed.Units
{
    public class FoodPlant : Plant
    {
        public FoodPlant(string id, int health, int productionQuantity, int productionHealthEffect, int growTime)
            : base(id, health, productionQuantity, growTime)
        {
            this.ProductionHealthEffect = productionHealthEffect;
        }

        public int ProductionHealthEffect { get; set; }

        public override void Water()
        {
            this.Health += 1;
        }

        public override void Wither()
        {
            if (this.HasGrown)
            {
                this.Health -= 2;
            }
        }
    }
}
