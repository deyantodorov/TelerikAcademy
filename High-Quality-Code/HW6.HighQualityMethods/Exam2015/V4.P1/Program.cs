namespace V4.P1
{
    using System;
    using System.Linq;
    using System.Numerics;
    using System.Text;

    /// <summary>
    ///  http://bgcoder.com/Contests/Practice/Index/223#0
    /// </summary>
    public class Program
    {
        private static void Main()
        {
            var input = Console.ReadLine().Split(' ');

            foreach (string base26 in input.Select(ConvertToBase26))
            {
                Console.Write(base26 + " ");
            }
        }

        private static string ConvertToBase26(string base21)
        {
            BigInteger base21Number = GetBase21(base21);

            string base26 = GetBase26(base21Number);

            return base26;
        }

        private static string GetBase26(BigInteger base21Number)
        {
            StringBuilder sb = new StringBuilder();

            BigInteger input = base21Number;

            while (input != 0)
            {
                BigInteger rem = input % 26;
                sb.Append((char)('a' + (char)rem));
                input /= 26;
            }

            return new string(sb.ToString().ToCharArray().Reverse().ToArray());
        }

        private static BigInteger GetBase21(string base21)
        {
            BigInteger sum = 0;
            long pow = base21.Length - 1;

            foreach (BigInteger tmp in base21.Select(symbol => (symbol - 'a') * Step(21, pow)))
            {
                sum += tmp;
                pow--;
            }

            return sum;
        }

        private static BigInteger Step(int numBase, long power)
        {
            switch (power)
            {
                case 0:
                    return 1;
                case 1:
                    return numBase;
            }

            BigInteger result = numBase;

            for (int i = 0; i < power - 1; i++)
            {
                result *= numBase;
            }

            return result;
        }
    }
}