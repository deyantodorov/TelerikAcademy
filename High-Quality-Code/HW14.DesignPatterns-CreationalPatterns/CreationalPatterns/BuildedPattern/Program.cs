using System;

namespace BuildedPattern
{
    public class Program
    {
        private static void Main()
        {
            var mealBuilder = new MealBuilder();

            var veganMeal = mealBuilder.PrepareVeganMeal();

            Console.WriteLine("Vegan Meal");
            veganMeal.ShowItems();
            Console.WriteLine($"Total cost: {veganMeal.GetCost()}");
            Console.WriteLine();

            var nonVeganMeal = mealBuilder.PrepareNonVeganMeal();
            Console.WriteLine("Non vegan meal");
            nonVeganMeal.ShowItems();
            Console.WriteLine($"Total cost: {nonVeganMeal.GetCost()}");
        }
    }
}
