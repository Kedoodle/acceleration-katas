using System;
using payslip;
using Xunit;

namespace payslip_tests
{
    public class PayslipCalculatorTests
    {
        [Fact]
        public void CalculatePayPeriods_SameMonth_Calculated()
        {
            const int expected = 1;
            
            var startDate = new DateTime(2020, 3, 1);
            var endDate = new DateTime(2020, 3, 31);
            var actual = PayslipCalculator.CalculatePayPeriods(startDate, endDate); 
                
            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData(60050, 1, 921.9375)]
        public void CalculateIncomeTax_VariousIncomesAndPeriods_Calculated(double grossIncome, int payPeriods, double tax)
        {
            var expected = tax;
            
            var actual = PayslipCalculator.CalculateIncomeTax(grossIncome, payPeriods); 
                
            Assert.Equal(expected, actual);
        }
    }
}