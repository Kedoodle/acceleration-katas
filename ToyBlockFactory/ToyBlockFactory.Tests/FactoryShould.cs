using System.IO;
using Moq;
using Xunit;

namespace ToyBlockFactory.Tests
{
    public class FactoryShould
    {
        private readonly Mock<TextReader> _mockConsoleInput;
        private readonly Mock<TextWriter> _mockConsoleOutput;
        private readonly ConsoleOrderTaker _consoleOrderTaker;
        private readonly ConsoleReportGenerator _consoleReportGenerator;
        private readonly Factory _factory;
        
        public FactoryShould()
        {
            _mockConsoleInput = new Mock<TextReader>();
            _mockConsoleOutput = new Mock<TextWriter>();
            _consoleOrderTaker = new ConsoleOrderTaker(_mockConsoleInput.Object, _mockConsoleOutput.Object);
            _consoleReportGenerator = new ConsoleReportGenerator(_mockConsoleOutput.Object);
            _factory = new Factory(_consoleOrderTaker, _consoleReportGenerator);
        }
    }
}