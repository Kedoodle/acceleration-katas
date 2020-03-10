using System;

namespace fizzbuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            for (var i = 1; i <= 100; i++)
            {
                Console.WriteLine(FizzBuzzGenerator.Generate(i));
            }
        }
    }
}


/*
using System;

namespace fizzbuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            for (var i = 1; i <= 100; i++)
            {
                if (i % 15 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
*/