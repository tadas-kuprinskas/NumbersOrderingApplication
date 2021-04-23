using DanskeHomeworkAssignment.WebApi.Helpers;
using DanskeHomeworkAssignment.WebApi.Services;
using FluentAssertions;
using Xunit;

namespace DanskeHomeworkAssignment.Tests
{
    public class ParsingHelpersTests
    {
        [Theory]
        [InlineData("1 5 6 9 8 7 3 20 14 12")]
        public void ParseStringToIntegerArray_GivenString_ReturnSuccessfulParse(string lineOfNUmbers)
        {
            var arrayOfIntegers = ParsingHelpers.ParseToIntegerArray(lineOfNUmbers);

            lineOfNUmbers.Should().NotBeNullOrEmpty();
            lineOfNUmbers.Should().BeOfType<string>();

            arrayOfIntegers.Should().NotBeNullOrEmpty();
            arrayOfIntegers.Should().BeOfType<int[]>();
        }
    }
}
