namespace T16.BitExchangeAdvanced
{
    using System;
    using System.Linq;

    /// <summary>
    /// 16. Write a program that exchanges bits {p, p+1, …, p+k-1} with bits {q, q+1, …, q+k-1} of a given 32-bit unsigned integer.
    /// </summary>
    public class BitExchangeAdvanced
    {
        private static void Main()
        {
            uint number = ReadAndValidateInput("Enter number to exchange bits: ");
            byte p = ReadAndValidateByte("Enter value for p: ");
            byte q = ReadAndValidateByte("Enter value for q: ");
            byte k = ReadAndValidateByte("Enter value for k (length): ");

            uint result = SwapBits(p, q, k, number);
            Console.WriteLine(result);
        }

        /// <summary>
        /// Validate input as unsigned integer
        /// </summary>
        private static uint ReadAndValidateInput(string msg)
        {
            uint number;

            Console.Write(msg);

            bool isValid = uint.TryParse(Console.ReadLine(), out number);
            while (isValid == false)
            {
                Console.Write("Invalid number! {0}", msg);
                isValid = uint.TryParse(Console.ReadLine(), out number);
            }

            return number;
        }

        /// <summary>
        /// Validate user input inforamtion as byte and limit numbers to 31, because in uint we have only 31 bits
        /// </summary>
        private static byte ReadAndValidateByte(string msg)
        {
            byte number;

            Console.Write(msg);

            bool isValid = byte.TryParse(Console.ReadLine(), out number);
            while (isValid == false || number > 31)
            {
                Console.Write("Invalid number! {0}", msg);
                isValid = byte.TryParse(Console.ReadLine(), out number);
            }

            return number;
        }

        /// <summary>
        /// Swapping bits method. You could find more information about bit exchange here - http://graphics.stanford.edu/~seander/bithacks.html
        /// </summary>
        private static uint SwapBits(byte position1, byte position2, byte length, uint number)
        {
            uint temp = ((number >> position1) ^ (number >> position2)) & ((1u << length) - 1);
            uint result = number ^ ((temp << position1) | (temp << position2));
            return result;
        }
    }
}