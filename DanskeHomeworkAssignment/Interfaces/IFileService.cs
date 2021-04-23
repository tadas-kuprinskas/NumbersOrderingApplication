using System.Threading.Tasks;

namespace DanskeHomeworkAssignment.WebApi.Interfaces
{
    public interface IFileService
    {
        Task<int[]> ReadFromFile();
        Task WriteToFile(int[] sortedNumbers);
    }
}