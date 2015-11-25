using System;
using System.Collections.Generic;

namespace HW9.SortingAndSearchingAlgorithms
{
    public interface ISorter<T> where T : IComparable<T>
    {
        void Sort(IList<T> collection);
    }
}
