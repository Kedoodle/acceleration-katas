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
            return $"Name: {FormatName()}" +
                   $"Pay Period: {FormatPayPeriod()}" +
                   $"Gross Income: {FormatGrossIncome()}" +
                   $"Income Tax: {FormatIncomeTax()}" +
                   $"Net Income: {FormatNetIncome()}" +
                   $"Super: {FormatSuper()}";
        }

        public string FormatName()
        {
            return $"{_payslip.Employee.FirstName} {_payslip.Employee.LastName}";
        }

        public string FormatPayPeriod()
        {
            return $"{_payslip.StartDate.Day,2} {_payslip.StartDate.Month} - {_payslip.EndDate.Day,2} {_payslip.EndDate.Month}";
        }

        public string FormatGrossIncome()
        {
            return Math.Round(_payslip.GrossIncome).ToString();
        }

        public string FormatIncomeTax()
        {
            return Math.Round(_payslip.IncomeTax).ToString();
        }

        public string FormatNetIncome()
        {
            return Math.Round(_payslip.NetIncome).ToString();
        }

        public string FormatSuper()
        {
            return Math.Round(_payslip.Super).ToString();
        }
    }
}