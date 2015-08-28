namespace T03.VariableInHexadecimalFormat
{
    using System;

    /// <summary>
    /// 3. Declare an integer variable and assign it with the value 254 in hexadecimal format (0x##). 
    ///    Use Windows Calculator to find its hexadecimal representation. Print the variable and ensure that the result is 254.
    /// </summary>
    public class VariableInHexadecimalFormat
    {
        private static void Main()
        {
            int hex = 0xFE;
            Console.WriteLine("254 decimal in hexidecimal is {0:X}", hex); 
        }
    }
}