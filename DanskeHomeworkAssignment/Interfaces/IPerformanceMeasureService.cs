using System;
using System.Collections.Generic;

namespace DanskeHomeworkAssignment.WebApi.Interfaces
{
    public interface IPerformanceMeasureService
    {
        int[] CreateRandomArray();
        string RecordSortTime(int[] unsortedArray, Func<int[], int[]> func);
        string ReturnBubbleSortMeasures(int[] unsortedArray);
        string ReturnInsertionSortMeasures(int[] unsortedArray);
        List<string> ReturnPerformanceResults();
    }
}