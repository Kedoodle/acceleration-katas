using System.IO;

namespace ToyBlockFactory
{
    public class ConsoleReportGenerator
    {
        private readonly TextWriter _output;

        public ConsoleReportGenerator(TextWriter output)
        {
            _output = output;
        }
    }
}