using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanskeHomeworkAssignment.WebApi.Helpers
{
    public static class ParsingHelpers
    {
        public static IEnumerable<int> ParseToIntegerArray(string lineOfNumbers)
        {
            return lineOfNumbers.Split(' ').Select(number => int.Parse(number)).ToArray();
        }
    }
}
