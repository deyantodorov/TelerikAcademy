namespace T02.TenRandomValues
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 2. Write a program that generates and prints to the console 10 random values in the range [100, 200].
    /// </summary>
    public class TenRandomValues
    {
        private static void Main()
        {
            Random random = new Random();

            List<int> values = new List<int>();

            // Generate
            for (int i = 0; i < 10; i++)
            {
                values.Add(random.Next(100, 200) + 1);
            }

            // Print
            for (int i = 0; i < values.Count; i++)
            {
                Console.WriteLine("{0,2}. {1}", i + 1, values[i]);
            }
        }
    }
}
