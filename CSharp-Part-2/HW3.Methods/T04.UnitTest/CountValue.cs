namespace T04.UnitTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CountValue
    {
        [TestMethod]
        public void TestMethodForInt()
        {
            Random rand = new Random();

            int[] array = new int[rand.Next(2, 100)];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(5, 1000);
            }

            T04.CountValue.CountValue.Count<int>(array, 2);
        }

        [TestMethod]
        public void TestMethodForString()
        {
            string[] array = { "as", "asd", "fdf", "as", "dfd", "jkj", "as" };
            T04.CountValue.CountValue.Count<string>(array, "as");
        }
    }
}
