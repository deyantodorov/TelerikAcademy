namespace RestaurantManager.Models
{
    using System;
    using System.Text;
    using RestaurantManager.Interfaces;

    public class Drink : Recipe, IDrink
    {
        public Drink(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isCarbonated)
            : base(name, price, calories, quantityPerServing, timeToPrepare)
        {
            this.IsCarbonated = isCarbonated;
            this.Unit = MetricUnit.Milliliters;


            // TODO: Refactor this. Bad practise but no time for refactoring!
            if (calories > 100)
            {
                throw new ArgumentOutOfRangeException("calories");
            }

            if (timeToPrepare > 20)
            {
                throw new ArgumentOutOfRangeException("timeToPrepare");
            }
        }

        public bool IsCarbonated { get; private set; }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.AppendFormat("{0}{1}", base.ToString(), Environment.NewLine);
            output.AppendFormat("Carbonated: {0}{1}", this.IsCarbonated ? "yes" : "no", Environment.NewLine);

            return output.ToString();
        }
    }
}
