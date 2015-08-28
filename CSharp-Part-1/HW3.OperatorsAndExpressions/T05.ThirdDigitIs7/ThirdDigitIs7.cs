namespace T05.ThirdDigitIs7
{
    using System;

    /// <summary>
    /// 5. Write an expression that checks for given integer if its third digit from right-to-left is 7.
    /// </summary>
    public class ThirdDigitIs7
    {
        private static void Main()
        {
            int[] values = { 5, 701, 9703, 877, 777877, 9999799 };

            TestThirdDigitForSeven(values);
        }

        private static void TestThirdDigitForSeven(int[] values)
        {
            int num;

            for (int i = 0; i < values.Length; i++)
            {
                num = (values[i] / 100) % 10;

                if (num == 7)
                {
                    Console.WriteLine("True {0}", values[i]);
                }
                else
                {
                    Console.WriteLine("False {0}", values[i]);
                }
            }
        }
    }
}