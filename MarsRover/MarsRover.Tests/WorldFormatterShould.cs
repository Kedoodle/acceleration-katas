using Moq;
using Xunit;

namespace MarsRover.Tests
{
    public class WorldFormatterShould
    {
        [Fact]
        public void FormatRoverStatusSummary()
        {
            const string expectedSummary = "The rover is currently at (1, 3) facing North.";
            
            var coordinateMock = Mock.Of<ICoordinate>(c => 
                c.X == 1 &&
                c.Y == 3);
            var roverMock = Mock.Of<IRover>(r => 
                r.Coordinate == coordinateMock &&
                r.Direction == Direction.North);
            var actualSummary = WorldFormatter.FormatRoverStatusSummary(roverMock);
            
            Assert.Equal(expectedSummary, actualSummary);
        }
    }
}