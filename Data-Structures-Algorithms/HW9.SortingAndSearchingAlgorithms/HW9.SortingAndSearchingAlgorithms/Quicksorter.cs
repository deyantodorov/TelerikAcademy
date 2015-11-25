using System;
using System.Collections.Generic;

namespace HW9.SortingAndSearchingAlgorithms
{
    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection", "Collection to sort cannot be null!");
            }

            this.QuickSort(collection, 0, collection.Count - 1);
        }

        private void QuickSort(IList<T> collection, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                return;
            }

            int partitionIndex = this.Partition(collection, startIndex, endIndex);
            this.QuickSort(collection, startIndex, partitionIndex - 1);
            this.QuickSort(collection, partitionIndex + 1, endIndex);
        }

        private int Partition(IList<T> collection, int startIndex, int endIndex)
        {
            T pivot = collection[endIndex];
            int start = startIndex - 1;

            for (int i = startIndex; i < endIndex; i++)
            {
                if (collection[i].CompareTo(pivot) < 0)
                {
                    start++;

                    T temp = collection[start];
                    collection[start] = collection[i];
                    collection[i] = temp;
                }
            }

            T temp1 = collection[start + 1];
            collection[start + 1] = collection[endIndex];
            collection[endIndex] = temp1;

            return start + 1;
        }
    }
}
