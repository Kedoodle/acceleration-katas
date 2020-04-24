using System.Linq;
using Xunit;

namespace MarsRover.Tests
{
    public class GridShould
    {
        private readonly Grid _grid;
        
        public GridShould()
        {
            const int width = 5;
            const int height = 5;
            _grid = new Grid(width, height);
        }
        
        [Fact]
        public void NotHaveObstaclesWhenInitialised()
        {
            Assert.False(_grid.HasObstacles());
        }

        [Fact]
        public void HaveObstaclesAdded()
        {
            _grid.AddObstacle(1, 1, ObstacleType.Tree);
            
            Assert.True(_grid.HasObstacles());
        }

        [Theory]
        [InlineData(Direction.North, 2, 3)]
        [InlineData(Direction.South, 2, 1)]
        [InlineData(Direction.East, 3, 2)]
        [InlineData(Direction.West, 1, 2)]
        public void GetAdjacentLocations(Direction direction, int expectedX, int expectedY)
        {
            var location = _grid.GetLocation(2, 2);
            var adjacentLocation = _grid.GetAdjacentLocationTo(location, direction);
            
            Assert.Equal(expectedX, adjacentLocation.X);
            Assert.Equal(expectedY, adjacentLocation.Y);
        }
        
        [Theory]
        [InlineData(2, 4, Direction.North, 2, 0)]
        [InlineData(2, 0, Direction.South, 2, 4)]
        [InlineData(4, 2, Direction.East, 0, 2)]
        [InlineData(0, 2, Direction.West, 4, 2)]
        public void WrapLocationsAroundEdge(int baseX, int baseY, Direction direction, int expectedX, int expectedY)
        {
            var location = _grid.GetLocation(baseX, baseY);
            var adjacentLocation = _grid.GetAdjacentLocationTo(location, direction);
            
            Assert.Equal(expectedX, adjacentLocation.X);
            Assert.Equal(expectedY, adjacentLocation.Y);
        }
    }
}
