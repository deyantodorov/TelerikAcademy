namespace FarmersCreed.Units
{
    using FarmersCreed.Interfaces;

    public class Animal : FarmUnit
    {
        public Animal(string id, int health, int productionQuantity, int productionHealthEffect)
            : base(id, health, productionQuantity)
        {
            this.ProductionHealthEffect = productionHealthEffect;
        }

        public int ProductionHealthEffect { get; set; }

        public virtual void Eat(IEdible food, int quantity)
        {
        }

        public virtual void Starve()
        {
            this.Health--;
        }

        public override string ToString()
        {
            string liveStatus = "DEAD";

            if (this.IsAlive)
            {
                liveStatus = string.Format("Health: {0}", this.Health);
            }

            return string.Format("{0}, {1}", base.ToString(), liveStatus);
        }
    }
}
