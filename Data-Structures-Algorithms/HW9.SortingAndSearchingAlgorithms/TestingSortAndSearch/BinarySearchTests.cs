using HW9.SortingAndSearchingAlgorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestingSortAndSearch
{
    [TestClass]
    public class BinarySearchTests
    {
        [TestMethod]
        public void SearchNonExistingItemTest()
        {
            int[] items = new int[]
            { 
                15, 125, 125, -1512, 16, 9823, -235, -32592, 
                -2358239, -9235, 9876253, 237568, 829356289, 
                56253, 11, 5252, 3435, 9012797, 12486124, 667
            };
            SortableCollection<int> collection = new SortableCollection<int>(items);

            bool isFound = collection.BinarySearch(111);

            Assert.IsFalse(isFound);
        }
    }
}
