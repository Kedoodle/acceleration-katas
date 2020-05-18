using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToyBlockFactory
{
    public class CuttingListReportParser : IReportParser
    {
        private readonly StringBuilder _stringBuilder = new StringBuilder();
        
        public string ToStringReport(Order order)
        {
            AddReportGeneratedConfirmation();
            AddReportHeader(order);
            AddShapeQuantityTable(order);
            return _stringBuilder.ToString();
        }

        private void AddReportGeneratedConfirmation()
        {
            _stringBuilder.AppendLine("Your cutting list has been generated:");
            _stringBuilder.AppendLine();
        }

        private void AddReportHeader(Order order)
        {
            var reportHeader =
                $"Name: {order.CustomerName} " +
                $"Address: {order.CustomerAddress} " +
                $"Due Date: {order.DueDate:d MMM yyyy} " +
                $"Order #: {order.OrderNumber:0000}";
            _stringBuilder.AppendLine(reportHeader);
            _stringBuilder.AppendLine();
        }
        
        private void AddShapeQuantityTable(Order order)
        {
            var headers = new[] {"", "Qty"};
            var shapes = Enum.GetValues(typeof(Shape));
            var rows = from Shape shape in shapes select new[] {shape.ToString(), GetShapeCount(order.Blocks, shape)};
            var table = rows.ToStringTable(headers);
            _stringBuilder.Append(table);
        }
        
        private static string GetShapeCount(IEnumerable<Block> blocks, Shape shape)
        {
            var count = blocks.Count(block => block.Shape == shape);
            return count == 0 ? "-" : count.ToString();
        }
    }
}
