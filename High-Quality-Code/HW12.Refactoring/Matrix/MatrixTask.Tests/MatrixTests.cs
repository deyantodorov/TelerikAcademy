namespace MatrixTask.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class MatrixTests
    {
        [TestCase(6, "  1 16 17 18 19 20\r\n 15  2 27 28 29 21\r\n 14 31  3 26 30 22\r\n 13 36 32  4 25 23\r\n 12 35 34 33  5 24\r\n 11 10  9  8  7  6\r\n")]
        [TestCase(5, "  1 13 14 15 16\r\n 12  2 21 22 17\r\n 11 23  3 20 18\r\n 10 25 24  4 19\r\n  9  8  7  6  5\r\n")]
        [TestCase(3, "  1  7  8\r\n  6  2  9\r\n  5  4  3\r\n")]
        public void TestWithNumber(int size, string test)
        {
            var matrix = new Matrix(size);
            var result = matrix.Walk();

            Assert.AreEqual(test, result, "Both matrix are different");
        }
    }
}
