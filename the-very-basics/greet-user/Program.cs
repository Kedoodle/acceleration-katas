using System;

namespace greet_user
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is your name?: ");
            var name = Console.ReadLine();
            Console.WriteLine("Hello " + name);
        }
    }
}