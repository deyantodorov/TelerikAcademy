namespace T04.HashTableImplementation
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MyHashTableUnitTest
    {
        [TestMethod]
        public void TestCreation()
        {
            var hashTable = new MyHashTable<string, int>();

            Assert.AreEqual(0, hashTable.Count);
        }

        [TestMethod]
        public void TestAdding()
        {
            var hashTable = new MyHashTable<string, int>
            {
                { "five", 5 },
                { "six", 6 }
            };

            Assert.AreEqual(2, hashTable.Count);
        }

        [TestMethod]
        public void TestFind()
        {
            var hashTable = new MyHashTable<string, int>
            {
                { "five", 5 },
                { "six", 6 }
            };

            Assert.AreEqual(5, hashTable.Find("five"));
        }

        [TestMethod]
        public void TestCount()
        {
            var hashTable = new MyHashTable<string, int>
            {
                { "five", 5 },
                { "six", 6 }
            };

            Assert.AreEqual(2, hashTable.Count);
        }

        [TestMethod]
        public void TestClear()
        {
            var hashTable = new MyHashTable<string, int>
            {
                { "five", 5 },
                { "six", 6 }
            };

            hashTable.Clear();

            Assert.AreEqual(0, hashTable.Count);
        }

        [TestMethod]
        public void TestRemove()
        {
            var hashTable = new MyHashTable<string, int>
            {
                { "five", 5 },
                { "six", 6 }
            };

            hashTable.Remove("five");
            hashTable.Remove("six");

            Assert.AreEqual(0, hashTable.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRemoveShouldThrowException()
        {
            var hashTable = new MyHashTable<string, int>
            {
                { "five", 5 },
                { "six", 6 }
            };

            hashTable.Remove("five");
            hashTable.Remove("six");
            hashTable.Remove("missing");
        }
    }
}
