using tictactoe;
using Xunit;

namespace tictactoe_tests
{
    public class ConsoleInputParserTests
    {
        [Fact]
        public void StringCoordinates_ParsedToIntValues()
        {
            const int expectedX = 0, expectedY = 1;

            const string userInput = "1,2";
            var successfulParse = ConsoleInputParser.TryParseCoordinates(userInput, out var actualX, out var actualY);
            
            Assert.True(successfulParse);
            Assert.Equal(expectedX, actualX);
            Assert.Equal(expectedY, actualY);
        }
        
        [Theory]
        [InlineData("a,b")]
        [InlineData("a,")]
        [InlineData(",b")]
        [InlineData(",")]
        [InlineData(",,")]
        [InlineData(" , ")]
        public void TryParse_InvalidStringCoordinates_ReturnsFalse(string userInput)
        {
            var successfulParse = ConsoleInputParser.TryParseCoordinates(userInput, out var actualX, out var actualY);
            
            Assert.False(successfulParse);
        }
    }
}