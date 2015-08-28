namespace RestaurantManager.Models
{
    using System;
    using System.Text;
    using RestaurantManager.Interfaces;

    public class Salad : Meal, ISalad
    {
        public Salad(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool containsPasta)
            : base(name, price, calories, quantityPerServing, timeToPrepare, true)
        {
            this.ContainsPasta = containsPasta;
        }

        public bool ContainsPasta { get; private set; }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.AppendFormat("{0}{1}{2}", this.IsVegan ? "[VEGAN] " : string.Empty, base.ToString(), Environment.NewLine);
            output.AppendFormat("Contains pasta: {0}{1}", this.ContainsPasta ? "yes" : "no", Environment.NewLine);

            return output.ToString();
        }
    }
}
