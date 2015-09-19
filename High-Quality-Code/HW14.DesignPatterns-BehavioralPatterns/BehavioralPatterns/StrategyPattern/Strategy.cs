using System;

namespace StrategyPattern
{
    public class Strategy
    {
        public static ISortingStrategy GetSortingStrategy(ObjectToSort objectToSort)
        {
            ISortingStrategy sortingStrategy = null;

            switch (objectToSort)
            {
                case ObjectToSort.StudentNumber:
                    sortingStrategy = new MergeSort();
                    break;
                case ObjectToSort.RailwayPassangers:
                    sortingStrategy = new HeapSort();
                    break;
                case ObjectToSort.CountryResidents:
                    sortingStrategy = new QuickSort();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Unsupported object to sort");
            }

            return sortingStrategy;
        }
    }
}
