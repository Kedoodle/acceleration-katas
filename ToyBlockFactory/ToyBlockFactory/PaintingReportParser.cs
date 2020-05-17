using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToyBlockFactory
{
    public class PaintingReportParser : IReportParser
    {
        private readonly StringBuilder _stringBuilder = new StringBuilder();
        public string ToStringReport(Order order)
        {
            AddReportGeneratedConfirmation();
            AddReportHeader(order);
            AddBlockQuantityTable(order);
            return _stringBuilder.ToString();
        }

        private void AddReportGeneratedConfirmation()
        {
            _stringBuilder.AppendLine("Your painting report has been generated:");
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
        
        private void AddBlockQuantityTable(Order order)
        {
            var headers = new[] {""}.Concat(Enum.GetNames(typeof(Colour))).ToArray();
            var shapes = Enum.GetValues(typeof(Shape));
            var rows = from Shape shape in shapes select new[] {shape.ToString()}.Concat(GetBlockShapeAndColourCounts(order.Blocks, shape));
            var table = rows.ToStringTable(headers);
            _stringBuilder.Append(table);
        }
        
        private static IEnumerable<string> GetBlockShapeAndColourCounts(IReadOnlyCollection<Block> blocks, Shape shape)
        {
            var colours = Enum.GetValues(typeof(Colour));
            return colours.Cast<Colour>().Select(colour => GetBlockCount(blocks, shape, colour));
        }

        private static string GetBlockCount(IReadOnlyCollection<Block> blocks, Shape shape, Colour colour)
        {
            return CountBlocks(blocks, shape, colour) == 0 ? "-" : CountBlocks(blocks, shape, colour).ToString();
        }

        private static int CountBlocks(IEnumerable<Block> blocks, Shape shape, Colour colour)
        {
            return blocks.Count(block => block.Shape == shape && block.Colour == colour);
        }
    }
}