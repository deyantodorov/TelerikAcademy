using System;
using System.Linq;

namespace FactoryMethod
{
    public class Program
    {
        private static void Main()
        {
            var creators = new Creator[2];
            creators[0] = new ConcreteCreatorA();
            creators[1] = new ConcreteCreatorB();

            foreach (var product in creators.Select(creator => creator.FactoryMethod()))
            {
                Console.WriteLine($"{product} with class name {product.GetType().Name} created at {DateTime.Now}");
            }
        }
    }
}
