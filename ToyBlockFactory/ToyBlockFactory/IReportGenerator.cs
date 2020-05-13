namespace ToyBlockFactory
{
    public interface IReportGenerator
    {
        public void GenerateInvoiceReport(Order order);
        public void GenerateCuttingListReport(Order order);
        public void GeneratePaintingReport(Order order);
    }
}