namespace Common
{
    using System;

    public class Validation
    {
        public static void StringIsNullOrEmpty(string value, string message)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(message + " can't be null or empty");
            }
        }

        public static void LessThanZero<T>(T value, T min, string message) where T : IComparable
        {
            if (value.CompareTo(min) < 0)
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
    }
}