using DanskeHomeworkAssignment.WebApi.Helpers;
using DanskeHomeworkAssignment.WebApi.Services;
using FluentAssertions;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace DanskeHomeworkAssignment.Tests
{
    public class FileServiceTests
    {
        private readonly FileService fileService = new();

        [Theory]
        [InlineData("1 8 15 3 2 16")]
        public async Task WriteToFile_GivenCorrectParameters_FileExists(string lineOfNumbers)
        {     
            await fileService.WriteToFile((int[])ParsingHelpers.ParseToIntegerArray(lineOfNumbers));

            lineOfNumbers.Should().NotBeNullOrEmpty();
            Assert.True(File.Exists(fileService.FilePath));            
        }

        [Fact]
        public async Task ReadFromFile_GivenCorrectPath_ReadsAndReturnsNumbers()
        {
            var lineOfNumbers = await fileService.ReadFromFile();

            Assert.True(File.Exists(fileService.FilePath));
            lineOfNumbers.Should().NotBeNullOrEmpty();
            lineOfNumbers.Should().BeOfType<int[]>();
        }
    }
}
