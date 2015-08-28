namespace FarmersCreed.Units
{
    using FarmersCreed.Interfaces;

    public class TobaccoPlant : Plant, IProductProduceable
    {
        public TobaccoPlant(string id, int health, int productionQuantity, int growTime)
            : base(id, health, productionQuantity, growTime)
        {
        }

        public override void Grow()
        {
            this.GrowTime -= 2;

            if (this.GrowTime <= 0)
            {
                this.HasGrown = true;
            }
        }

        public override Product GetProduct()
        {
            return this.IsAlive ? new Tobacco(this.GetProducetItemName(this.Id), ProductType.Tobacco, this.ProductionQuantity) : base.GetProduct();
        }
    }
}
