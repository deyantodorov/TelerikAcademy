namespace T06.IndexOfElement
{
    using System;
    using T05.Bigger;

    /// <summary>
    /// 6. Write a method that returns the index of the first element in array that is bigger than its neighbors, or -1, if there’s no such element.
    ///    Use the method from the previous exercise.
    /// </summary>
    public class IndexOfElement
    {
        private static void Main()
        {
            int[] array = { 0, 2, 1, 2, 3, 4, 1, 5, 2, 7, 8, 2, 4, 3, 23 };
            int[] array2 = { 0, 0, 0 };
            Console.WriteLine(FindBigger(array));
            Console.WriteLine(FindBigger(array2));
        }

        private static int FindBigger(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (Bigger.IsBigger(array, i) == 1)
                {
                    return i;
                }
            }

            // default value for not found
            return -1;
        }
    }
}
