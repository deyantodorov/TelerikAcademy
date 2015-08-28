namespace RestaurantManager.Models
{
    using System;
    using System.Text;
    using RestaurantManager.Interfaces;

    public class Dessert : Meal, IDessert
    {
        public Dessert(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan)
            : base(name, price, calories, quantityPerServing, timeToPrepare, isVegan)
        {
            this.WithSugar = true;
        }

        public bool WithSugar { get; private set; }

        public void ToggleSugar()
        {
            this.WithSugar = !this.WithSugar;
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.AppendFormat("{0}{1}{2}{3}", this.WithSugar ? string.Empty : "[NO SUGAR] ", this.IsVegan ? "[VEGAN] " : string.Empty, base.ToString(), Environment.NewLine);

            return output.ToString();
        }
    }
}
