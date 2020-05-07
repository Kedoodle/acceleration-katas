using System.IO;
using Moq;
using Xunit;

namespace Minesweeper.Tests
{
    public class ConsoleInputGetterShould
    {
        [Theory]
        [InlineData("44")]
        [InlineData("35")]
        [InlineData("00")]
        public void RequestFieldDimensions(string expectedDimensions)
        {
            var mockInputStream = Mock.Of<TextReader>(i => i.ReadLine() == expectedDimensions);
            var consoleInputGetter = new ConsoleInputGetter(mockInputStream);
            
            Assert.Equal(expectedDimensions, consoleInputGetter.ReadLine());
        }
    }
}