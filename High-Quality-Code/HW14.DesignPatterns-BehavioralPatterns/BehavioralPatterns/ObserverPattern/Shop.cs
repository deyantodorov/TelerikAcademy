using System;

namespace ObserverPattern
{
    public class Shop : IObserver
    {
        private readonly string name;
        private float price;

        public Shop(string name, float price)
        {
            this.name = name;
            this.price = price;
        }

        public void Update(float updatePrice)
        {
            this.price += updatePrice;
        }

        public override string ToString()
        {
            return $"Name: {this.name}, Price: {this.price}";
        }
    }
}
