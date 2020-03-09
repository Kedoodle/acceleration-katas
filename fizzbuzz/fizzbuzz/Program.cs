using System;

namespace fizzbuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            for (var i = 1; i <= 100; i++)
             {
                 if (i % 3 == 0)
                 {
                     Console.WriteLine("Fizz");
                 }
                 Console.WriteLine(i);
             }
         }
     }
 }