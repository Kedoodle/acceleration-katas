using System;

namespace payslip
{
    public class ConsolePayslipFormatter : IPayslipFormatter
    {
        private readonly Payslip _payslip;

        public ConsolePayslipFormatter(Payslip payslip)
        {
            _payslip = payslip;
        }

        public string GeneratePayslip()
        {
            var name = FormatName(_payslip.Employee.FirstName, _payslip.Employee.LastName);
            var payPeriod = FormatPayPeriod(_payslip.StartDate, _payslip.EndDate);
            var grossIncome = FormatGrossIncome(_payslip.GrossIncome);
            var incomeTax = FormatIncomeTax(_payslip.IncomeTax);
            var netIncome = FormatNetIncome(_payslip.NetIncome);
            var super = FormatSuper(_payslip.Super);
            return $"Name: {name}" +
                   $"Pay Period: {payPeriod}" +
                   $"Gross Income: {grossIncome}" +
                   $"Income Tax: {incomeTax}" +
                   $"Net Income: {netIncome}" +
                   $"Super: {super}";
        }

        public string FormatName(string firstName, string lastName)
        {
            return $"{firstName} {lastName}";
        }

        public string FormatPayPeriod(DateTime startDate, DateTime endDate)
        {
            return $"{startDate.Day,2} {startDate.Month} - {endDate.Day,2} {endDate.Month}";
        }

        public string FormatGrossIncome(int grossIncome)
        {
            return grossIncome.ToString();
        }

        public string FormatIncomeTax(int incomeTax)
        {
            return incomeTax.ToString();
        }

        public string FormatNetIncome(int netIncome)
        {
            return netIncome.ToString();
        }

        public string FormatSuper(int super)
        {
            return super.ToString();
        }
    }
}