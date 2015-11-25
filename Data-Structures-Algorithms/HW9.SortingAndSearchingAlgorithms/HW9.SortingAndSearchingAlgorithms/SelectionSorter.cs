using System;
using System.Collections.Generic;

namespace HW9.SortingAndSearchingAlgorithms
{
    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection", "Collection to sort cannot be null!");
            }

            for (int i = 0; i < collection.Count; i++)
            {
                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[i].CompareTo(collection[j]) > 0)
                    {
                        T temp = collection[i];

                        collection[i] = collection[j];
                        collection[j] = temp;
                    }
                }
            }
        }
    }
}
