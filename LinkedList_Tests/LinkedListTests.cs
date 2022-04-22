using LinkedList;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinkedList_Tests
{
    public class Tests
    {
        [Test]
        public void insertionTest()
        {
            MyLinkedList<String> actual = new MyLinkedList<string>();
            Assert.AreEqual(actual.Count, 0);

            List<String> expected = new List<string>(new[] { "A", "B", "C" });

            foreach (var item in expected)
                actual.Add(item);

            Assert.AreEqual(3, actual.Count);
            CollectionAssert.AreEqual(getList(actual), expected);
        }

        [Test]
        public void deletionTest()
        {
            MyLinkedList<String> actual = new MyLinkedList<string>();

            string[] expected = new string[] { "A", "B", "C", "D", "E" };

            foreach (var item in expected)
                actual.Add(item);

            Assert.True(actual.Remove(expected[0]));
            Assert.AreEqual(4, actual.Count);
            CollectionAssert.AreEqual(getList(actual), (new string[] { expected[1], expected[2], expected[3], expected[4] }).ToList());

            Assert.True(actual.Remove(expected[4]));
            Assert.AreEqual(3, actual.Count);
            CollectionAssert.AreEqual(getList(actual), (new string[] { expected[1], expected[2], expected[3] }).ToList());

            Assert.True(actual.Remove(expected[2]));
            Assert.AreEqual(2, actual.Count);
            CollectionAssert.AreEqual(getList(actual), (new string[] { expected[1], expected[3] }).ToList());

            Assert.False(actual.Remove("F"));

            actual.Add(expected[0]);
            actual.Add(expected[0]);
            Assert.AreEqual(4, actual.Count);

            Assert.True(actual.Remove(expected[0]));
            Assert.AreEqual(3, actual.Count);
            CollectionAssert.AreEquivalent(getList(actual), (new string[] { expected[0], expected[1], expected[3] }).ToList());

            Assert.True(actual.Remove(expected[0]));
            Assert.AreEqual(2, actual.Count);
            CollectionAssert.AreEqual(getList(actual), (new string[] { expected[1], expected[3] }).ToList());
        }

        [Test]
        public void copyingTest()
        {
            MyLinkedList<String> actualList = new MyLinkedList<string>();

            string[] actualArr = new string[5];
            string[] expected = new string[] { "A", "B", "C", "D", "E" };

            foreach (var item in expected)
                actualList.Add(item);

            actualList.CopyTo(actualArr, 0);
            Assert.AreEqual(actualArr, expected);

            string[] actualArr1 = new string[6];
            actualArr1[0] = "1";
            string[] expected1 = new string[] { "1", "A", "B", "C", "D", "E" };

            actualList.CopyTo(actualArr1, 1);
            Assert.AreEqual(actualArr1, expected1);
        }

        [Test]
        public void cleaningTest()
        {
            MyLinkedList<String> actual = new MyLinkedList<string>();
            MyLinkedList<String> expected = new MyLinkedList<string>();

            string[] actualArr = new string[] { "A", "B", "C", "D", "E" };

            foreach (var item in actualArr)
                actual.Add(item);

            actual.Clear();
            Assert.AreEqual(actual.Count, expected.Count);
        }

        private List<String> getList(MyLinkedList<String> custom)
        {
            List<String> returned = new List<string>();
            foreach (var item in custom)
            {
                returned.Add(item);
            }
            return returned;
        }
    }
}