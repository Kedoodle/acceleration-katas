using System;
using System.IO;
using System.Linq;
using System.Text;

namespace ToyBlockFactory
{
    public class ConsoleReportGenerator : IReportGenerator
    {
        private readonly TextWriter _output;
        private readonly StringBuilder _stringBuilder;

        public ConsoleReportGenerator(TextWriter output)
        {
            _output = output;
            _stringBuilder = new StringBuilder();
        }
        
        public void GenerateInvoiceReport(Order order)
        {
            _output.WriteLine("Your invoice report has been generated:");
            _output.WriteLine();
            _output.WriteLine(GetReportHeader(order));
            _output.WriteLine();
            _output.WriteLine(GetBlockShapeAndColourQuantityTable(order));
            _output.WriteLine();
            _output.WriteLine(GetChargesSummary(order));
        }

        private static string GetReportHeader(Order order)
        {
            return $"Name: {order.CustomerName} Address: {order.CustomerAddress} Due Date: {order.DueDate:d MMM yyyy} Order #: {order.OrderNumber:0000}";
        }

        private string GetBlockShapeAndColourQuantityTable(Order order)
        {
            _stringBuilder.Clear();
            AddBlockShapeAndColourQuantityTableHeaders();
            AddBlockShapeAndColourQuantityTableRows(order);
            return _stringBuilder.ToString();
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

        private string GetChargesSummary(Order order)
        {
            _stringBuilder.Clear();
            
            const int formatWidth = 23;
            AddShapeCharges(order, formatWidth);
            AddRedColourSurcharge(order, formatWidth);

            return _stringBuilder.ToString();
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