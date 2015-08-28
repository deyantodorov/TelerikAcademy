namespace T05.SortStrings
{
    using System;
    using Helper;

    /// <summary>
    /// 5. You are given an array of strings. Write a method that sorts the array by the length of its elements (the number of characters composing them).
    /// </summary>
    public class SortStrings
    {
        private static void Main()
        {
            string[] myArray = { "You", "are", "given", "an", "array", "of", "strings" };

            Console.Write("Input: ");
            Helper.PrintArray<string>(myArray);
            Console.WriteLine();

            Console.Write("DESC: ");
            SortArrayDesc(myArray);
            Helper.PrintArray<string>(myArray);
            Console.WriteLine();

            Console.Write("ASC: ");
            SortArrayAsc(myArray);
            Helper.PrintArray<string>(myArray);
            Console.WriteLine();
        }

        /// <summary>
        /// Ascending sort
        /// </summary>
        private static void SortArrayAsc(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[i].ToString().Length < array[j].ToString().Length)
                    {
                        string temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// Descending sort
        /// </summary>
        private static void SortArrayDesc(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[i].ToString().Length > array[j].ToString().Length)
                    {
                        string temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
    }
}
