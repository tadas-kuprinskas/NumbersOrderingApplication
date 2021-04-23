using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using DanskeHomeworkAssignment.WebApi.Helpers;
using DanskeHomeworkAssignment.WebApi.Interfaces;

namespace DanskeHomeworkAssignment.WebApi.Services
{
    public class FileService : IFileService
    {
        private const string fileUrl = "..\\..\\..\\..\\CommonData\\SortedNumbers.txt";

        //private readonly string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;

        public string FilePath { get; set; } = $"{Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileUrl)}";

        public async Task WriteToFile(int[] sortedNumbers)
        {
            
            using StreamWriter streamWriter = new(FilePath);

            await streamWriter.WriteLineAsync(string.Join(' ', sortedNumbers));
        }

        public async Task<int[]> ReadFromFile()
        {           
            using StreamReader streamReader = new(FilePath);
            string lineOfNumbers = await streamReader.ReadLineAsync();

            return (int[])ParsingHelpers.ParseToIntegerArray(lineOfNumbers);
        }
    }
}
