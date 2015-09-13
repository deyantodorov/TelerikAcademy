namespace BuildedPattern
{
    public class MealBuilder
    {
        public Meal PrepareVeganMeal()
        {
            var meal = new Meal();

            meal.AddItem(new VeganBurger());
            meal.AddItem(new Coke());

            return meal;
        }

        public Meal PrepareNonVeganMeal()
        {
            var meal = new Meal();

            meal.AddItem(new ChickenBurger());
            meal.AddItem(new Pepsi());

            return meal;
        }
    }
}
