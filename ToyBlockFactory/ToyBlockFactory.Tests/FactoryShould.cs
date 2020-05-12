using System;
using System.IO;
using System.Linq;
using Moq;
using Xunit;

namespace ToyBlockFactory.Tests
{
    public class FactoryShould
    {
        private readonly Mock<TextReader> _mockConsoleInput;
        private readonly Mock<TextWriter> _mockConsoleOutput;
        private readonly Factory _factory;
        
        public FactoryShould()
        {
            _mockConsoleInput = new Mock<TextReader>();
            _mockConsoleOutput = new Mock<TextWriter>();
            _factory = new Factory(_mockConsoleInput.Object, _mockConsoleOutput.Object);
        }
        
        [Fact]
        public void WelcomeUserOnStart()
        {
            _factory.Start();
            
            _mockConsoleOutput.Verify(m => m.WriteLine("Welcome to the Toy Block Factory!"), Times.Once);
        }

        [Fact]
        public void AddOrderFromInput()
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
            
            _factory.TakeOrder();

            var order = _factory.Orders.First();
            Assert.Equal(expectedDueDate, order.DueDate);
            Assert.Equal(7, order.Blocks.Count());
            Assert.Equal(2, order.Blocks.Count(b => b.Shape == Shape.Square));
            Assert.Equal(2, order.Blocks.Count(b => b.Shape == Shape.Triangle));
            Assert.Equal(3, order.Blocks.Count(b => b.Shape == Shape.Circle));
            Assert.Equal(1, order.Blocks.Count(b => b.Colour == Colour.Red));
            Assert.Equal(3, order.Blocks.Count(b => b.Colour == Colour.Blue));
            Assert.Equal(3, order.Blocks.Count(b => b.Colour == Colour.Yellow));
        }
    }
}