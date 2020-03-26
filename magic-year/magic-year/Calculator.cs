namespace magic_year
{
    public static class Calculator
    {
        public static int GetMagicYear(int startYear)
        {
            return startYear + 65;
        }

        public static int GetMonthlySalary(int annualSalary)
        {
            return annualSalary / 12;
        }
    }
}