using System;

namespace payslip
{
    public class PayslipGenerator
    {
        private readonly Employee _employee;
        private readonly DateTime _startDate;
        private readonly DateTime _endDate;
        
        public PayslipGenerator(Employee employee, in DateTime startDate, in DateTime endDate)
        {
            _employee = employee;
            _startDate = startDate;
            _endDate = endDate;
        }

        public Payslip Generate()
        {
            var payPeriods = PayslipCalculator.CalculatePayPeriods(_startDate, _endDate);
            var grossIncome = PayslipCalculator.CalculateGrossIncome(_employee.Salary, payPeriods);
            var incomeTax = PayslipCalculator.CalculateIncomeTax(grossIncome, payPeriods);
            var netIncome = PayslipCalculator.CalculateNetIncome(grossIncome, incomeTax);
            var super = PayslipCalculator.CalculateSuper(grossIncome, _employee.SuperRate);
            var payslip = new Payslip(_employee, _startDate, _endDate, grossIncome, incomeTax, netIncome, super);
            return payslip;
        }
    }

    public static class PayslipCalculator
    {
        public static int CalculatePayPeriods(in DateTime startDate, in DateTime endDate)
        {
            var payPeriods = 1 + endDate.Month - startDate.Month;
            return payPeriods;
        }

        public static double CalculateGrossIncome(in double employeeSalary, in int payPeriods)
        {
            return employeeSalary / 12;
        }

        public static double CalculateIncomeTax(in double grossIncome, in int payPeriods)
        {
            if (grossIncome <= 18200) return 0;
            if (grossIncome <= 37000) return (grossIncome - 18200) * 0.19;
            if (grossIncome <= 87000) return 3572 + (grossIncome - 37000) * 0.325;
            if (grossIncome <= 180000) return 19822 + (grossIncome - 87000) * 0.37;
            return 54232 + (grossIncome - 180000) * 0.45;
        }

        public static double CalculateNetIncome(in double grossIncome, in double incomeTax)
        {
            return grossIncome - incomeTax;
        }

        public static double CalculateSuper(in double grossIncome, in double superRate)
        {
            return grossIncome * superRate / 100;
        }
    }
}