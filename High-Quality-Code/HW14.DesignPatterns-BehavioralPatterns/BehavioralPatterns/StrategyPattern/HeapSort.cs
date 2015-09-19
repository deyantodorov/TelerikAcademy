using System.Collections.Generic;

namespace StrategyPattern
{
    public class HeapSort : ISortingStrategy
    {
        public void Sort<T>(List<T> dataToBeSorted)
        {
            // It's not Heap Sort, but it's just an example for Strategy Pattern
            dataToBeSorted.Sort();
        }
    }
}
