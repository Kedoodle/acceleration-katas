using System;

namespace magic_year
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the magic year calculator!\n");
            
            Console.Write("Please enter your name: ");
            var firstName = Console.ReadLine();
            Console.Write("Please enter your surname: ");
            var lastName = Console.ReadLine();
            var annualSalary = GetUserInputAsInt("Please enter your annual salary");
            var startYear = GetUserInputAsInt("Please enter your work start year");
            var fullName = $"{firstName} {lastName}";
            var monthlySalary = Calculator.GetMonthlySalary(annualSalary);
            var magicYear = Calculator.GetMagicYear(startYear);
            
            Console.WriteLine("\nYour magic age details are:\n");
            
            Console.WriteLine($"Name: {fullName}\n" +
                              $"Monthly Salary: {monthlySalary}\n" +
                              $"Magic Year: {magicYear}");
        }

        private static int GetUserInputAsInt(string prompt)
        {
            Console.Write($"{prompt}: ");
            int inputAsInt;
            while (!int.TryParse(Console.ReadLine(), out inputAsInt))
            {
                Console.Write($"Invalid input! {prompt}: ");
            }
            return inputAsInt;
        }
    }
}