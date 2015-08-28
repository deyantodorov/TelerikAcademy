namespace T01.ArrayOfIntegers
{
    using System;

    /// <summary>
    /// 1. Write a program that allocates array of 20 integers and initializes each element by its index multiplied by 5. Print the obtained array on the console.
    /// </summary>
    public class ArrayOfIntegers
    {
        private static void Main()
        {
            int[] myArray = new int[20];

            for (int i = 0; i < myArray.Length; i++)
            {
                int element = i * 5;
                myArray[i] = element;
            }

            for (int i = 0; i < myArray.Length; i++)
            {
                Console.WriteLine("Element {0}: {1}", i + 1, myArray[i]);
            }
        }
    }
}
