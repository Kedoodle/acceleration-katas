using System.ComponentModel;
using System.IO;

namespace ToyBlockFactory
{
    public class ConsoleReportGenerator : IReportGenerator
    {
        private readonly TextWriter _output;

        public ConsoleReportGenerator(TextWriter output)
        {
            _output = output;
        }

        public void Generate(Report report, Order order)
        {
            var reportParser = report switch
            {
                Report.Invoice => new InvoiceReportParser(),
                _ => throw new InvalidEnumArgumentException()
            };
            _output.WriteLine(reportParser.ToStringReport(order));
        }
    }
}