namespace T08.ShortAsBinary
{
    using System;
    using Helper;

    /// <summary>
    /// 8. Write a program that shows the binary representation of given 16-bit signed integer number (the C# type short).
    /// </summary>
    public class ShortAsBinary
    {
        private static void Main()
        {
            short value = InputValidators.AsShort("Enter value: ");
            Console.WriteLine(NumSys.DecToBin(value));
        }
    }
}
