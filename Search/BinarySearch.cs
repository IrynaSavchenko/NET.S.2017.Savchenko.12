using System;
using System.Collections.Generic;

namespace Search
{
    /// <summary>
    /// Class containing the Binary Search algorithm logic
    /// </summary>
    public static class BinarySearch
    {
        private static int NoMatchFound = -1;

        /// <summary>
        /// Searches an item in the array using the Binary Search algorithm
        /// </summary>
        /// <typeparam name="T">Type of items in the array</typeparam>
        /// <param name="array">Sorted array to search the item in</param>
        /// <param name="item">Item to be found</param>
        /// <param name="comparer">Comparer representing sorting criteria</param>
        /// <returns>Index of the item in the array or -1 if it was not found</returns>
        public static int Search<T>(T[] array, T item, IComparer<T> comparer)
        {
            CheckInputArray(array);
            return PerformSearch(array, item, comparer);
        }

        private static int PerformSearch<T>(T[] array, T item, IComparer<T> comparer)
        {
            if (array.Length == 0)
                return NoMatchFound;

            int middle = array.Length / 2;

            int comparisonResult = comparer.Compare(array[middle], item);

            if (comparisonResult == 0)
                return middle;
            if (comparisonResult > 0)
                return PerformSearch<T>(GetArrayPart(array, 0, middle - 1), item, comparer);

            int index = PerformSearch<T>(GetArrayPart(array, middle + 1, array.Length - 1), item, comparer);
            return index == NoMatchFound ? NoMatchFound : middle + index + 1;
        }

        private static T[] GetArrayPart<T>(T[] array, int first, int last)
        {
            List<T> newArray = new List<T>();

            for (int i = first; i <= last; i++)
                newArray.Add(array[i]);

            return newArray.ToArray();
        }

        private static void CheckInputArray<T>(T[] array)
        {
            if (array == null)
                throw new ArgumentNullException($"{nameof(array)} cannot be null");
            if (array.Length == 0)
                throw new ArgumentException($"{nameof(array)} cannot be empty");
        }
    }
}
