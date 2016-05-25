using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AchieveIt.Test
{
    public class BinarySearchTest
    {
        public int BinarySearch(int[] sortedArray, int searchValue)
        {
            // Get middle value
            var midPos = sortedArray.Length / 2;
            var mid = sortedArray[midPos];

            if (mid < searchValue)
            {
                // Search Right side.
                return BinarySearch(sortedArray.Where((elem, i) => i > midPos).ToArray(), searchValue);
            }
            else if (mid > searchValue)
            {
                // Search Left side.
                return BinarySearch(sortedArray.Where((elem, i) => i < midPos).ToArray(), searchValue);
            }
            else
            {
                return mid;
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
            var sortAlgorithm = new QuickSortTest();

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
            Console.WriteLine($"Searching for: {789}");
            var valueFound = BinarySearch(sortedList, 789);
            timer.Stop();
            Console.WriteLine($"Value found: {valueFound == 789} [{valueFound}]");
            Console.WriteLine($"Time searching: {timer.Elapsed}");
        }
    }
}