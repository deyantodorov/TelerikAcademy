namespace T02.Max
{
    using System;
    using Helper;

    /// <summary>
    /// 2. Write a method GetMax() with two parameters that returns the bigger of two integers. 
    ///    Write a program that reads 3 integers from the console and prints the biggest of them using the method GetMax().
    /// </summary>
    public class Max
    {
        private static void Main()
        {
            int first = Helper.ValidateInputAsInt("Enter first value: ");
            int second = Helper.ValidateInputAsInt("Enter second value: ");
            int third = Helper.ValidateInputAsInt("Enter third value: ");

            Console.WriteLine("Max number is: {0}", GetMax(GetMax(first, second), third));

            GetMax(first, second);
        }

        private static int GetMax(int first, int second)
        {
            if (first > second)
            {
                return first;
            }
            else
            {
                return second;
            }
        }
    }
}
