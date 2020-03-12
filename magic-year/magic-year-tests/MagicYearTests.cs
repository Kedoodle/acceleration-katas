using System;
using magic_year;
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
}