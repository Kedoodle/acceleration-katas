using System;

namespace payslip
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the payslip generator!\n");
            
            Console.Write("Please input your name: ");
            var firstName = Console.ReadLine();
            Console.Write("Please input your surname: ");
            var lastName = Console.ReadLine();
            var annualSalary = ParseDouble("Please input your annual salary: ");
            var superRate = ParseDouble("Please input your super rate: ");
            Console.Write("Please input your payment start date: ");
            Console.Write("Please input your payment end date: ");
            
            Console.WriteLine("Your payslip has been generated:");
            
            
            Console.WriteLine("Thank you for using MYOB!");
        }

        private static double ParseDouble(string prompt)
        {
            double parsedInput;
            Console.Write(prompt);
            var input = Console.ReadLine();
            while (!double.TryParse(input, out parsedInput))
            {
                Console.Write("Invalid input. Please enter a valid number: ");
                input = Console.ReadLine();
            }
            return parsedInput;
        }
    }
}