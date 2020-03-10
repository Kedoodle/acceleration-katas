using System;

namespace payslip
{
    public class Payslip
    {
        public Payslip(Employee employee, DateTime startDate, DateTime endDate, double grossIncome, double incomeTax,
            double netIncome, double super)
        {
            Employee = employee;
            StartDate = startDate;
            EndDate = endDate;
            GrossIncome = grossIncome;
            IncomeTax = incomeTax;
            NetIncome = netIncome;
            Super = super;
        }
        public Employee Employee { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public double GrossIncome { get; private set; }
        public double IncomeTax { get; private set; }
        public double NetIncome { get; private set; }
        public double Super { get; private set; }
    }
}