namespace T13.ComparingFloats
{
    using System;

    /// <summary>
    /// 13. Write a program that safely compares floating-point numbers (double) with precision eps = 0.000001.
    /// Note: Two floating-point numbers a and b cannot be compared directly by a == b because of the nature of the floating-point arithmetic. Therefore, we assume two numbers are equal if they are more closely to each other than a fixed constant eps.
    /// </summary>
    public class ComparingFloats
    {
        private static void Main()
        {
            double a = 5.3;
            double b = 6.01;
            CompareFloats(a, b);

            a = 5.00000001;
            b = 5.00000003;
            CompareFloats(a, b);

            a = 5.00000005;
            b = 5.00000001;
            CompareFloats(a, b);

            a = -0.0000007;
            b = 0.00000007;
            CompareFloats(a, b);

            a = -4.999999;
            b = -4.999998;
            CompareFloats(a, b);

            a = 4.999999;
            b = 4.999998;
            CompareFloats(a, b);
        }

        private static void CompareFloats(double a, double b)
        {
            double eps = 0.000001f;
            double difference = FindDifference(a, b);
            bool isEqual = difference < eps;

            Console.WriteLine("Value {0} equal to {1} is {2}", a, b, isEqual);
        }

        private static double FindDifference(double a, double b)
        {
            if (b > a)
            {
                return b - a;
            }
            else
            {
                return a - b;
            }
        }
    }
}