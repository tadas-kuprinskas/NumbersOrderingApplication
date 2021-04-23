namespace DanskeHomeworkAssignment.WebApi.Interfaces
{
    public interface ISortingService
    {
        int[] BubbleSort(int[] arrayToSort);
        int[] InsertionSort(int[] arrayToSort);
        void SortInput(string lineOfNumbers);
    }
}