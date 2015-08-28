namespace T03.ComplexMathCompare
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// 3. Write a program to compare the performance of square root, natural logarithm, sinus for float, double and decimal values.
    /// </summary>
    public class TestComplexMath
    {
        private const int Length = 100;

        private static void Main()
        {
            AdditionOperations();
        }

        private static void AdditionOperations()
        {
            Random random = new Random();
            Stopwatch stopwatch = new Stopwatch();

            var floatArray = new float[Length];
            var doubleArray = new double[Length];
            var decimalArray = new decimal[Length];

            for (int i = 0; i < Length; i++)
            {
                var number = random.Next(1, 10000);
                floatArray[i] = number;
                doubleArray[i] = number;
                decimalArray[i] = number;
            }

            var floats = new ExtendFloatOperations(floatArray);
            var doubles = new ExtendDoubleOperations(doubleArray);
            var decimals = new ExtendDecimalOperations(decimalArray);

            // square root
            stopwatch.Start();
            floats.SquareRoot();
            stopwatch.Stop();
            Console.WriteLine("Square root float, time: {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            doubles.Add();
            stopwatch.Stop();
            Console.WriteLine("Square root double, time: {0}", stopwatch.Elapsed);
            stopwatch.Reset();
            
            stopwatch.Start();
            decimals.Add();
            stopwatch.Stop();
            Console.WriteLine("Square root decimal, time: {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            // natural logarithm           
            stopwatch.Start();
            floats.NaturalLogarithm();
            stopwatch.Stop();
            Console.WriteLine("Natural logarithm float result, time: {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            doubles.NaturalLogarithm();
            stopwatch.Stop();
            Console.WriteLine("Natural logarithm double, time: {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            decimals.NaturalLogarithm();
            stopwatch.Stop();
            Console.WriteLine("Natural logarithm decimal, time: {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            // sinus
            stopwatch.Start();
            floats.Sinus();
            stopwatch.Stop();
            Console.WriteLine("Sinus float result, time: {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            doubles.Sinus();
            stopwatch.Stop();
            Console.WriteLine("Sinus double result time: {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            decimals.Sinus();
            stopwatch.Stop();
            Console.WriteLine("Sinus decimal result time: {0}", stopwatch.Elapsed);
            stopwatch.Reset();
        }
    }
}
