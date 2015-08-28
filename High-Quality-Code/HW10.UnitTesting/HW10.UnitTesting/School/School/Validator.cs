namespace School
{
    using System;

    public static class Validator
    {
        public static void IsNull<T>(T value, string name)
        {
            if (value == null)
            {
                throw new NullReferenceException(name + "'t can't be null");
            }
        }

        public static void IsNullOrWhiteSpace(string value, string name)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(string.Format("{0} name can't be null or whitespace", name));
            }
        }
    }
}