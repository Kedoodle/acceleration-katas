using System;
using System.Diagnostics;

namespace sum_to_n
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
            if (n < 0)
                Console.WriteLine("Sum of positive integers 1 to n: 0");
            else 
                Console.WriteLine("Sum of positive integers 1 to n: " + n*(n+1)/2);
        }
    }
}