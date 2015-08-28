namespace RestaurantManager.Models
{
    using System;
    using System.Text;
    using RestaurantManager.Interfaces;

    public abstract class Recipe : IRecipe
    {
        private string name;
        private decimal price;
        private int calories;
        private int quantityPerServing;
        private int timeToPrepare;

        protected Recipe(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare)
        {
            this.Name = name;
            this.Price = price;
            this.Calories = calories;
            this.QuantityPerServing = quantityPerServing;
            this.TimeToPrepare = timeToPrepare;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                this.ValidateStringIsNullOrEmpty(value, "The Name is required");
                this.name = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            private set
            {
                this.ValidationLessThan(value, 0, "Price");
                this.price = value;
            }
        }

        public int Calories
        {
            get
            {
                return this.calories;

            }

            private set
            {
                this.ValidationLessThan(value, 0, "Calories");
                this.calories = value;
            }
        }

        public int QuantityPerServing
        {
            get
            {
                return this.quantityPerServing;
            }

            private set
            {
                this.ValidationLessThan(value, 0, "QuantityPerServing");
                this.quantityPerServing = value;
            }
        }

        public MetricUnit Unit { get; protected set; }

        public int TimeToPrepare
        {
            get
            {
                return this.timeToPrepare;
            }

            private set
            {
                this.ValidationLessThan(value, 0, "TimeToPrepare");
                this.timeToPrepare = value;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            // TODO: Currency Issue. Refactor {1:C}
            output.AppendFormat("==  {0} == ${1:F2}{2}", this.Name, this.Price, Environment.NewLine);
            output.AppendFormat("Per serving: {0} {1}, {2} kcal{3}", this.QuantityPerServing, this.Unit.Equals(MetricUnit.Grams) ? "g" : "ml", this.Calories, Environment.NewLine);
            output.AppendFormat("Ready in {0} minutes", this.TimeToPrepare);

            return output.ToString();
        }

        protected void ValidateStringIsNullOrEmpty(string value, string message)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(message);
            }
        }

        protected void ValidationLessThan<T>(T value, T minValue, string message) where T : IComparable
        {
            if (value.CompareTo(minValue) < 0)
            {
                string errorMessage = string.Format("The {0} must be positive.", message);
                throw new ArgumentOutOfRangeException(errorMessage);
            }
        }
    }
}
