using System;
using System.IO;
using System.Linq;
using Moq;
using Xunit;

namespace ToyBlockFactory.Tests
{
    public class ConsoleOrderTakerShould
    {
        
        private readonly Mock<TextReader> _mockConsoleInput;
        private readonly Mock<TextWriter> _mockConsoleOutput;
        private readonly ConsoleOrderTaker _consoleOrderTaker;

        public ConsoleOrderTakerShould()
        {
            _mockConsoleInput = new Mock<TextReader>();
            _mockConsoleOutput = new Mock<TextWriter>();
            _consoleOrderTaker = new ConsoleOrderTaker(_mockConsoleInput.Object, _mockConsoleOutput.Object);
        }
        
        [Fact]
        public void GetOrderFromInput()
        {
            var expectedDueDate = new DateTime(2019, 1, 19);
            _mockConsoleInput.SetupSequence(m => m.ReadLine())
                .Returns("Mark Pearl") // Name
                .Returns("1 Bob Avenue, Auckland") // Address
                .Returns("19 Jan 2019") // Date
                .Returns("1") // Red squares
                .Returns("") // Blue squares
                .Returns("1") // Yellow squares
                .Returns("") // Red triangles
                .Returns("2") // Blue triangles
                .Returns("") // Yellow triangles
                .Returns("") // Red circles
                .Returns("1") // Blue circles
                .Returns("2"); // Yellow circles
            
            var order = _consoleOrderTaker.TakeOrder();
            
            Assert.Equal(expectedDueDate, order.DueDate);
            Assert.Equal(7, order.Blocks.Count);
            Assert.Equal(2, order.Blocks.Count(b => b.Shape == Shape.Square));
            Assert.Equal(2, order.Blocks.Count(b => b.Shape == Shape.Triangle));
            Assert.Equal(3, order.Blocks.Count(b => b.Shape == Shape.Circle));
            Assert.Equal(1, order.Blocks.Count(b => b.Colour == Colour.Red));
            Assert.Equal(3, order.Blocks.Count(b => b.Colour == Colour.Blue));
            Assert.Equal(3, order.Blocks.Count(b => b.Colour == Colour.Yellow));
            
            _mockConsoleOutput.Verify(m => m.Write("Please input your Name: "), Times.Once);
            _mockConsoleOutput.Verify(m => m.Write("Please input your Address: "), Times.Once);
            _mockConsoleOutput.Verify(m => m.Write("Please input your Due Date: "), Times.Once);
            _mockConsoleOutput.Verify(m => m.Write("Please input the number of Red Squares: "), Times.Once);
            _mockConsoleOutput.Verify(m => m.Write("Please input the number of Blue Squares: "), Times.Once);
            _mockConsoleOutput.Verify(m => m.Write("Please input the number of Yellow Squares: "), Times.Once);
            _mockConsoleOutput.Verify(m => m.Write("Please input the number of Red Triangles: "), Times.Once);
            _mockConsoleOutput.Verify(m => m.Write("Please input the number of Blue Triangles: "), Times.Once);
            _mockConsoleOutput.Verify(m => m.Write("Please input the number of Yellow Triangles: "), Times.Once);
            _mockConsoleOutput.Verify(m => m.Write("Please input the number of Red Circles: "), Times.Once);
            _mockConsoleOutput.Verify(m => m.Write("Please input the number of Blue Circles: "), Times.Once);
            _mockConsoleOutput.Verify(m => m.Write("Please input the number of Yellow Circles: "), Times.Once);
        }
    }
}
