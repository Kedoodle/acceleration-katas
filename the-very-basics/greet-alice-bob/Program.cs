using System;

namespace greet_alice_bob
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is your name?: ");
            var name = Console.ReadLine();
            if (name.Equals("Alice") || name.Equals("Bob"))
            {
                Console.WriteLine("Hello " + name);
            }
            else
            {
                Console.WriteLine("Go away " + name);
            }
        }
    }
}