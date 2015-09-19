using System.Collections.Generic;

namespace StrategyPattern
{
    public class MergeSort : ISortingStrategy
    {
        public void Sort<T>(List<T> dataToBeSorted)
        {
            // It's not Merge Sort, but it's just an example for Strategy Pattern
            dataToBeSorted.Sort();
        }
    }
}
