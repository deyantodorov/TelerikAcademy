namespace FurnitureManufacturer.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    public class Validation
    {
        public static void StringIsNullOrEmpty(string value, string message)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(message + " can't be null or empty");
            }
        }

        public static void LessThan<T>(T value, T min, string message) where T : IComparable
        {
            if (value.CompareTo(min) < 0)
            {
                throw new ArgumentOutOfRangeException(message + " can't be less than zero");
            }
        }

        public static void LessThanOrEqual<T>(T value, T min, string message) where T : IComparable
        {
            if (value.CompareTo(min) <= 0)
            {
                throw new ArgumentOutOfRangeException(message + " can't be less than zero");
            }
        }

        public static void IsInRange(int value, string message, int min, int max)
        {
            if (value < min || value > max)
            {
                throw new ArgumentOutOfRangeException(string.Format("Input value for {0} is {1}, but can't be less than {2} and greater than{3}", message, value, min, max));
            }
        }

        public static void IsDigits(string value, string message)
        {
            if (value.Any(ch => !char.IsDigit(ch)))
            {
                throw new ArgumentException(message + " must be only digits");
            }
        }

        internal static void IsNull(ICollection<IFurniture> value, string message)
        {
            if (value == null)
            {
                throw new ArgumentNullException(message + " can't be null");
            }
        }
    }
}
