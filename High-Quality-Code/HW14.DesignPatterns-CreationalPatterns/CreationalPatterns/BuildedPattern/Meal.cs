using System;
using System.Collections.Generic;
using System.Linq;
using BuildedPattern.Interfaces;

namespace BuildedPattern
{
    public class Meal
    {
        private readonly List<IItem> items = new List<IItem>();

        public void AddItem(IItem item)
        {
            this.items.Add(item);
        }

        public float GetCost()
        {
            return this.items.Sum(item => item.Price());
        }

        public void ShowItems()
        {
            foreach (var item in this.items)
            {
                Console.WriteLine($"Item: {item.Name()}");
                Console.WriteLine($"Packing: {item.Packing().Pack()}");
                Console.WriteLine($"Price: {item.Price()}");
            }
        }
    }
}
