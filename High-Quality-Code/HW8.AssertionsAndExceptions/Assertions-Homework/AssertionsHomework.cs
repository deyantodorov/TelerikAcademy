using System;
using System.Diagnostics;

public class AssertionsHomework
{
    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        Debug.Assert(HaveElements(arr.Length), "Array is Empty.");
        Debug.Assert(NotNullOrEmpty(arr), "Array has one element and it's value is null or empty");

        for (int index = 0; index < arr.Length - 1; index++)
        {
            int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
            Swap(ref arr[index], ref arr[minElementIndex]);
        }
    }

    private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        Debug.Assert(startIndex <= endIndex, "startIndex is greater or equal to to endIndex");

        int minElementIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }

        return minElementIndex;
    }

    private static void Swap<T>(ref T x, ref T y)
    {
        T oldX = x;
        x = y;
        y = oldX;
    }

    public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    {
        Debug.Assert(HaveElements(arr.Length), "Array is Empty.");
        Debug.Assert(NotNullOrEmpty(arr), "Array has one element and it's value is null or empty");

        return BinarySearch(arr, value, 0, arr.Length - 1);
    }

    private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        Debug.Assert(startIndex <= endIndex, "startIndex is greater or equal to to endIndex");

        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            if (arr[midIndex].Equals(value))
            {
                return midIndex;
            }

            if (arr[midIndex].CompareTo(value) < 0)
            {
                // Search on the right half
                startIndex = midIndex + 1;
            }
            else
            {
                // Search on the right half
                endIndex = midIndex - 1;
            }
        }

        // Searched value not found
        return -1;
    }

    private static bool HaveElements(int length)
    {
        bool isEmpty = length > 0;
        return isEmpty;
    }

    private static bool NotNullOrEmpty<T>(T[] arr) where T : IComparable<T>
    {
        bool nullOrEmpty = true;

        if (arr.Length == 1 && (arr[0] == null || (arr[0].CompareTo(default(T)) == 0)))
        {
            nullOrEmpty = false;
        }

        return nullOrEmpty;
    }

    private static void Main()
    {
        int[] arr = { 3, -1, 15, 4, 17, 2, 33, 0 };
        var letters = new char[] { 'w', 'z', 'a', 'f', 'd', 'g', 's', 'w', 'e', 'r', 't', 'l' };

        Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
        Console.WriteLine("letters = [{0}]", string.Join(", ", letters));

        SelectionSort(arr);
        SelectionSort(letters);

        Console.WriteLine("arr sorted = [{0}]", string.Join(", ", arr));
        Console.WriteLine("letters sorted = [{0}]", string.Join(", ", letters));

        // Uncomment to see Assertion errors
        // SelectionSort(new int[0]); // Test sorting empty array
        // SelectionSort(new int[1]); // Test sorting single element array

        Console.WriteLine(BinarySearch(arr, -1000));
        Console.WriteLine(BinarySearch(arr, 0));
        Console.WriteLine(BinarySearch(arr, 17));
        Console.WriteLine(BinarySearch(arr, 10));
        Console.WriteLine(BinarySearch(arr, 1000));

        // Uncomment to see Assertion errors
        // Console.WriteLine("");
        // Console.WriteLine(BinarySearch(new int[0], default(int)));
    }
}
