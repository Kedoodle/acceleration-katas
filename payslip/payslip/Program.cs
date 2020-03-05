using System;
using System.Globalization;

namespace payslip
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ParseDayMonth("Please input your payment end date: "));
            
            
            Console.WriteLine("Welcome to the payslip generator!\n");
            
            Console.Write("Please input your name: ");
            var firstName = Console.ReadLine();
            Console.Write("Please input your surname: ");
            var lastName = Console.ReadLine();
            var salary = ParseDouble("Please input your annual salary: ");
            var superRate = ParseDouble("Please input your super rate: ");
            var startDate = ParseDayMonth("Please input your payment start date: ");
            var endDate = ParseDayMonth("Please input your payment end date: ");
            
            var employee = new Employee(firstName, lastName, salary, superRate);
            var payslipGenerator = new PayslipGenerator(employee, startDate, endDate);
            var payslip = payslipGenerator.Generate();
            var consolePayslipFormatter = new ConsolePayslipFormatter(payslip);
            var payslipString = consolePayslipFormatter.FormatPayslip();

            Console.WriteLine("\nYour payslip has been generated:\n");
            
            Console.WriteLine(payslipString);
            
            Console.WriteLine("\nThank you for using MYOB!");
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
        
        private static DateTime ParseDayMonth(string prompt)
        {
            DateTime parsedInput;
            Console.Write(prompt);
            var input = Console.ReadLine();
            while (!DateTime.TryParseExact(input, "d MMMM", CultureInfo.CurrentCulture, DateTimeStyles.None, out parsedInput))
            {
                Console.Write("Invalid input. Please enter a valid date (e.g. 1 March): ");
                input = Console.ReadLine();
            }
            return parsedInput;
        }
    }
}