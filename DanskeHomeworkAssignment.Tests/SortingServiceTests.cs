using DanskeHomeworkAssignment.WebApi.Services;
using FluentAssertions;
using Xunit;

namespace DanskeHomeworkAssignment.Tests
{
    public class SortingServiceTests
    {
        private readonly FileService fileService = new();

        [Fact]
        public void BubbleSort_GivenUnsortedArray_ReturnSuccessfullSort()
        {
            SortingService sortingService = new(fileService);
            PerformanceMeasureService performanceMeasuringService = new(sortingService);

            var unsortedArray = performanceMeasuringService.CreateRandomArray();

            var sortedArray = sortingService.BubbleSort(unsortedArray);

            sortedArray.Should().NotBeNullOrEmpty();
            sortedArray.Should().BeOfType<int[]>();

            sortedArray.Should().BeInAscendingOrder();
        }

        [Fact]
        public void InsertionSort_GivenUnsortedArray_ReturnSuccessfullSort()
        {
            SortingService sortingService = new(fileService);
            PerformanceMeasureService performanceMeasuringService = new(sortingService);

            var unsortedArray = performanceMeasuringService.CreateRandomArray();
            var sortedArray = sortingService.InsertionSort(unsortedArray);

            sortedArray.Should().NotBeNullOrEmpty();
            sortedArray.Should().BeOfType<int[]>();

            sortedArray.Should().BeInAscendingOrder();
        }
    }
}
