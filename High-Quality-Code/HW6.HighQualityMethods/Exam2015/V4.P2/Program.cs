namespace V4.P2
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        private static void Main()
        {
            int sequence = int.Parse(Console.ReadLine());

            for (int i = 0; i < sequence; i++)
            {
                string[] line = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                long[] lineNumbers = GetLineNumbers(line);
                long[] absDiff = GetAbsDiff(lineNumbers);
                bool isIncresing = GetIncresingSeq(lineNumbers, absDiff);

                Console.WriteLine(isIncresing ? "True" : "False");
            }
        }

        private static bool GetIncresingSeq(long[] lineNumbers, long[] absDiff)
        {
            long[] absDiffSeq = GetAbsDiff(absDiff);

            for (int i = 0; i < absDiffSeq.Length; i++)
            {
                if (absDiffSeq[i] != 1 && absDiffSeq[i] != 0)
                {
                    return false;
                }
            }

            for (int i = 0; i < absDiff.Length - 1; i++)
            {
                if (absDiff[i] > absDiff[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

        private static long[] GetAbsDiff(long[] lineNumbers)
        {
            List<long> list = new List<long>();

            for (int i = 0; i < lineNumbers.Length - 1; i++)
            {
                list.Add(Math.Abs(lineNumbers[i] - lineNumbers[i + 1]));
            }

            return list.ToArray();
        }

        private static long[] GetLineNumbers(string[] line)
        {
            long[] lineNumbers = new long[line.Length];

            for (int n = 0; n < line.Length; n++)
            {
                lineNumbers[n] = long.Parse(line[n]);
            }

            return lineNumbers;
        }
    }
}