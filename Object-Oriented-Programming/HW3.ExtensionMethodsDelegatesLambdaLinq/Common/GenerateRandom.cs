namespace Common
{
    using System;
    using System.Text;

    public static class GenerateRandom
    {
        private const int SmallLetterA = 97;
        private const int SmallLetterZ = 122;
        private static readonly Random rand = new Random();

        public static string Text(int length)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                sb.Append((char)rand.Next(SmallLetterA, SmallLetterZ));
            }

            return sb.ToString();
        }

        public static int Number(int start, int end)
        {
            return rand.Next(start, end);
        }
    }
}
