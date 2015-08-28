namespace T15.GenericCalculator
{
    using System;
    using System.Globalization;
    using System.Threading;

    /// <summary>
    /// 15. * Modify your last program and try to make it work for any number type, not just integer (e.g. decimal, float, byte, etc.). 
    ///     Use generic method (read in Internet about generic methods in C#).
    /// </summary>
    public class GenericCalculator
    {
        private static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var min = CalcMin<int>(1, 4, 1, 3, 2, 35, 1, 22, 11, -12, -1);
            Console.WriteLine("Minimum is: {0}", min);

            var max = CalcMax<int>(1, 4, 1, 3, 2, 35, 1, 22, 11, -12, -1);
            Console.WriteLine("Maximum is: {0}", max);

            var avg = CalcAvg<double>(1.1, 4, 1, 3, 2, 35, 1, 22, 11, -12, -1);
            Console.WriteLine("Average is: {0}", avg);

            var sum = CalcSum<int>(1, 4, 1, 3, 2, 35, 1, 22, 11, -12, -1);
            Console.WriteLine("Sum is: {0}", sum);

            var product = CalcProduct<int>(1, 4, 1, 3, 2, 35, 1, 22, 11, -12, -1);
            Console.WriteLine("Product is: {0}", product);
        }

        private static T CalcMin<T>(params T[] array)
        {
            Array.Sort(array);
            dynamic result = array[0];
            return result;
        }

        private static T CalcMax<T>(params T[] array)
        {
            Array.Sort(array);
            dynamic result = array[array.Length - 1];
            return result;
        }

        private static T CalcAvg<T>(params T[] array)
        {
            dynamic result = 0;

            for (int i = 0; i < array.Length; i++)
            {
                result += array[i];
            }

            result = result / array.Length;
            return result;
        }

        private static T CalcSum<T>(params T[] array)
        {
            dynamic result = 0;

            for (int i = 0; i < array.Length; i++)
            {
                result += array[i];
            }

            return result;
        }

        private static T CalcProduct<T>(params T[] array)
        {
            dynamic result = 1;

            for (int i = 0; i < array.Length; i++)
            {
                result *= array[i];
            }

            return result;
        }
    }
}