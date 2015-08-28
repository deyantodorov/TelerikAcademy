namespace MobilePhone
{
    using System;

    public static class DataValidator
    {
        public static void StringNullEmptyValidation(string message, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(message + "  can't be null or empty");
            }
        }

        public static void NegativeNumber(string message, decimal value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(message + " can't be negative value");
            }
        }
    }
}
