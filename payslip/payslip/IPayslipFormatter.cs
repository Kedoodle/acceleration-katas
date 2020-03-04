using System;

namespace payslip
{
    public interface IPayslipFormatter
    {
        string FormatName(string firstName, string lastName);
        string FormatPayPeriod(DateTime startDate, DateTime endDate);
        string FormatGrossIncome(int grossIncome);
        string FormatIncomeTax(int incomeTax);
        string FormatNetIncome(int netIncome);
        string FormatSuper(int super);
    }
}