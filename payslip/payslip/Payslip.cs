using System;

namespace payslip
{
    public class Payslip
    {
        public Employee Employee { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public int GrossIncome { get; private set; }
        public int IncomeTax { get; private set; }
        public int NetIncome { get; private set; }
        public int Super { get; private set; }
    }
}