namespace HW5.Variables.Data.Expressions.Constants
{
    using System;

    /// <summary>
    /// General class for statistic calculations: average, minimum, maximum
    /// </summary>
    public static class Statistics
    {
        /// <summary>
        /// Return maximum of given values in array
        /// </summary>
        /// <param name="array">numbers in array</param>
        /// <param name="count">number of values</param>
        public static double GetMax(double[] array, int count)
        {
            IsCountCorrect(array.Length, count);

            double max = array[0];

            for (int i = 1; i < count; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }

            return Print(max);
        }

        /// <summary>
        /// Return minimum of given values in array
        /// </summary>
        /// <param name="array">numbers in array</param>
        /// <param name="count">number of values</param>
        public static double GetMin(double[] array, int count)
        {
            IsCountCorrect(array.Length, count);

            double min = array[0];

            for (int i = 1; i < count; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }

            return Print(min);
        }

        /// <summary>
        /// Return average of given values in array
        /// </summary>
        /// <param name="array">numbers in array</param>
        /// <param name="count">number of values</param>
        public static double GetAvg(double[] array, int count)
        {
            IsCountCorrect(array.Length, count);

            double sum = array[0];

            for (int i = 1; i < count; i++)
            {
                sum += array[i];
            }

            var average = sum / count;

            return Print(average);
        }

        /// <summary>
        /// Print information.
        /// </summary>
        private static double Print(double input)
        {
            return input;
        }

        /// <summary>
        /// Validation method for count value. Count must be between 0 and array.length - 1
        /// </summary>
        private static void IsCountCorrect(int length, int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("Count can't be less than 0");
            }
            else if (count > length)
            {
                throw new ArgumentOutOfRangeException("Count is greater than array length");
            }
        }
    }
}
