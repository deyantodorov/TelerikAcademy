namespace P5.Task5
{
    using System;
    using System.Linq;

    public class Task5
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int s = int.Parse(Console.ReadLine());
            int counter = 0;

            string nBits = GetRight5(n);

            for (int i = 0; i < s; i++)
            {
                int number = int.Parse(Console.ReadLine());
                string numberToString = GetBits(number);

                for (int bit = 0; bit < numberToString.Length - 4; bit++)
                {
                    string sliced = numberToString.Substring(bit, 5);

                    if (nBits == sliced)
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }

        private static string GetBits(int number)
        {
            var result = Convert.ToString(number, 2).PadLeft(29, '0');
            return result;
        }

        private static string GetRight5(int p)
        {
            var result = Convert.ToString(p, 2).PadLeft(5, '0');
            return result;
        }
    }
}