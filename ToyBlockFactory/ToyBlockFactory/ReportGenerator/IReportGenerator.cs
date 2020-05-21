namespace ToyBlockFactory.ReportGenerator
{
    public interface IReportGenerator
    {
        public void Generate(Report report, Order order);
    }
}
