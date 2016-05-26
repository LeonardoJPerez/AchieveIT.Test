using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AchieveIt.Test
{
    public class Answer12
    {
        /// <summary>
        /// Binaries Search for an array of integers. Returns index of value or -1 if not found.
        /// </summary>
        /// <param name="sortedArray">The sorted array.</param>
        /// <param name="searchValue">The search value.</param>
        /// <param name="minPosition">The minimum position of the array.</param>
        /// <param name="maxPosition">The maximum position of the array.</param>
        /// <returns></returns>
        public static int BinarySearchInt(int[] sortedArray, int searchValue, int minPosition = 0, int maxPosition = -1)
        {
            // Get middle value and boundaries.
            var max = maxPosition == -1 ? sortedArray.Length - 1 : maxPosition;
            var min = minPosition;
            var midPosition = (max + min) / 2;
            var midValue = sortedArray[midPosition];

            if (midValue < searchValue)
            {
                // Search Right side.
                return BinarySearchInt(sortedArray, searchValue, midPosition + 1, max);
            }
            else if (midValue > searchValue)
            {
                // Search Left side.
                return BinarySearchInt(sortedArray, searchValue, min, midPosition - 1);
            }
            else if (midValue == searchValue)
            {
                return midPosition;
            }

            return -1;
        }

        public int BinarySearch<T>(T[] sortedArray, T searchValue, int minPosition = 0, int maxPosition = -1)
        {
            // Get middle value
            var max = maxPosition == -1 ? sortedArray.Length - 1 : maxPosition;
            var min = minPosition;
            var midPosition = (max + min) / 2;
            var midValue = sortedArray[midPosition];

            var comparer = Comparer<T>.Default;
            var res = comparer.Compare(midValue, searchValue);
            switch (res)
            {
                case -1:
                    // Search Right side.
                    return BinarySearch(sortedArray, searchValue, midPosition + 1, max);

                case 1:
                    // Search Left side.
                    return BinarySearch(sortedArray, searchValue, min, midPosition - 1);

                default:
                    return midPosition;
            }
        }

        private static List<List<int>> _sourceListsDouble = new List<List<int>> {
            //new List<double>{ 7.9, 687.5, 345.6, 5318.6, 80330138, 813, 83, 834, 4, 3543.00, 3005.1, 51, 3585.9, 4, 3438.0, 4684, 438438, 4 },
            //new List<double>{ 78, 569, 85, 665, 47, 527, 752, 4485, 320, 2, 545, 4, 52, 23, 63, 56, 5, 36363, 62, 3535   },
            new List<int>{ 100, 25, 84, 96, 55, 789, 66, 5, 2, 4, 7, 855, 24, 56, 96 }
        };

        [Test]
        [TestCaseSource("_sourceListsDouble")]
        public void TestBinarySearchInteger(List<int> list)
        {
            Console.Write("Unsorted: ");
            foreach (var elem in list)
            {
                Console.Write($"{elem} ");
            }

            var timer = new Stopwatch();
            var sortAlgorithm = new Answer11();

            timer.Start();
            var sortedList = sortAlgorithm.QuickSort(list.ToArray());
            timer.Stop();

            Console.Write("\nSorted:   ");
            foreach (var elem in sortedList)
            {
                Console.Write($"{elem} ");
            }

            Console.WriteLine($"Time: {timer.Elapsed}");

            timer.Reset();
            timer.Start();
            Console.WriteLine($"Searching for: {855}");
            var valueIndex = BinarySearch(sortedList, 855);
            timer.Stop();
            Console.WriteLine($"Value found: {valueIndex != -1} [index: {valueIndex}]");
            Console.WriteLine($"Time searching: {timer.Elapsed}");
        }
    }
}