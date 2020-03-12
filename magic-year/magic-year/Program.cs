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
            Console.Write("Please enter your annual salary: ");
            int.TryParse(Console.ReadLine(), out var annualSalary);
            Console.Write("Please enter your work start year: ");
            int.TryParse(Console.ReadLine(), out var startYear);

            var fullName = $"{firstName} {lastName}";
            var monthlySalary = Calculator.GetMonthlySalary(annualSalary);
            var magicYear = Calculator.GetMagicYear(startYear);
            
            Console.WriteLine("\nYour magic age details are:\n");
            
            Console.WriteLine($"Name: {fullName}\n" +
                              $"Monthly Salary: {monthlySalary}\n" +
                              $"Magic Year: {magicYear}");
        }
    }
}