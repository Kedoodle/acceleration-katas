using System;

namespace payslip
{
    public interface IPayslipFormatter
    {
        string FormatName();
        string FormatPayPeriod();
        string FormatGrossIncome();
        string FormatIncomeTax();
        string FormatNetIncome();
        string FormatSuper();
    }
}