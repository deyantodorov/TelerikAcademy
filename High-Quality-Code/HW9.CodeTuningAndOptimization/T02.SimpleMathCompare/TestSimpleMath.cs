namespace T02.SimpleMathCompare
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// 2. Write a program to compare the performance of add, subtract, increment, multiply, divide for int, long, float, double and decimal values.
    ///    Author comment: I didn't find nice way to use generic class for numbers operations.
    /// </summary>
    public class TestSimpleMath
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

            var intArray = new int[Length];
            var longArray = new long[Length];
            var floatArray = new float[Length];
            var doubleArray = new double[Length];
            var decimalArray = new decimal[Length];

            for (int i = 0; i < Length; i++)
            {
                var number = random.Next(1, 10000);

                intArray[i] = number;
                longArray[i] = number;
                floatArray[i] = number;
                doubleArray[i] = number;
                decimalArray[i] = number;
            }

            var ints = new IntOperations(intArray);
            var longs = new LongOperations(longArray);
            var floats = new FloatOperations(floatArray);
            var doubles = new DoubleOperations(doubleArray);
            var decimals = new DecimalOperations(decimalArray);

            // add
            stopwatch.Start();
            var addAsInt = ints.Add();
            stopwatch.Stop();
            Console.WriteLine("Add int result: {0}, time: {1}", addAsInt, stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            var addAsLong = longs.Add();
            stopwatch.Stop();
            Console.WriteLine("Add long result: {0}, time: {1}", addAsLong, stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            var addAsFloat = floats.Add();
            stopwatch.Stop();
            Console.WriteLine("Add float result: {0}, time: {1}", addAsFloat, stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            var addAsDouble = doubles.Add();
            stopwatch.Stop();
            Console.WriteLine("Add double result: {0}, time: {1}", addAsDouble, stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            var addAsDecimal = decimals.Add();
            stopwatch.Stop();
            Console.WriteLine("Add decimal result: {0}, time: {1}", addAsDecimal, stopwatch.Elapsed);
            stopwatch.Reset();

            // subtract
            Console.WriteLine();
            stopwatch.Start();
            addAsInt = ints.Subtract();
            stopwatch.Stop();
            Console.WriteLine("Subtract int result: {0}, time: {1}", addAsInt, stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            addAsLong = longs.Subtract();
            stopwatch.Stop();
            Console.WriteLine("Subtract long result: {0}, time: {1}", addAsLong, stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            addAsFloat = floats.Subtract();
            stopwatch.Stop();
            Console.WriteLine("Subtract float result: {0}, time: {1}", addAsFloat, stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            addAsDouble = doubles.Subtract();
            stopwatch.Stop();
            Console.WriteLine("Subtract double result: {0}, time: {1}", addAsDouble, stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            addAsDecimal = decimals.Subtract();
            stopwatch.Stop();
            Console.WriteLine("Subtract decimal result: {0}, time: {1}", addAsDecimal, stopwatch.Elapsed);
            stopwatch.Reset();

            // increment
            Console.WriteLine();
            stopwatch.Start();
            addAsInt = ints.Increment();
            stopwatch.Stop();
            Console.WriteLine("Increment int result: {0}, time: {1}", addAsInt, stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            addAsLong = longs.Increment();
            stopwatch.Stop();
            Console.WriteLine("Increment long result: {0}, time: {1}", addAsLong, stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            addAsFloat = floats.Increment();
            stopwatch.Stop();
            Console.WriteLine("Increment float result: {0}, time: {1}", addAsFloat, stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            addAsDouble = doubles.Increment();
            stopwatch.Stop();
            Console.WriteLine("Increment double result: {0}, time: {1}", addAsDouble, stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            addAsDecimal = decimals.Increment();
            stopwatch.Stop();
            Console.WriteLine("Increment decimal result: {0}, time: {1}", addAsDecimal, stopwatch.Elapsed);
            stopwatch.Reset();

            // multiply
            Console.WriteLine();
            stopwatch.Start();
            addAsInt = ints.Multiply();
            stopwatch.Stop();
            Console.WriteLine("Multiply int result: {0}, time: {1}", addAsInt, stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            addAsLong = longs.Multiply();
            stopwatch.Stop();
            Console.WriteLine("Multiply long result: {0}, time: {1}", addAsLong, stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            addAsFloat = floats.Multiply();
            stopwatch.Stop();
            Console.WriteLine("Multiply float result: {0}, time: {1}", addAsFloat, stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            addAsDouble = doubles.Multiply();
            stopwatch.Stop();
            Console.WriteLine("Multiply double result: {0}, time: {1}", addAsDouble, stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            addAsDecimal = decimals.Multiply();
            stopwatch.Stop();
            Console.WriteLine("Multiply decimal result: {0}, time: {1}", addAsDecimal, stopwatch.Elapsed);
            stopwatch.Reset();

            // divide
            Console.WriteLine();
            stopwatch.Start();
            addAsInt = ints.Divide();
            stopwatch.Stop();
            Console.WriteLine("Divide int result: {0}, time: {1}", addAsInt, stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            addAsLong = longs.Divide();
            stopwatch.Stop();
            Console.WriteLine("Divide long result: {0}, time: {1}", addAsLong, stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            addAsFloat = floats.Divide();
            stopwatch.Stop();
            Console.WriteLine("Divide float result: {0}, time: {1}", addAsFloat, stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            addAsDouble = doubles.Divide();
            stopwatch.Stop();
            Console.WriteLine("Divide double result: {0}, time: {1}", addAsDouble, stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            addAsDecimal = decimals.Divide();
            stopwatch.Stop();
            Console.WriteLine("Divide decimal result: {0}, time: {1}", addAsDecimal, stopwatch.Elapsed);
            stopwatch.Reset();
        }
    }
}
