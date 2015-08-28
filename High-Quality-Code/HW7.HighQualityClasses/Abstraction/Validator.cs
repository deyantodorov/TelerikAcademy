namespace Abstraction
{
    using System;

    public class Validator
    {
        public static void ValueNotEqualToZero(double value, string name)
        {
            if (value == 0)
            {
                throw new ArgumentOutOfRangeException(name + " can't be zero");
            }
        }

        public static void ValueNotLessThanZero(double value, string name)
        {
            if (value == 0)
            {
                throw new ArgumentOutOfRangeException(name + " can't be zero");
            }
        }
    }
}
