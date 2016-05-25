using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AchieveIt.Test
{
    [TestFixture]
    public class QuickSortTest
    {
        /// <summary>
        /// QuickSort algorithm for a generic list. Added as a bonus.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns>A QuickSorted list.</returns>
        public T[] QuickSort<T>(T[] list)
        {
            if (list.Length <= 1) { return list; }

            var listToSort = new List<T>(list); // Created new list for ease of use with linq extensions.
            var wall = -1; // Value that will determine where the list will be partioned.

            // For simplicity we alway select the last item as pivot. We could have a rand to
            var pivot = listToSort.Count() - 1;

            var comparer = Comparer<T>.Default;
            for (int i = 0; i < listToSort.Count() - 1; i++)
            {
                var res = comparer.Compare(listToSort[i], listToSort[pivot]);
                if (res < 0)
                {
                    wall++;
                    var t = listToSort[wall];
                    listToSort[wall] = listToSort[i];
                    listToSort[i] = t;
                }
            }

            wall++;

            // Swap Pivot with wall. This means the pivot value is in its correct position.
            var temp = listToSort[wall];
            listToSort[wall] = listToSort[pivot];
            listToSort[pivot] = temp;

            // Create partitions for list. Left side are any numbers lower than the wall, Right side numbers higher than the wall.
            var left = listToSort.Where((elem, i) => i < wall).ToArray();
            var right = listToSort.Where((elem, i) => i >= wall).ToArray();

            // Exit condition. Grouping to account for duplicates.
            if (left.GroupBy((v) => v).Count() <= 1 && right.GroupBy((v) => v).Count() <= 1)
            {
                return left.Concat(right).ToArray();
            }

            // Repeat sort for Left and Right partitions.
            return QuickSort(left).Concat(QuickSort(right)).ToArray();
        }

        /// <summary>
        /// QuickSort algorithm for an array of integers. Conforms to test requirements.)
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns>A QuickSorted list.</returns>
        public int[] QuickSort(int[] list)
        {
            if (list.Length <= 1) { return list; }

            var listToSort = new List<int>(list); // Created new list for ease of use with linq extensions.
            var wall = -1; // Value that will determine where the list will be partioned.

            // For simplicity we always select the last item as pivot. We could have a random number to minimize worst case scenario and/or use 2 iterators in the for loop. I went with the simpler, easier to understand implementation.
            var pivot = listToSort.Count() - 1;

            for (int i = 0; i < listToSort.Count() - 1; i++)
            {
                if ((listToSort[i] < listToSort[pivot]))
                {
                    wall++;
                    var t = listToSort[wall];
                    listToSort[wall] = listToSort[i];
                    listToSort[i] = t;
                }
            }

            wall++;

            // Swap Pivot with wall. This means the pivot value is in its correct position.
            var temp = listToSort[wall];
            listToSort[wall] = listToSort[pivot];
            listToSort[pivot] = temp;

            // Create partitions for list. Left side are any numbers lower than the wall, Right side numbers higher than the wall.
            var left = listToSort.Where((elem, i) => i < wall).ToArray();
            var right = listToSort.Where((elem, i) => i >= wall).ToArray();

            // Exit condition. Grouping to account for duplicates.
            if (left.GroupBy((v) => v).Count() <= 1 && right.GroupBy((v) => v).Count() <= 1)
            {
                return left.Concat(right).ToArray();
            }

            // Repeat sort for Left and Right partitions.
            return QuickSort(left).Concat(QuickSort(right)).ToArray();
        }

        private static List<List<int>> _sourceListsInt = new List<List<int>> {
            new List<int>{ 3, 1, 2, 5, 7, 9, 6, 8, 0, 4 },
            new List<int>{ 2, 5, 4, 9, 6, 3, 7, 8, 1, 0 },
            new List<int>{ 9, 4, 8, 5, 7, 6, 0, 2, 3, 1 },
            new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
            new List<int>{ 8, 7, 6, 5, 0, 9, 4, 3, 1, 2 },
            new List<int>{ 100, 25, 84, 96, 55, 789, 66, 5, 2, 4, 7, 855, 24, 56, 96 }
        };

        [Test]
        [TestCaseSource("_sourceListsInt")]
        public void TestListInt(List<int> list)
        {
            Console.Write("Unsorted: ");
            foreach (var elem in list)
            {
                Console.Write($"{elem} ");
            }

            var timer = new Stopwatch();

            timer.Start();
            var sortedList = QuickSort(list.ToArray());
            timer.Stop();

            Console.Write("\nSorted:   ");
            foreach (var elem in sortedList)
            {
                Console.Write($"{elem} ");
            }

            Console.Write($"\nTime: {timer.Elapsed}");
        }

        private static List<List<double>> _sourceListsDouble = new List<List<double>> {
            new List<double>{ 7.9, 687.5, 345.6, 5318.6, 80330138, 813, 83, 834, 4, 3543.00, 3005.1, 51, 3585.9, 4, 3438.0, 4684, 438438, 4 },
            new List<double>{ 78, 569, 85, 665, 47, 527, 752, 4485, 320, 2, 545, 4, 52, 23, 63, 56, 5, 36363, 62, 3535   },
        };

        [Test]
        [TestCaseSource("_sourceListsDouble")]
        public void TestListDouble(List<double> list)
        {
            Console.Write("Unsorted: ");
            foreach (var elem in list)
            {
                Console.Write($"{elem} ");
            }

            var timer = new Stopwatch();

            timer.Start();
            var sortedList = QuickSort<double>(list.ToArray());
            timer.Stop();

            Console.Write("\nSorted:   ");
            foreach (var elem in sortedList)
            {
                Console.Write($"{elem} ");
            }

            Console.Write($"\nTime: {timer.Elapsed}");
        }
    }
}