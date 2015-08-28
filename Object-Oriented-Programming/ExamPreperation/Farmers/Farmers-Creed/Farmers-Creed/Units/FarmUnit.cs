namespace FarmersCreed.Units
{
    using FarmersCreed.Interfaces;

    public abstract class FarmUnit : GameObject, IProductProduceable
    {
        private int health;

        protected FarmUnit(string id, int health, int productionQuantity)
            : base(id)
        {
            this.Health = health;
            this.ProductionQuantity = productionQuantity;
            this.IsAlive = true;
        }

        public int Health
        {
            get
            {
                return this.health; 
            }

            set
            {
                if (!(this.health < 0))
                {
                    this.health = value;
                }

                // Make dead
                if (this.health <= 0)
                {
                    this.IsAlive = false;
                }
            }


        }

        public bool IsAlive { get; protected set; }

        public int ProductionQuantity { get; set; }

        public virtual Product GetProduct()
        {
            return null;
        }

        protected string GetProducetItemName(string id)
        {
            return string.Format("{0}Product", this.Id);
        }
    }
}