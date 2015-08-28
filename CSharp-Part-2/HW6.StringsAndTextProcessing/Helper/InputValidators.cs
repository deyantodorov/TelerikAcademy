namespace Helper
{
    using System;

    /// <summary>
    /// Helper class for different input validator methods
    /// </summary>
    public class InputValidators
    {
        public static short AsShort(string message)
        {
            short number;

            Console.Write(message);
            bool isValid = short.TryParse(Console.ReadLine(), out number);
            while (isValid == false)
            {
                Console.Write("Invalid number! {0}", message);
                isValid = short.TryParse(Console.ReadLine(), out number);
            }

            return number;
        }

        public static int AsInt(string message)
        {
            int number;

            Console.Write(message);
            bool isValid = int.TryParse(Console.ReadLine(), out number);
            while (isValid == false)
            {
                Console.Write("Invalid number! {0}", message);
                isValid = int.TryParse(Console.ReadLine(), out number);
            }

            return number;
        }

        public static uint AsUint(string message)
        {
            uint number;

            Console.Write(message);
            bool isValid = uint.TryParse(Console.ReadLine(), out number);
            while (isValid == false)
            {
                Console.Write("Invalid number! {0}", message);
                isValid = uint.TryParse(Console.ReadLine(), out number);
            }

            return number;
        }

        public static long AsLong(string message)
        {
            long number;

            Console.Write(message);
            bool isValid = long.TryParse(Console.ReadLine(), out number);
            while (isValid == false)
            {
                Console.Write("Invalid number! {0}", message);
                isValid = long.TryParse(Console.ReadLine(), out number);
            }

            return number;
        }

        public static float AsFloat(string message)
        {
            float number;

            Console.Write(message);
            bool isValid = float.TryParse(Console.ReadLine().ToString().Replace(',', '.'), out number);
            while (isValid == false)
            {
                Console.Write("Invalid number! {0}", message);
                isValid = float.TryParse(Console.ReadLine().ToString().Replace(',', '.'), out number);
            }

            return number;
        }

        public static decimal AsDecimal(string message)
        {
            decimal number;

            Console.Write(message);
            bool isValid = decimal.TryParse(Console.ReadLine().ToString().Replace(',', '.'), out number);
            while (isValid == false)
            {
                Console.Write("Invalid number! {0}", message);
                isValid = decimal.TryParse(Console.ReadLine().ToString().Replace(',', '.'), out number);
            }

            return number;
        }
    }
}
