using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Search.Tests
{
    [TestFixture]
    public class BinarySearchTests
    {
        [TestCase(new[] { -3, 2, 8, 11, 19, 21 }, 11, ExpectedResult = 3)]
        [TestCase(new[] { -15, -4, 5, 9, 18, 20 }, 20, ExpectedResult = 5)]
        [TestCase(new[] { -18, -15, -13, 0, 4, 9, 10 }, 5, ExpectedResult = -1)]
        public int BinarySearchTest_IntArray_ItemIndex(int[] array, int item)
        {
            return BinarySearch.Search(array, item, Comparer<int>.Default);
        }

        [TestCase(new[] { -3.3, 2.5, 8.9, 11.1, 19.2, 21.4 }, 11.1, ExpectedResult = 3)]
        [TestCase(new[] { -15.6, -4.1, 5.3, 9.6, 18.2, 20.4 }, 20.4, ExpectedResult = 5)]
        [TestCase(new[] { -18.8, -15.1, -13.2, 0, 4.3, 9.2, 10.9 }, 5.8, ExpectedResult = -1)]
        public int BinarySearchTest_DoubleArray_ItemIndex(double[] array, double item)
        {
            return BinarySearch.Search(array, item, Comparer<double>.Default);
        }

        [TestCase(new[] { "Abraham", "Barbara", "Michael", "Phillip" }, "Phillip", ExpectedResult = 3)]
        [TestCase(new[] { "David", "Frank", "George" }, "George", ExpectedResult = 2)]
        [TestCase(new[] { "Aria", "Nick", "Thomas" }, "Lily", ExpectedResult = -1)]
        public int BinarySearchTest_StringArray_ItemIndex(string[] array, string item)
        {
            return BinarySearch.Search(array, item, Comparer<string>.Default);
        }

        [TestCase(null, 2)]
        public void BinarySearchTest_Null_ThrowsArgumentNullException(int[] array, int item)
        {
            Assert.Throws<ArgumentNullException>(() => BinarySearch.Search(array, item, Comparer<int>.Default));
        }

        [TestCase(new int[] { }, 9)]
        public void BinarySearchTest_EmptyArray_ThrowsArgumentException(int[] array, int item)
        {
            Assert.Throws<ArgumentException>(() => BinarySearch.Search(array, item, Comparer<int>.Default));
        }
    }
}
