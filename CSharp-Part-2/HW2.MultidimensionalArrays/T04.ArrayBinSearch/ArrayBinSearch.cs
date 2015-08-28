namespace T04.ArrayBinSearch
{
    using System;
    using Helper;

    /// <summary>
    /// 4. Write a program, that reads from the console an array of N integers and an integer K, sorts the array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K. 
    /// </summary>
    public class ArrayBinSearch
    {
        private static void Main()
        {
            // Read values and initialize array
            int n = Helper.ValidateInputAsInt("N (array length): ");
            int k = Helper.ValidateInputAsInt("K (value looking for): ");

            int[] myArray = new int[n];

            for (int c = 0; c < myArray.Length; c++)
            {
                myArray[c] = Helper.ValidateInputAsInt("Value: ");
            }

            /*
            // Quick testing
            int n = 3;
            int k = 10;
            int[] myArray = { 0, -2, -4, 0, -9, 5, 7, 1, 3, 3, 2, 1, 1, 3, 9, 8, 5, 6, 4, 6, 7, 9, 1, 0 };
            */

            Console.WriteLine();
            Console.WriteLine("Print initial values: ");
            Helper.PrintArray<int>(myArray);
            Console.WriteLine();

            // Sort array and BinarySearch
            Array.Sort(myArray);
            Console.WriteLine("Show sorted array: ");
            Helper.PrintArray<int>(myArray);
            Console.WriteLine();

            int result = Array.BinarySearch(myArray, k);

            if (result < 0)
            {
                result = ~result;

                if (result == 0)
                {
                    Console.WriteLine("No value <= K");
                }
                else if (result > 0)
                {
                    Console.WriteLine("Searched value {0} not found. Smaller value is found {1}", k, myArray[result - 1]);
                }
                else
                {
                    Console.WriteLine("Searched value {0} not found. Smaller value is found {1}", k, myArray[result]);
                }
            }
            else
            {
                Console.WriteLine("Searched value {0} found!", myArray[result]);
            }
        }
    }
}
