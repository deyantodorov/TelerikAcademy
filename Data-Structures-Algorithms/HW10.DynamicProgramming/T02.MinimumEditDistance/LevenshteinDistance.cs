namespace T02.MinimumEditDistance
{
    using System;

    public static class LevenshteinDistance
    {
        public static double Calculate(string startWord, string endWord, Cost cost)
        {
            var d = new double[startWord.Length + 1, endWord.Length + 1];

            for (int i = 0; i <= startWord.Length; i++)
            {
                d[i, 0] = i * cost.Delete;
            }

            for (int j = 0; j <= endWord.Length; j++)
            {
                d[0, j] = j * cost.Insert;
            }

            for (int j = 1; j <= endWord.Length; j++)
            {
                for (int i = 1; i <= startWord.Length; i++)
                {
                    if (startWord[i - 1] == endWord[j - 1])
                    {
                        d[i, j] = d[i - 1, j - 1];
                    }
                    else
                    {
                        d[i, j] = Math.Min(Math.Min(d[i - 1, j] + cost.Delete, d[i, j - 1] + cost.Insert), d[i - 1, j - 1] + cost.Replace);
                    }
                }
            }

            return d[startWord.Length, endWord.Length];
        }
    }
}
