using System;
using payslip;
using Xunit;

namespace payslip_tests
{
    public class ConsolePayslipFormatterTests
    {
        [Fact]
        public void GetName_FirstLastNames_Concatenates()
        {
            const string expected = "John Doe";
            
            var consolePayslipFormatter = CreateSampleConsolePayslipFormatter();
            var actual = consolePayslipFormatter.FormatName(); 
                
            Assert.Equal(expected, actual);
        }


        private ConsolePayslipFormatter CreateSampleConsolePayslipFormatter()
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