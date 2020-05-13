using System;
using System.Collections.Generic;
using System.IO;
using Moq;
using Xunit;

namespace ToyBlockFactory.Tests
{
    public class ConsoleReportGeneratorShould
    {
        private readonly Mock<TextWriter> _mockConsoleOutput;
        private readonly ConsoleReportGenerator _consoleReportGenerator;
        private readonly Order _order;

        public ConsoleReportGeneratorShould()
        {
            _mockConsoleOutput = new Mock<TextWriter>();
            _consoleReportGenerator = new ConsoleReportGenerator(_mockConsoleOutput.Object);
            _order = new Order
            {
                CustomerName = "Mark Pearl",
                CustomerAddress = "1 Bob Avenue, Auckland",
                DueDate = new DateTime(2019, 1, 19),
                OrderNumber = 1,
                Blocks = new List<Block>
                {
                    new Block(Shape.Square, Colour.Red),
                    new Block(Shape.Square, Colour.Yellow),
                    new Block(Shape.Triangle, Colour.Blue),
                    new Block(Shape.Triangle, Colour.Blue),
                    new Block(Shape.Circle, Colour.Blue),
                    new Block(Shape.Circle, Colour.Yellow),
                    new Block(Shape.Circle, Colour.Yellow)
                }
            };
        }
        
        [Fact]
        public void GenerateInvoiceReports()
        {
            const string expectedConfirmation = "Your invoice report has been generated:";
            const string expectedHeader = "Name: Mark Pearl Address: 1 Bob Avenue, Auckland Due Date: 19 Jan 2019 Order #: 0001";
            var expectedTable = 
                "|          | Red | Blue | Yellow |" + Environment.NewLine + 
                "|----------|-----|------|--------|" + Environment.NewLine +
                "| Square   | 1   | -    | 1      |" + Environment.NewLine +
                "| Triangle | -   | 2    | -      |" + Environment.NewLine +
                "| Circle   | -   | 1    | 2      |" + Environment.NewLine;
            var expectedCharges =
                "Squares                2 @ $1 each = $2" + Environment.NewLine +
                "Triangles              2 @ $2 each = $4" + Environment.NewLine +
                "Circles                3 @ $3 each = $9" + Environment.NewLine +
                "Red colour surcharge   1 @ $1 each = $1";
                
            _consoleReportGenerator.GenerateInvoiceReport(_order);
            
            _mockConsoleOutput.Verify(m => m.WriteLine(expectedConfirmation), Times.Once);
            _mockConsoleOutput.Verify(m => m.WriteLine(expectedHeader), Times.Once);
            _mockConsoleOutput.Verify(m => m.WriteLine(expectedTable), Times.Once);
            _mockConsoleOutput.Verify(m => m.WriteLine(expectedCharges), Times.Once);
        }
        
        [Fact]
        public void GenerateCuttingListReports()
        {
            
        }
        
        [Fact]
        public void GeneratePaintingReports()
        {
            
        }
    }
}