namespace T01.DeclareVariables
{
    using System;

    /// <summary>
    /// 1. Declare five variables choosing for each of them the most appropriate of the types byte, sbyte, short, ushort, int, uint, long, ulong to represent the following 
    ///    values: 52130, -115, 4825932, 97, -10000.
    /// </summary>
    public class DeclareVariables
    {
        private static void Main()
        {
            ushort firstValue = 52130;
            sbyte secondValue = -115;
            uint thirdValue = 4825932;
            byte fouthValue = 97;
            short fifthValue = -10000;

            Console.WriteLine(firstValue);
            Console.WriteLine(secondValue);
            Console.WriteLine(thirdValue);
            Console.WriteLine(fouthValue);
            Console.WriteLine(fifthValue);
        }
    }
}