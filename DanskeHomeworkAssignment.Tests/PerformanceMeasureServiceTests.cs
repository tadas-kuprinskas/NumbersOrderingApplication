using DanskeHomeworkAssignment.WebApi.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DanskeHomeworkAssignment.Tests
{
    public class PerformanceMeasureServiceTests
    {
        private readonly FileService fileService = new();

        [Fact]
        public void CreateRandomArray_GivenCorrectParameter_ReturnsArrayOfIntegers()
        {
            SortingService sortingService = new(fileService);
            PerformanceMeasureService performanceMeasureService = new(sortingService);

            var randomArray = performanceMeasureService.CreateRandomArray();

            randomArray.Should().NotBeEmpty();
            randomArray.Should().BeOfType<int[]>();
        }

        [Fact]
        public void RecordSortedTime_GivenCorrectParameters_IsNotEmptyAndReturnsString()
        {
            SortingService sortingService = new(fileService);
            PerformanceMeasureService performanceMeasureService = new(sortingService);

            var unsortedArray = performanceMeasureService.CreateRandomArray();

            var bubbleSortResult = performanceMeasureService.RecordSortTime(unsortedArray, sortingService.BubbleSort);
            var insertionSortResult = performanceMeasureService.RecordSortTime(unsortedArray, sortingService.InsertionSort);

            bubbleSortResult.Should().NotBeNullOrEmpty();
            insertionSortResult.Should().NotBeNullOrEmpty();

            bubbleSortResult.Should().BeOfType<string>();
            insertionSortResult.Should().BeOfType<string>();
        }

        [Fact]
        public void ReturnBubbleSortMeasures_GivenString_ReturnsString()
        {
            SortingService sortingService = new(fileService);
            PerformanceMeasureService performanceMeasureService = new(sortingService);

            var unsortedArray = performanceMeasureService.CreateRandomArray();
            var bubbleSortResult = performanceMeasureService.ReturnBubbleSortMeasures(unsortedArray);

            bubbleSortResult.Should().BeOfType<string>();
        }

        [Fact]
        public void ReturnInsertionSortMeasures_GivenString_ReturnsString()
        {
            SortingService sortingService = new(fileService);
            PerformanceMeasureService performanceMeasureService = new(sortingService);

            var unsortedArray = performanceMeasureService.CreateRandomArray();
            var insertionSortResult = performanceMeasureService.ReturnInsertionSortMeasures(unsortedArray);

            insertionSortResult.Should().BeOfType<string>();
        }

        [Fact]
        public void ReturnPerformanceResults_GivenStrings_ReturnsListOfStrings()
        {
            SortingService sortingService = new(fileService);
            PerformanceMeasureService performanceMeasureService = new(sortingService);

            var performanceResults = performanceMeasureService.ReturnPerformanceResults();

            performanceResults.Should().NotBeNullOrEmpty();
            performanceResults.Should().BeOfType<List<string>>();
        }
    }
}
