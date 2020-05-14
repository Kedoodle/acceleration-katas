using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToyBlockFactory
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
            AddBlockShapeAndColourQuantityTableHeaders();
            AddBlockShapeAndColourQuantityTableRows(order);
            _stringBuilder.AppendLine();
            
            // var headers = new[] {""}.Concat(Enum.GetNames(typeof(Colour)));
            // var shapes = Enum.GetValues(typeof(Shape));
            // var rows = from Shape shape in shapes select new[] {shape.ToString()}.Concat(GetBlockShapeAndColourCounts(blocks, shape));
            // return "";
        }
        
        private void AddBlockShapeAndColourQuantityTableHeaders()
        {
            var longestShape = Enum.GetNames(typeof(Shape)).Max(shape => shape.Length);

            _stringBuilder.AppendFormat($"| {{0, {-longestShape}}} |", "");
            foreach (Colour colour in Enum.GetValues(typeof(Colour)))
            {
                var width = colour.ToString().Length;
                _stringBuilder.AppendFormat($" {{0, {-width}}} |", colour);
            }
            _stringBuilder.AppendLine();

            _stringBuilder.Append(string.Format($"| {{0, {longestShape}}} |", "").Replace(' ', '-'));
            foreach (Colour colour in Enum.GetValues(typeof(Colour)))
            {
                var width = colour.ToString().Length;
                _stringBuilder.Append(string.Format($" {{0, {width}}} |", "").Replace(' ', '-'));
            }
            _stringBuilder.AppendLine();
        }

        private void AddBlockShapeAndColourQuantityTableRows(Order order)
        {
            var longestShape = Enum.GetNames(typeof(Shape)).Max(shape => shape.Length);
            foreach (Shape shape in Enum.GetValues(typeof(Shape)))
            {
                _stringBuilder.AppendFormat($"| {{0, {-longestShape}}} |", shape);
                foreach (Colour colour in Enum.GetValues(typeof(Colour)))
                {
                    var width = colour.ToString().Length;
                    var quantity = order.Blocks.Count(b => b.Shape == shape && b.Colour == colour);
                    _stringBuilder.AppendFormat($" {{0, {-width}}} |", quantity == 0 ? "-" : quantity.ToString());
                }
                _stringBuilder.AppendLine();
            }
        }
        
        // private static IEnumerable<string> GetBlockShapeAndColourCounts(IEnumerable<Block> blocks, Shape shape)
        // {
        //     var colours = Enum.GetValues(typeof(Colour));
        //     return colours.Cast<Colour>().Select(colour => CountBlocks(blocks, shape, colour).ToString());
        // }
        //
        // private static int CountBlocks(IEnumerable<Block> blocks, Shape shape, Colour colour)
        // {
        //     return blocks.Count(block => block.Shape == shape && block.Colour == colour);
        // }

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
            _stringBuilder.Append($"{quantity} @ ${price} each = ${subtotal}");
        }
    }
}