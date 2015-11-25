namespace T01.KnapsackProblem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// 1. Write a program based on dynamic programming to solve the "Knapsack Problem": you are given N products, each has weight Wi and costs Ci and a knapsack of capacity M and you want to put inside a subset of the products with highest cost and weight ≤ M. The numbers N, M, Wi and Ci are integers in the range [1..500]. Example: M=10 kg, N=6, products:
    ///     beer – weight=3, cost=2
    ///     vodka – weight=8, cost=12
    ///     cheese – weight=4, cost=5
    ///     nuts – weight=1, cost=4
    ///     ham – weight=2, cost=3
    ///     whiskey – weight=8, cost=13
    ///     
    ///     Optimal solution:
    ///     nuts + whiskey
    ///     weight = 9
    ///     cost = 17
    /// </summary>

    public class MainProgram
    {
        private static void Main()
        {
            List<Item> knapsackItems = new List<Item>();
            knapsackItems.Add(new Item
            {
                Name = "beer",
                Weight = 3,
                Value = 2,
            });

            knapsackItems.Add(new Item
            {
                Name = "vodka",
                Weight = 8,
                Value = 12,
            });

            knapsackItems.Add(new Item
            {
                Name = "cheese",
                Weight = 4,
                Value = 5,
            });

            knapsackItems.Add(new Item
            {
                Name = "nuts",
                Weight = 1,
                Value = 4,
            });

            knapsackItems.Add(new Item
            {
                Name = "ham",
                Weight = 2,
                Value = 3,
            });

            knapsackItems.Add(new Item
            {
                Name = "whiskey",
                Weight = 8,
                Value = 13,
            });

            var bag = new Knapsack(10);
            bag.Calculate(knapsackItems);
            bag.All(x => { Console.WriteLine(x); return true; });
            Console.WriteLine("Max weight: " + bag.Sum(x => x.Weight));
            Console.WriteLine("Max value: " + bag.Sum(x => x.Value));
        }
    }
}
