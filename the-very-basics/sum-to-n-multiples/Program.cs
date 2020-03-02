using System;
using System.Linq;

namespace sum_to_n_multiples
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
                Console.WriteLine("Sum of positive multiples of three or five: 0");
            else 
                Console.WriteLine("Sum of positive multiples of three or five: " + Enumerable.Range(1, n).Where(i => i % 3 == 0 || i % 5 == 0).Sum());
        }
    }
}