namespace T09.FloatToBinary
{
    using System;
    using System.Globalization;
    using System.Threading;
    using Helper;

    /// <summary>
    /// 9. * Write a program that shows the internal binary representation of given 32-bit signed 
    ///      floating-point number in IEEE 754 format (the C# type float). 
    ///      Example: -27,25 -> sign = 1, exponent = 1000 0011, mantissa = 1011 0100 0000 0000 0000 000.
    /// </summary>
    public class FloatToBinary
    {
        private static void Main()
        {
            // You could test here: http://www.h-schmidt.net/FloatConverter/ 
            // Here your could find good tutorial about this problem - http://www.youtube.com/watch?v=H79PNQ4Z9HE
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            float value = InputValidators.AsFloat("Enter some float value: ");

            string result = NumSys.ConvertFloatToBinary(value);
            Console.WriteLine("As binary: {0}", result);
            Console.WriteLine("Sign: {0}", result.Substring(0, 1));
            Console.WriteLine("Exponent: {0}", result.Substring(1, 8));
            Console.WriteLine("Mantissa: {0}", result.Substring(9, 23));
        }
    }
}