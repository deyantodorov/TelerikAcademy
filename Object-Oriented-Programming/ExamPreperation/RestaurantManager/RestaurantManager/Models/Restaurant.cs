namespace RestaurantManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using RestaurantManager.Interfaces;

    public class Restaurant : IRestaurant
    {
        private const string NoRecipesMessage = "No recipes... yet";
        private const string TitleDrinks = "~~~~~ DRINKS ~~~~~";
        private const string TitleSalads = "~~~~~ SALADS ~~~~~";
        private const string TitleMainCourses = "~~~~~ MAIN COURSES ~~~~~";
        private const string TitleDesserts = "~~~~~ DESSERTS ~~~~~";
        private const string TheNameIsRequired = "The name is required.";
        private const string TheLocationIsRequired = "The location is required.";
        private const string ValueCanTBeNull = "Value can't be null";

        private string name;
        private string location;
        private IList<IRecipe> recipes;

        public Restaurant(string name, string location)
        {
            this.Name = name;
            this.Location = location;
            this.Recipes = new List<IRecipe>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                this.ValidateStringIsNullOrEmpty(value, TheNameIsRequired);
                this.name = value;
            }
        }

        public string Location
        {
            get
            {
                return this.location;
            }

            private set
            {
                this.ValidateStringIsNullOrEmpty(value, TheLocationIsRequired);
                this.location = value;
            }
        }

        public IList<IRecipe> Recipes
        {
            get { return new List<IRecipe>(this.recipes); }
            private set { this.recipes = value; }
        }

        public void AddRecipe(IRecipe recipe)
        {
            this.ValidationForNull(recipe, ValueCanTBeNull);
            this.recipes.Add(recipe);
        }

        public void RemoveRecipe(IRecipe recipe)
        {
            this.ValidationForNull(recipe, ValueCanTBeNull);
            this.recipes.Remove(recipe);
        }

        public string PrintMenu()
        {
            var sb = new StringBuilder();

            sb.AppendLine(string.Format("***** {0} - {1} *****", this.Name, this.Location));

            if (this.recipes.Any())
            {
                this.GetDrinks(sb);
                this.GetSalads(sb);
                this.GetMainCourses(sb);
                this.GetDeserts(sb);
            }
            else
            {
                sb.AppendLine(NoRecipesMessage);
            }

            return sb.ToString().Trim();
        }

        public override string ToString()
        {
            return this.PrintMenu();
        }

        public void ValidationForNull(object value, string message)
        {
            if (value == null)
            {
                throw new ArgumentException(message);
            }
        }

        protected void ValidateStringIsNullOrEmpty(string value, string message)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(message);
            }
        }

        private void GetDrinks(StringBuilder sb)
        {
            var recipesFiltered = this.recipes.Where(x => x is IDrink).OrderBy(x => x.Name).ToList();

            if (!recipesFiltered.Any())
            {
                return;
            }

            this.GetRecipes(sb, recipesFiltered, TitleDrinks);
        }

        private void GetSalads(StringBuilder sb)
        {
            var recipesFiltered = this.recipes.Where(x => x is ISalad).OrderBy(x => x.Name).ToList();

            if (!recipesFiltered.Any())
            {
                return;
            }

            this.GetRecipes(sb, recipesFiltered, TitleSalads);
        }

        private void GetMainCourses(StringBuilder sb)
        {
            var recipesFiltered = this.recipes.Where(x => x is IMainCourse).OrderBy(x => x.Name).ToList();

            if (!recipesFiltered.Any())
            {
                return;
            }

            this.GetRecipes(sb, recipesFiltered, TitleMainCourses);
        }

        private void GetDeserts(StringBuilder sb)
        {
            var recipesFiltered = this.recipes.Where(x => x is IDessert).OrderBy(x => x.Name).ToList();

            if (!recipesFiltered.Any())
            {
                return;
            }

            this.GetRecipes(sb, recipesFiltered, TitleDesserts);
        }

        private void GetRecipes(StringBuilder sb, List<IRecipe> recipesFiltered, string title)
        {
            sb.AppendLine(title);
            foreach (var recipe in recipesFiltered)
            {
                sb.Append(recipe);
            }
        }
    }
}
