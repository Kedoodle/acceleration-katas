using System;
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
            
            var locationMock = Mock.Of<ILocation>(c => 
                c.X == 1 &&
                c.Y == 3);
            var roverMock = Mock.Of<IRover>(r => 
                r.Location == locationMock &&
                r.Direction == Direction.North);
            var worldFormatter = new WorldFormatter(roverMock, Mock.Of<IGrid>());
            var actualSummary = worldFormatter.FormatRoverStatusSummary();
            
            Assert.Equal(expectedSummary, actualSummary);
        }

        [Fact]
        public void FormatWorld()
        {
            var expectedWorld = "..." + Environment.NewLine +
                                         "..." + Environment.NewLine +
                                         "N..";
            
            var grid = new Grid(3, 3);
            var rover = new Rover();
            var location = grid.GetLocation(0, 0);
            rover.DropOnGrid(grid, location, Direction.North);
            var worldFormatter = new WorldFormatter(rover, grid);
            var actualWorld = worldFormatter.FormatWorld();
            
            Assert.Equal(expectedWorld, actualWorld);
        }
    }
}