namespace T02.ArraysCompare
{
    using System;
    using Helper;

    /// <summary>
    /// 2. Write a program that reads two arrays from the console and compares them element by element.
    /// </summary>
    public class ArraysCompare
    {
        private static void Main()
        {
            int firstArraySize = Helper.ValidateInputAsInt("Enter first array size: ");
            int secondArraySize = Helper.ValidateInputAsInt("Enter second array size: ");

            if (firstArraySize == secondArraySize)
            {
                string[] firstArray = new string[firstArraySize];
                string[] secondArray = new string[secondArraySize];

                for (int index = 0; index < firstArray.Length; index++)
                {
                    Console.Write("First array value: ");
                    firstArray[index] = Console.ReadLine();

                    Console.Write("Second array value: ");
                    secondArray[index] = Console.ReadLine();
                }

                bool isEqual = true;

                for (int index = 0; index < firstArray.Length; index++)
                {
                    if (!object.Equals(firstArray[index], secondArray[index]))
                    {
                        isEqual = false;
                        break;
                    }
                }

                if (!isEqual)
                {
                    Console.WriteLine("Both arrays are different!");
                }
                else
                {
                    Console.WriteLine("Both arrays are the same!");
                }
            }
            else
            {
                Console.WriteLine("Both arrays are different!");
            }
        }
    }
}
