namespace ToyBlockFactory.ReportGenerator
{
    public interface IReportParser
    {
        string ToStringReport(Order order);
    }
}
