namespace Exceptions_Homework
{
    using System;

    public class Validator
    {
        public static void IsValueSmaller(int value, int minValue, string name)
        {
            if (value < minValue)
            {
                throw new ArgumentOutOfRangeException(name + " can't be negative " + minValue);
            }
        }

        public static void IsValueBigger(int value, int minValue, string name)
        {
            if (value < minValue)
            {
                throw new ArgumentOutOfRangeException(name + " can't be negative " + minValue);
            }
        }

        public static void IsStringNullOrEmpty(string value, string name)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(name + " can't be null or empty");
            }
        }
    }
}
