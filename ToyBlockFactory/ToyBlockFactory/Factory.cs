using System.Collections.Generic;
using System.IO;

namespace ToyBlockFactory
{
    public class Factory
    {
        private readonly ConsoleOrderTaker _consoleOrderTaker;
        private readonly ConsoleReportGenerator _consoleReportGenerator;

        public Factory(ConsoleOrderTaker consoleOrderTaker, ConsoleReportGenerator consoleReportGenerator)
        {
            _consoleOrderTaker = consoleOrderTaker;
            _consoleReportGenerator = consoleReportGenerator;
        }

        public List<Order> Orders { get; set; }
    }
}