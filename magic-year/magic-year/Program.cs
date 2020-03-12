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
            var annualSalary = Console.ReadLine();
            Console.Write("Please enter your work start year: ");
            var startYear = Console.ReadLine();

            var fullName = $"{firstName} {lastName}";
            var monthlySalary = -1;
            var magicYear = -1;
            
            Console.WriteLine("\nYour magic age details are:\n");
            
            Console.WriteLine($"Name: {fullName}\n" +
                              $"Monthly Salary: {monthlySalary}\n" +
                              $"Magic Year: {magicYear}");
        }
    }
}