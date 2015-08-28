namespace V4.P1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    ///  http://bgcoder.com/Contests/Practice/Index/221#0
    /// </summary>
    public class Program
    {
        private static void Main()
        {
            string[] words = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (words.Length == 1)
            {
                Console.WriteLine("{0} = {1}", words[0], CalcWordNum(words[0]));
            }
            else
            {
                long sum = 0;

                for (int i = 0; i < words.Length; i++)
                {
                    sum += CalcWordNum(words[i]);
                }

                string base19 = GetStringAs19Base(sum);
                Console.WriteLine("{0} = {1}", base19, sum);
            }
        }

        private static string GetStringAs19Base(long num)
        {
            var sb = new StringBuilder();

            long input = num;
            long rem;

            while (input != 0)
            {
                rem = input % 23;
                sb.Append((char)('a' + (char)rem));
                input /= 23;
            }

            return new string(sb.ToString().ToCharArray().Reverse().ToArray());
        }

        private static long CalcWordNum(string word)
        {
            char[] symbols = word.ToCharArray();
            List<int> numbers = new List<int>();

            for (int i = 0; i < symbols.Length; i++)
            {
                int current = (int)symbols[i] - 'a';
                numbers.Add(current);
            }

            long result = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                long current = numbers[i] * (int)Math.Pow(23, numbers.Count - 1 - i);
                result += current;
            }

            return result;
        }
    }
}