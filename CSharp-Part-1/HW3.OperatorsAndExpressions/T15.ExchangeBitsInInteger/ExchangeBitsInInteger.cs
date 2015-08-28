namespace T15.ExchangeBitsInInteger
{
    using System;
    using System.Linq;

    /// <summary>
    /// 15. Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer.
    /// </summary>
    public class ExchangeBitsInInteger
    {
        private static void Main()
        {
            uint number = ReadAndValidateInput("Please, enter 32-bit unsigned integer: ");
            uint swapedNumber;

            if ((number >> 3) != 0 || (number >> 24 != 0))
            {
                swapedNumber = SwapBits(3, 24, number);
                Console.WriteLine(swapedNumber);
            }
            else if ((number >> 4) != 0 || (number >> 25 != 0))
            {
                swapedNumber = SwapBits(4, 25, number);
                Console.WriteLine(swapedNumber);
            }
            else if ((number >> 5) != 0 || (number >> 26 != 0))
            {
                swapedNumber = SwapBits(5, 26, number);
                Console.WriteLine(swapedNumber);
            }
            else
            {
                swapedNumber = number;
                Console.WriteLine("Swapped bits numbers is {0}", swapedNumber);
            }
        }

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

        private static uint SwapBits(byte position1, byte position2, uint number)
        {
            uint temp = ((number >> position1) ^ (number >> position2)) & ((1u << 3) - 1);
            uint result = number ^ ((temp << position1) | (temp << position2));
            return result;
        }
    }
}