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
            ConsoleInputParser.TryParseCoordinates(userInput, out var actualX, out var actualY);
            
            Assert.Equal(expectedX, actualX);
            Assert.Equal(expectedY, actualY);
        }
    }
}