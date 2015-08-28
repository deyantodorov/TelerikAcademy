namespace T02.FloatOrDouble
{
    using System;

    /// <summary>
    /// 2. Which of the following values can be assigned to a variable of type float and which to a variable of type double: 34.567839023, 12.345, 8923.1234857, 3456.091?
    /// </summary>
    public class FloatOrDouble
    {
        private static void Main()
        {
            float floatValue1 = 12.345f;
            float floatValue2 = 3456.091f;

            double doubleValue1 = 34.567839023;
            double doubleValue2 = 8923.1234857;

            Console.WriteLine(floatValue1);
            Console.WriteLine(floatValue2);
            Console.WriteLine(doubleValue1);
            Console.WriteLine(doubleValue2);
        }
    }
}