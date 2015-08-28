namespace T02.ReadNumber
{
    using System;
    using Helper;

    /// <summary>
    /// 2. Write a method ReadNumber(int start, int end) that enters an integer number in given range [start…end]. 
    ///    If an invalid number or non-number text is entered, the method should throw an exception. 
    ///    Using this method write a program that enters 10 numbers: a1, a2, … a10, such that 1 greater a1 greater … greater a10 greater 100
    /// </summary>
    public class ReadNumber
    {
        public static void FillPrintArray()
        {
            int[] numbers = new int[10];

            for (int i = 0; i < numbers.Length; i++)
            {
                // Start value depends on previous entered
                int start = int.MinValue;

                if (i == 0)
                {
                    start = i + 2;
                }
                else
                {
                    start = numbers[i - 1] + 1;

                    // Stop because next entered value will be incorrect.
                    if (start >= 99)
                    {
                        return;
                    }
                }

                // End correct value
                int end = 99;
                Console.Write("{0}. Enter value in range from {1} to {2}: ", i + 1, start, end);

                int input = ReadValue(start, end);

                // Test for error. -1 is equal to error.
                if (input == -1)
                {
                    break;
                }
                else
                {
                    numbers[i] = input;
                }
            }

            Console.WriteLine("Array values are: ");
            Arrays.PrintArray<int>(numbers);
        }

        public static int ReadValue(int start, int end)
        {
            try
            {
                int input = int.Parse(Console.ReadLine());

                if (start >= end || start <= 1 || end >= 100 || input < start || input > end)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return input;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Error! Entered value is not in correct range.");
                return -1;
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Error! Value cannot be null.");
                return -1;
            }
            catch (FormatException)
            {
                Console.WriteLine("Error! Invalid number.");
                return -1;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error! Number is too big for Int32. Max number is {0}.", int.MaxValue);
                return -1;
            }
        }

        private static void Main()
        {
            FillPrintArray();
        }
    }
}
