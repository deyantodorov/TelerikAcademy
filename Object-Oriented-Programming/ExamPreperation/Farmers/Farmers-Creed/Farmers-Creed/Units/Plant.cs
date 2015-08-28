namespace FarmersCreed.Units
{
    public class Plant : FarmUnit
    {
        public Plant(string id, int health, int productionQuantity, int growTime)
            : base(id, health, productionQuantity)
        {
            this.GrowTime = growTime;
        }

        public bool HasGrown { get; protected set; }

        public int GrowTime { get; set; }

        public virtual void Water()
        {
            this.Health += 2;
        }

        public virtual void Wither()
        {
            if (this.HasGrown)
            {
                this.Health -= 1;
            }
        }

        public virtual void Grow()
        {
            this.GrowTime--;

            if (this.GrowTime <= 0)
            {
                this.HasGrown = true;
            }
        }

        public override string ToString()
        {
            string liveStatus = "DEAD";

            if (this.IsAlive)
            {
                liveStatus = string.Format("Health: {0}, Grown: {1}", this.Health, this.HasGrown ? "Yes" : "No");
            }

            return string.Format("{0}, {1}", base.ToString(), liveStatus);
        }
    }
}
