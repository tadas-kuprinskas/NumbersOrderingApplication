using DanskeHomeworkAssignment.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DanskeHomeworkAssignment.WebApi.Services
{
    public class PerformanceMeasureService : IPerformanceMeasureService
    {
        private readonly ISortingService _sortingService;
        public PerformanceMeasureService(ISortingService sortingService)
        {
            _sortingService = sortingService;
        }

        public int[] CreateRandomArray()
        {
            Random random = new();
            int maxSize = 20000;
            int[] unsortedArray = new int[maxSize];

            for (int i = 0; i < unsortedArray.Length; i++)
                unsortedArray[i] = random.Next(maxSize + 1);

            return unsortedArray;
        }

        public string RecordSortTime(int[] unsortedArray, Func<int[], int[]> func)
        {
            Stopwatch stopwatch = new();
            stopwatch.Reset();
            stopwatch.Start();
            func((int[])unsortedArray.Clone());
            stopwatch.Stop();
            return $"{stopwatch.ElapsedMilliseconds} ms";
        }

        public string ReturnBubbleSortMeasures(int[] unsortedArray)
        {
            return RecordSortTime(unsortedArray, _sortingService.BubbleSort);
        }

        public string ReturnInsertionSortMeasures(int[] unsortedArray)
        {
            return RecordSortTime(unsortedArray, _sortingService.InsertionSort);
        }

        public List<string> ReturnPerformanceResults()
        {
            var unsortedArray = CreateRandomArray();

            List<string> results = new()
            {
                $"BubbleSort took {ReturnBubbleSortMeasures(unsortedArray)} to sort the Array",
                $"InsertionSort took {ReturnInsertionSortMeasures(unsortedArray)} to sort the Array"
            };

            return results;
        }
    }
}

