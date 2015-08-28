namespace T05.Bigger
{
    using System;

    /// <summary>
    /// 5. Write a method that checks if the element at given position in given array of integers is bigger than its two neighbors (when such exist).
    /// </summary>
    public class Bigger
    {
        /// <summary>
        /// Compare array neighbours
        /// </summary>
        /// <returns>(1) - bigger, (-1) - not bigger, (0) - equal</returns>
        public static int IsBigger(int[] array, int position)
        {
            int result = 0;

            if (position >= array.Length)
            {
                throw new ArgumentOutOfRangeException("This position is outside of array.");
            }
            else if (array.Length < 2)
            {
                throw new ArgumentException("You need at least two elements in your array.");
            }
            else
            {
                if (position == 0)
                {
                    result = array[position].CompareTo(array[position + 1]);
                }
                else if (position == array.Length - 1)
                {
                    result = array[position].CompareTo(array[position - 1]);
                }
                else
                {
                    if (array[position].CompareTo(array[position - 1]) == 1 && array[position].CompareTo(array[position + 1]) == 1)
                    {
                        result = 1;
                    }
                    else if (array[position].CompareTo(array[position - 1]) == -1 && array[position].CompareTo(array[position + 1]) == -1)
                    {
                        result = -1;
                    }
                    else if (array[position].CompareTo(array[position - 1]) == 0 && array[position].CompareTo(array[position + 1]) == 0)
                    {
                        result = 0;
                    }
                }
            }

            return result;
        }

        private static void Main()
        {
            int[] array = { 12, 2, 1, 2, 3, 4, 1, 5, 2, 7, 8, 2, 4, 3, 23 };

            int result = IsBigger(array, 0);

            if (result == 1)
            {
                Console.WriteLine("Bigger");
            }
            else if (result == -1)
            {
                Console.WriteLine("Smaller");
            }
            else
            {
                Console.WriteLine("Equal");
            }
        }
    }
}
