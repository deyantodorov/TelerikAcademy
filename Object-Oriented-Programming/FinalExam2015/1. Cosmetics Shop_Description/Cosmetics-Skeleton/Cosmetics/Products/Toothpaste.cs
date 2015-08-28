namespace Cosmetics.Products
{
    using System.Collections.Generic;
    using System.Text;

    using Cosmetics.Common;
    using Cosmetics.Contracts;

    public class Toothpaste : Product, IToothpaste
    {
        private const string IngredientsPrintFormat = "  * Ingredients: {0}";
        private const int IngradientsMaxLength = 12;
        private const int IngradientsMinLength = 4;
        private const string IngradientsPrintName = "Each ingredient";
        private string ingredients;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients)
            : base(name, brand, price, gender)
        {
            this.Ingredients = this.GetIngradents(ingredients);
        }

        public string Ingredients
        {
            get
            {
                return this.ingredients;
            }

            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value);
                this.ingredients = value;
            }
        }

        public override string ToString()
        {
            string print = base.ToString() + this.PrintToothpaste();
            return print.Trim();
        }

        private string GetIngradents(IList<string> input)
        {
            this.ValidateInputIngradients(input);
            return string.Join(", ", input);
        }

        private void ValidateInputIngradients(IList<string> input)
        {
            Validator.CheckIfNull(input, string.Format(GlobalErrorMessages.ObjectCannotBeNull, "Ingredients"));

            foreach (var item in input)
            {
                Validator.CheckIfStringLengthIsValid(item, Toothpaste.IngradientsMaxLength, Toothpaste.IngradientsMinLength, string.Format(GlobalErrorMessages.InvalidStringLength, Toothpaste.IngradientsPrintName, Toothpaste.IngradientsMinLength, Toothpaste.IngradientsMaxLength));
            }
        }

        // TODO: May be base.Print() ???
        private string PrintToothpaste()
        {
            var sb = new StringBuilder();

            sb.AppendLine(string.Format(IngredientsPrintFormat, this.Ingredients));

            return sb.ToString();
        }
    }
}
