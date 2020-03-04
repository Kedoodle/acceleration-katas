using System;

namespace multiplication_table
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MAX = 12;
            for (var i = 0; i <= MAX; i++)
            {
                Console.Write("{0,3} ", i);
                for (var j = 1; j <= MAX; j++)
                {
                    Console.Write("{0,3} ", i>0 ? i*j : j);
                }
                Console.Write("\n");
            }
        }
    }
}