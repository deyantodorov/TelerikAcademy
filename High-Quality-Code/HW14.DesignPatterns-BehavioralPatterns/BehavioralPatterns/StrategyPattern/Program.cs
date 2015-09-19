using System;
using System.Collections.Generic;

namespace StrategyPattern
{
    public class Program
    {
        private static void Main()
        {
            var countryResidents = new List<string> { "ad", "xx", "ax", "zw" };
            var sortingStrategy = Strategy.GetSortingStrategy(ObjectToSort.CountryResidents);
            sortingStrategy.Sort(countryResidents);

            countryResidents.ForEach(x => Console.Write(x + " "));
            Console.WriteLine();

            var studentNumbers = new List<int>() { 123, 321, 111, 331 };
            sortingStrategy = Strategy.GetSortingStrategy(ObjectToSort.StudentNumber);
            sortingStrategy.Sort(studentNumbers);

            studentNumbers.ForEach(x => Console.Write(x + " "));
            Console.WriteLine();

            var railwayPassangers = new List<string>() { "A21", "Z2", "F3", "G43" };
            sortingStrategy = Strategy.GetSortingStrategy(ObjectToSort.RailwayPassangers);
            sortingStrategy.Sort(railwayPassangers);

            railwayPassangers.ForEach(x => Console.Write(x + " "));
            Console.WriteLine();
        }
    }
}
