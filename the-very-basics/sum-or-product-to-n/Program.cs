using System;
using System.Linq;

namespace sum_or_product_to_n
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter an integer: ");
            var n = 0;
            try
            {
                n = Convert.ToInt32(Console.ReadLine());
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("Please enter a valid integer");
                Environment.Exit(0);
            }
            
            Console.WriteLine("Would you like the sum or product of 1 to n?: ");
            var choice = Console.ReadLine();
            if (choice.ToLower().Equals("sum"))
            {
                Console.WriteLine("Sum of positive integers 1 to n: " + n*(n+1)/2);
            }
            else
            {
                Console.WriteLine("Product of positive integers 1 to n: " + Enumerable.Range(1, n).Aggregate((total, next) => total * next));
            }
        }
    }
}