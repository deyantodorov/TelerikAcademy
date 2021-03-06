﻿using System.Collections.Generic;

namespace StrategyPattern
{
    public class QuickSort : ISortingStrategy
    {
        public void Sort<T>(List<T> dataToBeSorted)
        {
            // It's not Quick Sort, but it's just an example for Strategy Pattern
            dataToBeSorted.Sort();
        }
    }
}
