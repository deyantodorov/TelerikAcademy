namespace T05.HashSetImplementation
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MyHashSetTest
    {
        [TestMethod]
        public void TestCreation()
        {
            var hashSet = new MyHashSet<int>();

            Assert.AreEqual(0, hashSet.Count);
        }

        [TestMethod]
        public void TestAdd()
        {
            var hashSet = new MyHashSet<int> { 5, 3, 4 };
            Assert.AreEqual(3, hashSet.Count);
        }

        [TestMethod]
        public void TestClear()
        {
            var hashSet = new MyHashSet<int> { 5, 3, 4 };
            hashSet.Clear();
            Assert.AreEqual(0, hashSet.Count);
        }

        [TestMethod]
        public void TestRemove()
        {
            var hashSet = new MyHashSet<int> { 5, 3, 4 };
            hashSet.Remove(4);

            Assert.IsFalse(hashSet.Contains(4));
        }
    }
}
