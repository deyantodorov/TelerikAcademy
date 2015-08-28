namespace T14.Calculator
{
    using System;

    /// <summary>
    /// 14. Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers. Use variable number of arguments.
    /// </summary>
    public class Calculator
    {
        private static void Main()
        {
            decimal min = CalcMin(1, 4, 1, 3, 2, 35, 1, 22, 11, -12, -1);
            Console.WriteLine("Minimum is: {0}", min);

            decimal max = CalcMax(1, 4, 1, 3, 2, 35, 1, 22, 11, -12, -1);
            Console.WriteLine("Maximum is: {0}", max);

            decimal avg = CalcAvg(1, 4, 1, 3, 2, 35, 1, 22, 11, -12, -1);
            Console.WriteLine("Average is: {0}", avg);

            decimal sum = CalcSum(1, 4, 1, 3, 2, 35, 1, 22, 11, -12, -1);
            Console.WriteLine("Sum is: {0}", sum);

            decimal product = CalcProduct(1, 4, 1, 3, 2, 35, 1, 22, 11, -12, -1);
            Console.WriteLine("Product is: {0}", product);
        }

        private static decimal CalcMin(params int[] array)
        {
            Array.Sort(array);
            decimal result = array[0];
            return result;
        }
        
        private static decimal CalcMax(params int[] array)
        {
            Array.Sort(array);
            decimal result = array[array.Length - 1];
            return result;
        }
        
        private static decimal CalcAvg(params int[] array)
        {
            decimal result = 0;
            
            for (int i = 0; i < array.Length; i++)
            {
                result += array[i];
            }

            result = result / array.Length;
            return result;
        }

        private static decimal CalcSum(params int[] array)
        {
            decimal result = 0;
            
            for (int i = 0; i < array.Length; i++)
            {
                result += array[i];
            }

            return result;
        }

        private static decimal CalcProduct(params int[] array)
        {
            decimal result = 1;
            
            for (int i = 0; i < array.Length; i++)
            {
                result *= array[i];
            }

            return result;
        }
    }
}
