﻿namespace RestaurantManager.Engine.Factories
{
    using RestaurantManager.Interfaces;
    using RestaurantManager.Interfaces.Engine;
    using RestaurantManager.Models;

    public class RecipeFactory : IRecipeFactory
    {
        public IDrink CreateDrink(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isCarbonated)
        {
            return new Drink(name, price, calories, quantityPerServing, timeToPrepare, isCarbonated);
        }

        public ISalad CreateSalad(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool containsPasta)
        {
            return new Salad(name, price, calories, quantityPerServing, timeToPrepare, containsPasta);
        }

        public IMainCourse CreateMainCourse(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan, string type)
        {
            return new MainCourse(name, price, calories, quantityPerServing, timeToPrepare, isVegan, this.GetMainCourseType(type));
        }

        public IDessert CreateDessert(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan)
        {
            return new Dessert(name, price, calories, quantityPerServing, timeToPrepare, isVegan);
        }

        private MainCourseType GetMainCourseType(string type)
        {
            switch (type.ToLower())
            {
                case "soup":
                    return MainCourseType.Soup;
                case "entree":
                    return MainCourseType.Entree;
                case "pasta":
                    return MainCourseType.Pasta;
                case "side":
                    return MainCourseType.Side;
                case "meat":
                    return MainCourseType.Meat;
                default:
                    return MainCourseType.Other;
            }
        }
    }
}
