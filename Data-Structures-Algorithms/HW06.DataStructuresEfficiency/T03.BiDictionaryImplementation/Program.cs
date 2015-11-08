using System;

namespace T03.BiDictionaryImplementation
{
    public class Program
    {
        private static void Main()
        {
            var bidictionary = new BiDictionary<string, int, string>(true);

            bidictionary.Add("kircho", 1, "JavaScript");
            bidictionary.Add("mircho", 2, "Java");
            bidictionary.Add("svircho", 3, "C#");
            bidictionary.Add("shosho", 3, "C#");
            bidictionary.Add("gosho", 3, "Coffee");
            bidictionary.Add("tosho", 1, "Python");

            Console.WriteLine(string.Join(" ", bidictionary.GetByFirstKey("mircho")));
            Console.WriteLine(string.Join(" ", bidictionary.GetBySecondKey(3)));
            Console.WriteLine(string.Join(" ", bidictionary.GetByFirstAndSecondKey("svircho", 3)));

            Console.WriteLine(bidictionary.Count);

            bidictionary.RemoveByFirstKey("gosho");
            Console.WriteLine(bidictionary.Count);

            bidictionary.RemoveBySecondKey(3);
            Console.WriteLine(bidictionary.Count);

            bidictionary.RemoveByFirstAndSecondKey("tosho", 1);
            Console.WriteLine(bidictionary.Count);
        }
    }
}
