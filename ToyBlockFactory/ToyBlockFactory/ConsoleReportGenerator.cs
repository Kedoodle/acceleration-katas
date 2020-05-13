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
        
        public void GenerateInvoiceReport(Order order)
        {
            throw new System.NotImplementedException();
        }

        public void GenerateCuttingListReport(Order order)
        {
            throw new System.NotImplementedException();
        }

        public void GeneratePaintingReport(Order order)
        {
            throw new System.NotImplementedException();
        }
    }
}