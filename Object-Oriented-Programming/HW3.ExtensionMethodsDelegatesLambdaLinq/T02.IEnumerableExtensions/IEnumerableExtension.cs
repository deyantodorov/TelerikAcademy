namespace T02.IEnumerableExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Problem 2. IEnumerable extensions
    ///            Implement a set of extension methods for IEnumerable<T> that implement the following group functions: sum, product, min, max, average.
    /// </summary>
    public static class IEnumerableExtension
    {
        /// <summary>
        /// Sum extension method
        /// </summary>
        public static T Sum<T>(this IEnumerable<T> collection)
        {
            ValidateForEmptyCollection<T>(collection);

            T result = default(T);

            foreach (var item in collection)
            {
                dynamic current = item;
                result += current;
            }

            return result;
        }

        /// <summary>
        /// Product extension method
        /// </summary>
        public static T Product<T>(this IEnumerable<T> collection) where T : IComparable
        {
            ValidateForEmptyCollection<T>(collection);
            ValidateForNumber<T>(collection);

            dynamic product = 1;

            foreach (T item in collection)
            {
                product *= item;
            }

            return product;
        }

        /// <summary>
        /// Min extension method
        /// </summary>
        public static T Min<T>(this IEnumerable<T> collection) where T : IComparable
        {
            ValidateForEmptyCollection<T>(collection);

            T min = collection.First();

            foreach (var item in collection)
            {
                if (item.CompareTo(min) < 0)
                {
                    min = item;
                }
            }

            return min;
        }

        /// <summary>
        /// Max extension method
        /// </summary>
        public static T Max<T>(this IEnumerable<T> collection) where T : IComparable
        {
            ValidateForEmptyCollection<T>(collection);

            T max = collection.First();

            foreach (var item in collection)
            {
                if (max.CompareTo(item) < 0)
                {
                    max = item;
                }
            }

            return max;
        }

        /// <summary>
        /// Average extension method
        /// </summary>
        public static T Average<T>(this IEnumerable<T> collection) where T : IComparable
        {
            ValidateForEmptyCollection<T>(collection);

            T sum = default(T);
            dynamic count = 0;

            foreach (T item in collection)
            {
                count++;
                dynamic value = item;
                sum += value;
            }

            return sum / count;
        }

        private static void ValidateForNumber<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                decimal value;
                bool isNumber = decimal.TryParse(item.ToString(), out value);

                if (!isNumber)
                {
                    throw new ArgumentException("Value is not number");
                }
            }
        }

        private static void ValidateForEmptyCollection<T>(IEnumerable<T> collection)
        {
            if (collection.Count() == 0)
            {
                throw new ArgumentNullException("Collection is empty");
            }
        }
    }
}
