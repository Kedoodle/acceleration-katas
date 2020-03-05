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

        public string FormatPayslip()
        {
            return $"Name: {FormatName()}\n" +
                   $"Pay Period: {FormatPayPeriod()}\n" +
                   $"Gross Income: {FormatGrossIncome()}\n" +
                   $"Income Tax: {FormatIncomeTax()}\n" +
                   $"Net Income: {FormatNetIncome()}\n" +
                   $"Super: {FormatSuper()}";
        }

        public string FormatName()
        {
            return $"{_payslip.Employee.FirstName} {_payslip.Employee.LastName}";
        }

        public string FormatPayPeriod()
        {
            return $"{_payslip.StartDate:dd MMMM} - {_payslip.EndDate:dd MMMM}";
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