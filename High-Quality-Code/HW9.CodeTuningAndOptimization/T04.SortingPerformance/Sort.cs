namespace T04.SortingPerformance
{
    using System;

    public static class Sort
    {
        public static void InsertionSort<T>(T[] array) where T : IComparable<T>
        {
            for (int nextIndex = 1; nextIndex < array.Length; nextIndex++)
            {
                var key = array[nextIndex];
                int prevIndex = nextIndex - 1;

                while (prevIndex >= 0 && array[prevIndex].CompareTo(key) > 0)
                {
                    array[prevIndex + 1] = array[prevIndex];
                    prevIndex -= 1;
                    array[prevIndex + 1] = key;
                }
            }
        }

        public static T[] SelectionSort<T>(T[] array) where T : IComparable<T>
        {
            T[] result = array;

            for (int i = 0; i < result.Length; i++)
            {
                for (int j = i + 1; j < result.Length; j++)
                {
                    if (result[i].CompareTo(result[j]) > 0)
                    {
                        Swap(ref result[i], ref result[j]);
                    }
                }
            }

            return result;
        }

        public static void QuickSort<T>(T[] array, int left, int right) where T : IComparable
        {
            int i = left;
            int j = right;

            // Instead of left / 2 we use left shift with 1 position
            IComparable pivot = array[(left >> 1) + (right >> 1)];

            while (i <= j)
            {
                while (array[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (array[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap values
                    var temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;

                    i++;
                    j--;
                }

                // Recursive calls
                if (left < j)
                {
                    QuickSort(array, left, j);
                }

                if (i < right)
                {
                    QuickSort(array, i, right);
                }
            }
        }

        private static void Swap<T>(ref T x, ref T y)
        {
            T oldX = x;
            x = y;
            y = oldX;
        }
    }
}
