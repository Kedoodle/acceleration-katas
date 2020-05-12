
using System.IO;
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
        public void WelcomesUserOnStart()
        {
            _factory.Start();
            
            _mockConsoleOutput.Verify(m => m.WriteLine("Welcome to the Toy Block Factory!"), Times.Once);
        }
    }
}