namespace T09.PrintASequence
{
    using System;

    /// <summary>
    /// 9. Write a program that prints the first 10 members of the sequence: 2, -3, 4, -5, 6, -7, ...
    /// </summary>
    public class PrintASequence
    {
        private static void Main()
        {
            int start = 2;

            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write("{0}, ", start);
                }
                else
                {
                    if (i == 9)
                    {
                        Console.Write("-{0}", start);
                    }
                    else
                    {
                        Console.Write("-{0}, ", start);
                    }
                }

                start++;
            }

            Console.WriteLine();
        }
    }
}
