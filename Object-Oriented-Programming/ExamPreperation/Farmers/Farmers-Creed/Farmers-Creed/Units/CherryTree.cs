namespace FarmersCreed.Units
{
    using FarmersCreed.Interfaces;

    public class CherryTree : FoodPlant, IProductProduceable
    {
        public CherryTree(string id, int health, int productionQuantity, int productionHealthEffect, int growTime)
            : base(id, health, productionQuantity, productionHealthEffect, growTime)
        {
        }

        public override Product GetProduct()
        {
            return this.IsAlive ? new Cherry(this.GetProducetItemName(this.Id), ProductType.Cherry, FoodType.Organic, this.ProductionQuantity, this.ProductionHealthEffect) : base.GetProduct();
        }
    }
}