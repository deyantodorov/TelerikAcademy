namespace T04.SortingPerformance
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// 4. * Write a program to compare the performance of insertion sort, selection sort, quicksort for int, double and string values. 
    /// Check also the following cases: random values, sorted values, values sorted in reversed order.
    /// </summary>
    public class MainProgram
    {
        private const int MaxLength = 100;

        private static void Main()
        {
            var intArray = GenerateRandomIntegerValues();
            var doubleArray = GenerateRandomDoubleValues();
            var stringArray = GenerateRandomStringValues();

            Console.WriteLine(Environment.NewLine + "SELECTION SORT" + Environment.NewLine);
            TestSelectionSort(intArray, doubleArray, stringArray);
            Console.WriteLine(Environment.NewLine + "QUICK SORT" + Environment.NewLine);
            TestingQuckSort(intArray, doubleArray, stringArray);
            Console.WriteLine(Environment.NewLine + "INSERTION SORT" + Environment.NewLine);
            TestingInsertionSort(intArray, doubleArray, stringArray);
        }

        private static void TestingInsertionSort(int[] intArray, double[] doubleArray, string[] stringArray)
        {
            Stopwatch stopwatch = new Stopwatch();

            // Test Quick Sort Sort - Random values
            stopwatch.Start();
            Sort.InsertionSort<int>(intArray);
            stopwatch.Stop();
            Console.WriteLine("Time random int values: " + stopwatch.Elapsed);
            stopwatch.Reset();
            // Print<int>(intArray);

            stopwatch.Start();
            Sort.InsertionSort<double>(doubleArray);
            stopwatch.Stop();
            Console.WriteLine("Time random double values: " + stopwatch.Elapsed);
            stopwatch.Reset();
            // Print<double>(doubleArray);

            stopwatch.Start();
            Sort.InsertionSort<string>(stringArray);
            stopwatch.Stop();
            Console.WriteLine("Time random string values: " + stopwatch.Elapsed);
            stopwatch.Reset();
            // Print<string>(stringArray);

            // Sorted values
            Array.Sort(intArray);
            Array.Sort(doubleArray);
            Array.Sort(stringArray);

            stopwatch.Start();
            Sort.InsertionSort<int>(intArray);
            stopwatch.Stop();
            Console.WriteLine("Time sorted int values: " + stopwatch.Elapsed);
            stopwatch.Reset();
            // Print<int>(intArray);

            stopwatch.Start();
            Sort.InsertionSort<double>(doubleArray);
            stopwatch.Stop();
            Console.WriteLine("Time sorted double values: " + stopwatch.Elapsed);
            stopwatch.Reset();
            // Print<double>(doubleArray);

            stopwatch.Start();
            Sort.InsertionSort<string>(stringArray);
            stopwatch.Stop();
            Console.WriteLine("Time sorted string values: " + stopwatch.Elapsed);
            stopwatch.Reset();
            // Print<string>(stringArray);

            // Reverse values
            Array.Reverse(intArray);
            Array.Reverse(doubleArray);
            Array.Reverse(stringArray);

            stopwatch.Start();
            Sort.InsertionSort<int>(intArray);
            stopwatch.Stop();
            Console.WriteLine("Time reversed int values: " + stopwatch.Elapsed);
            stopwatch.Reset();
            // Print<int>(intArray);

            stopwatch.Start();
            Sort.InsertionSort<double>(doubleArray);
            stopwatch.Stop();
            Console.WriteLine("Time reversed double values: " + stopwatch.Elapsed);
            stopwatch.Reset();
            // Print<double>(doubleArray);

            stopwatch.Start();
            Sort.InsertionSort<string>(stringArray);
            stopwatch.Stop();
            Console.WriteLine("Time reversed string values: " + stopwatch.Elapsed);
            stopwatch.Reset();
            // Print<string>(stringArray);
        }

        private static void TestingQuckSort(int[] intArray, double[] doubleArray, string[] stringArray)
        {
            Stopwatch stopwatch = new Stopwatch();

            // Test Quick Sort Sort - Random values
            stopwatch.Start();
            Sort.QuickSort<int>(intArray, 0, intArray.Length - 1);
            stopwatch.Stop();
            Console.WriteLine("Time random int values: " + stopwatch.Elapsed);
            stopwatch.Reset();
            // Print<int>(intArray);

            stopwatch.Start();
            Sort.QuickSort<double>(doubleArray, 0, doubleArray.Length - 1);
            stopwatch.Stop();
            Console.WriteLine("Time random double values: " + stopwatch.Elapsed);
            stopwatch.Reset();
            // Print<double>(doubleArray);

            stopwatch.Start();
            Sort.QuickSort<string>(stringArray, 0, stringArray.Length - 1);
            stopwatch.Stop();
            Console.WriteLine("Time random string values: " + stopwatch.Elapsed);
            stopwatch.Reset();
            // Print<string>(stringArray);

            // Sorted values
            Array.Sort(intArray);
            Array.Sort(doubleArray);
            Array.Sort(stringArray);

            stopwatch.Start();
            Sort.QuickSort<int>(intArray, 0, intArray.Length - 1);
            stopwatch.Stop();
            Console.WriteLine("Time sorted int values: " + stopwatch.Elapsed);
            stopwatch.Reset();
            // Print<int>(intArray);

            stopwatch.Start();
            Sort.QuickSort<double>(doubleArray, 0, doubleArray.Length - 1);
            stopwatch.Stop();
            Console.WriteLine("Time sorted double values: " + stopwatch.Elapsed);
            stopwatch.Reset();
            // Print<double>(doubleArray);

            stopwatch.Start();
            Sort.QuickSort<string>(stringArray, 0, stringArray.Length - 1);
            stopwatch.Stop();
            Console.WriteLine("Time sorted string values: " + stopwatch.Elapsed);
            stopwatch.Reset();
            // Print<string>(stringArray);

            // Reverse values
            Array.Reverse(intArray);
            Array.Reverse(doubleArray);
            Array.Reverse(stringArray);

            stopwatch.Start();
            Sort.QuickSort<int>(intArray, 0, intArray.Length - 1);
            stopwatch.Stop();
            Console.WriteLine("Time reversed int values: " + stopwatch.Elapsed);
            stopwatch.Reset();
            // Print<int>(intArray);

            stopwatch.Start();
            Sort.QuickSort<double>(doubleArray, 0, doubleArray.Length - 1);
            stopwatch.Stop();
            Console.WriteLine("Time reversed double values: " + stopwatch.Elapsed);
            stopwatch.Reset();
            // Print<double>(doubleArray);

            stopwatch.Start();
            Sort.QuickSort<string>(stringArray, 0, stringArray.Length - 1);
            stopwatch.Stop();
            Console.WriteLine("Time reversed string values: " + stopwatch.Elapsed);
            stopwatch.Reset();
            // Print<string>(stringArray);
        }

        private static void TestSelectionSort(int[] intArray, double[] doubleArray, string[] stringArray)
        {
            Stopwatch stopwatch = new Stopwatch();

            // Test Selection Sort - Random values
            stopwatch.Start();
            var sortingInt = Sort.SelectionSort<int>(intArray);
            stopwatch.Stop();
            Console.WriteLine("Time random int values: " + stopwatch.Elapsed);
            stopwatch.Reset();
            // Print<int>(sortingInt);

            stopwatch.Start();
            var sortingDouble = Sort.SelectionSort<double>(doubleArray);
            stopwatch.Stop();
            Console.WriteLine("Time random double values: " + stopwatch.Elapsed);
            stopwatch.Reset();
            // Print<double>(sortingDouble);

            stopwatch.Start();
            var sortingString = Sort.SelectionSort<string>(stringArray);
            stopwatch.Stop();
            Console.WriteLine("Time random string values: " + stopwatch.Elapsed);
            stopwatch.Reset();
            // Print<string>(sortingString);

            // Sorted values
            Array.Sort(sortingInt);
            Array.Sort(sortingDouble);
            Array.Sort(sortingString);

            stopwatch.Start();
            sortingInt = Sort.SelectionSort<int>(intArray);
            stopwatch.Stop();
            Console.WriteLine("Time sorted int values: " + stopwatch.Elapsed);
            stopwatch.Reset();
            // Print<int>(sortingInt);

            stopwatch.Start();
            sortingDouble = Sort.SelectionSort<double>(doubleArray);
            stopwatch.Stop();
            Console.WriteLine("Time sorted double values: " + stopwatch.Elapsed);
            stopwatch.Reset();
            // Print<double>(sortingDouble);

            stopwatch.Start();
            sortingString = Sort.SelectionSort<string>(stringArray);
            stopwatch.Stop();
            Console.WriteLine("Time sorted string values: " + stopwatch.Elapsed);
            stopwatch.Reset();
            // Print<string>(sortingString);

            // Reverse values
            Array.Reverse(sortingInt);
            Array.Reverse(sortingDouble);
            Array.Reverse(sortingString);

            stopwatch.Start();
            sortingInt = Sort.SelectionSort<int>(intArray);
            stopwatch.Stop();
            Console.WriteLine("Time reversed int values: " + stopwatch.Elapsed);
            stopwatch.Reset();
            // Print<int>(sortingInt);

            stopwatch.Start();
            sortingDouble = Sort.SelectionSort<double>(doubleArray);
            stopwatch.Stop();
            Console.WriteLine("Time reversed double values: " + stopwatch.Elapsed);
            stopwatch.Reset();
            // Print<double>(sortingDouble);

            stopwatch.Start();
            sortingString = Sort.SelectionSort<string>(stringArray);
            stopwatch.Stop();
            Console.WriteLine("Time reversed string values: " + stopwatch.Elapsed);
            stopwatch.Reset();
            // Print<string>(sortingString);
        }

        private static int[] GenerateRandomIntegerValues()
        {
            Random random = new Random();

            var array = new int[MaxLength];

            for (int i = 0; i < array.Length; i++)
            {
                var number = random.Next(1, 10000);
                array[i] = number;
            }

            return array;
        }

        private static double[] GenerateRandomDoubleValues()
        {
            Random random = new Random();

            var array = new double[MaxLength];

            for (int i = 0; i < array.Length; i++)
            {
                var number = random.Next(1, 10000) * 0.12345;
                array[i] = number;
            }

            return array;
        }

        private static string[] GenerateRandomStringValues()
        {
            Random random = new Random();

            var array = new string[MaxLength];

            for (int i = 0; i < array.Length; i++)
            {
                var number = random.Next(1, 26);
                array[i] = GenerateRandomString(number);
            }

            return array;
        }

        private static string GenerateRandomString(int length)
        {
            var result = new char[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = (char)(97 + length);
            }

            return new string(result);
        }

        private static void Print<T>(T[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
            Console.WriteLine(new string('-', 50));
        }
    }
}
