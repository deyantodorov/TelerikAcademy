using System.Collections.Generic;

namespace StrategyPattern
{
    public interface ISortingStrategy
    {
        void Sort<T>(List<T> dataToBeSorted);
    }
}
