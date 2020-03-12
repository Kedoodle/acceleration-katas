using System;
using Xunit;

namespace magic_year_tests
{
    public class MagicYearTests
    {
        [Fact]
        public void MagicYear_StartYear1980_Returns2045()
        {
            const int expected = 2045;
            const int startYear = 1980;
            var actual = Calculator.GetMagicYear(startYear);
            Assert.Equal(expected, actual);
        }
    }

    public static class Calculator
    {
        public static int GetMagicYear(int startYear)
        {
            return startYear + 65;
        }
    }
}