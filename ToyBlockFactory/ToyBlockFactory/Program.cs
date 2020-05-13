using System;

namespace ToyBlockFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var consoleOrderTaker = new ConsoleOrderTaker(Console.In, Console.Out);
            var consoleReportGenerator = new ConsoleReportGenerator(Console.Out);
            var factory = new Factory(consoleOrderTaker, consoleReportGenerator);
        }
    }
}