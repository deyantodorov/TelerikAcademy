namespace T02.ReverseString
{
    using System;
    using System.Diagnostics;
    using System.Text;

    /// <summary>
    /// 2. Write a program that reads a string, reverses it and prints the result at the console.
    ///    Example: "sample" -> "elpmas".
    /// </summary>
    public class ReverseString
    {
        public static string ReverseSB(string text)
        {
            StringBuilder result = new StringBuilder();

            for (int i = text.Length - 1; i >= 0; i--)
            {
                result.Append(text[i]);
            }

            return result.ToString();
        }

        public static string ReverseArray(string text)
        {
            char[] myArr = text.ToCharArray();

            Array.Reverse(myArr);

            return new string(myArr);
        }

        public static string ReverseXor(string text)
        {
            char[] myArr = text.ToCharArray();
            int length = text.Length - 1;

            for (int i = 0; i < length; i++, length--)
            {
                myArr[i] ^= myArr[length];
                myArr[length] ^= myArr[i];
                myArr[i] ^= myArr[length];
            }

            return new string(myArr);
        }

        private static void Main()
        {
            // Testing different type of reverse algorithms
            Stopwatch timeTest = new Stopwatch();

            Console.Write("Enter some string: ");
            string str = Console.ReadLine();

            // Using StringBuilder
            timeTest.Start();
            string reversed = ReverseSB(str);
            timeTest.Stop();
            Console.WriteLine("Reverse text: {0}\ntime: {1} - StringBuilder class", reversed, timeTest.Elapsed);
            timeTest.Reset();

            Console.WriteLine();

            // Using Array.Reverse
            timeTest.Start();
            string reversedArrayReverse = ReverseArray(str);
            timeTest.Stop();
            Console.WriteLine("Reverse text: {0}\ntime: {1} - Array.Reverse", reversedArrayReverse, timeTest.Elapsed);
            timeTest.Reset();

            Console.WriteLine();

            // Using XOR
            timeTest.Start();
            string reversedXor = ReverseXor(str);
            timeTest.Stop();
            Console.WriteLine("Reverse text: {0}\ntime: {1} - XOR", reversedXor, timeTest.Elapsed);
            timeTest.Reset();
        }
    }
}
