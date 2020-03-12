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

        [Fact]
        public void MonthlySalary_AnnualSalary60050_Returns5004()
        {
            const int expected = 5004;
            const int annualSalary = 60050;
            var actual = Calculator.GetMonthlySalary(annualSalary);
            Assert.Equal(expected, actual);
        }
    }
}