using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToyBlockFactory.ReportGenerator
{
    public class InvoiceReportParser : IReportParser
    {
        private readonly StringBuilder _stringBuilder = new StringBuilder();
        
        public string ToStringReport(Order order)
        {
            AddReportGeneratedConfirmation();
            AddReportHeader(order);
            AddBlockQuantityTable(order);
            AddChargesSummary(order);
            return _stringBuilder.ToString();
        }

        private void AddReportGeneratedConfirmation()
        {
            _stringBuilder.AppendLine("Your invoice report has been generated:");
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
            _stringBuilder.AppendLine(table);
            _stringBuilder.AppendLine();
        }
        
        private static IEnumerable<string> GetBlockShapeAndColourCounts(IReadOnlyCollection<Block> blocks, Shape shape)
        {
            var colours = Enum.GetValues(typeof(Colour));
            return colours.Cast<Colour>().Select(colour => GetBlockCount(blocks, shape, colour));
        }

        private static string GetBlockCount(IEnumerable<Block> blocks, Shape shape, Colour colour)
        {
            var count = blocks.Count(block => block.Shape == shape && block.Colour == colour);
            return count == 0 ? "-" : count.ToString();
        }
        
        private void AddChargesSummary(Order order)
        {
            const int formatWidth = 23;
            AddShapeCharges(order, formatWidth);
            AddRedColourSurcharge(order, formatWidth);
        }
        private void AddShapeCharges(Order order, int formatWidth)
        {
            foreach (Shape shape in Enum.GetValues(typeof(Shape)))
            {
                _stringBuilder.AppendFormat($"{{0, {-formatWidth}}}", shape + "s");
                var quantity = order.Blocks.Count(b => b.Shape == shape);
                var price = ShapeExtensions.GetPrice(shape);
                var subtotal = quantity * price;
                _stringBuilder.AppendLine($"{quantity} @ ${price} each = ${subtotal}");
            }
        }

        private void AddRedColourSurcharge(Order order, int formatWidth)
        {
            _stringBuilder.AppendFormat($"{{0, {-formatWidth}}}", "Red colour surcharge");
            var quantity = order.Blocks.Count(b => b.Colour == Colour.Red);
            var price = ColourExtensions.GetPrice(Colour.Red);
            var subtotal = quantity * price;
            _stringBuilder.AppendLine($"{quantity} @ ${price} each = ${subtotal}");
        }
    }
}
