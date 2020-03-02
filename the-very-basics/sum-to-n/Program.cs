using System;
using System.Diagnostics;

namespace sum_to_n
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a positive integer: ");
            var n = 0;
            try
            {
                n = Convert.ToInt32(Console.ReadLine());
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("Please enter a valid integer");
            }
            if (n < 0)
                Console.WriteLine("Sum: 0");
            else 
                Console.WriteLine("Sum: " + n*(n+1)/2);
        }
    }
}