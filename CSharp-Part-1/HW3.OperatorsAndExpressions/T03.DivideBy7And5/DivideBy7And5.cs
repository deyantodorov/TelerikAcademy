namespace T03.DivideBy7And5
{
    using System;

    /// <summary>
    /// 3. Write a Boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 at the same time.
    /// </summary>
    public class DivideBy7And5
    {
        private static void Main()
        {

            int[] values = { 3, 0, 5, 7, 35, 140 };

            IsDividable(values);
        }
        
        private static void IsDividable(int[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] % 7 == 0 && values[i] % 5 == 0)
                {
                    Console.WriteLine("{0} True", values[i]);
                }
                else
                {
                    Console.WriteLine("{0} False", values[i]);
                }
            }
        }
    }
}