using DanskeHomeworkAssignment.WebApi.Helpers;
using DanskeHomeworkAssignment.WebApi.Interfaces;

namespace DanskeHomeworkAssignment.WebApi.Services
{
    public class SortingService : ISortingService
    {      
        private readonly IFileService _fileService;

        public SortingService(IFileService fileService)
        {           
            _fileService = fileService;
        }

        public void SortInput(string lineOfNumbers)
        {
            var arrayOfIntegers = ParsingHelpers.ParseToIntegerArray(lineOfNumbers);
            var sortedArray = BubbleSort((int[])arrayOfIntegers);

            _fileService.WriteToFile(sortedArray);
        }

        public int[] BubbleSort(int[] arrayToSort)
        {
            for (int i = 0; i < arrayToSort.Length; i++)
            {
                for (int j = 0; j < arrayToSort.Length - i - 1; j++)
                {
                    if (arrayToSort[j] > arrayToSort[j + 1])
                    {
                        var swapValue = arrayToSort[j];
                        arrayToSort[j] = arrayToSort[j + 1];
                        arrayToSort[j + 1] = swapValue;
                    }
                }
            }

            return arrayToSort;
        }

        public int[] InsertionSort(int[] arrayToSort)
        {
            for (var i = 0; i < arrayToSort.Length; i++)
            {
                var key = arrayToSort[i];
                var j = i;
                while (j > 0 && arrayToSort[j - 1] > key)
                {
                    var swapValue = arrayToSort[j - 1];
                    arrayToSort[j - 1] = arrayToSort[j];
                    arrayToSort[j] = swapValue;
                    j--;
                }

                arrayToSort[j] = key;
            }

            return arrayToSort;
        }
    }
}
