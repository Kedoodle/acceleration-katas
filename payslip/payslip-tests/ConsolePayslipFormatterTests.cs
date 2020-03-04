using System;
using payslip;
using Xunit;

namespace payslip_tests
{
    public class ConsolePayslipFormatterTests
    {
        private readonly ConsolePayslipFormatter _consolePayslipFormatter = CreateSampleConsolePayslipFormatter();

        [Fact]
        public void FormatName_FirstLastNames_Concatenates()
        {
            const string expected = "John Doe";
            var actual = _consolePayslipFormatter.FormatName();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FormatPayPeriod_SingleDigitDates_PrependsZero()
        {
            const string expected = "01 March - 31 March";
            var actual = _consolePayslipFormatter.FormatPayPeriod();
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void FormatGrossIncome_Decimals_RoundsToNearestInteger()
        {
            const string expected = "5004";
            var actual = _consolePayslipFormatter.FormatGrossIncome();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FormatIncomeTax_Decimals_RoundsToNearestInteger()
        {
            const string expected = "922";
            var actual = _consolePayslipFormatter.FormatIncomeTax();
            Assert.Equal(expected, actual);
        }

        private static ConsolePayslipFormatter CreateSampleConsolePayslipFormatter()
        {
            const string firstName = "John";
            const string lastName = "Doe";
            const float salary = 60050;
            const float superRate = 9;
            var startDate = new DateTime(2020, 3, 1);
            var endDate = new DateTime(2020, 3, 31);
            var employee = new Employee(firstName, lastName, salary, superRate);
            var payslipGenerator = new PayslipGenerator(employee, startDate, endDate);
            var payslip = payslipGenerator.Generate();
            var consolePayslipFormatter = new ConsolePayslipFormatter(payslip);
            return consolePayslipFormatter;
        }
    }
}