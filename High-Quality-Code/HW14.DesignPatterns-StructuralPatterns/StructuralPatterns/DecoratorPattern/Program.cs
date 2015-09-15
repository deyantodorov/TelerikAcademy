using System;

namespace DecoratorPattern
{
    /// <summary>
    /// This example shows how we add different topics on Cakes and Pastry in virtual Bakery
    /// </summary>
    public class Program
    {
        private static void Main()
        {
            var cakeBase = new CakeBase();
            Console.WriteLine(cakeBase);

            var creamCake = new CreamDecorator(cakeBase);
            Console.WriteLine(creamCake);

            var cherryCake = new CherryDecorator(creamCake);
            Console.WriteLine(cherryCake);

            var scentedCake = new ArtificialScentDecorator(cherryCake);
            Console.WriteLine(scentedCake);

            var nameCardOnCake = new NameCardDecorator(scentedCake);
            Console.WriteLine(nameCardOnCake);

            var pastry = new PastryBase();
            Console.WriteLine(pastry);

            var creamPastry = new CreamDecorator(pastry);
            var cherryPastry = new CherryDecorator(creamPastry);
            var scentedPastry = new ArtificialScentDecorator(cherryPastry);
            Console.WriteLine(scentedPastry);
        }
    }
}
