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
        public void BeEmptyWhenInitialised()
        {
            Assert.True(_grid.IsEmpty());
        }

        [Fact]
        public void NotBeEmptyWhenObstacleAdded()
        {
            var coordinate = _grid.GetCoordinate(1, 1);
            Grid.AddObstacle(ObstacleType.Tree, coordinate);
            
            Assert.False(_grid.IsEmpty());
        }

        [Theory]
        [InlineData(Direction.North, 2, 3)]
        [InlineData(Direction.South, 2, 1)]
        [InlineData(Direction.East, 3, 2)]
        [InlineData(Direction.West, 1, 2)]
        public void GetAdjacentCoordinates(Direction direction, int expectedX, int expectedY)
        {
            var coordinate = _grid.GetCoordinate(2, 2);
            var adjacentCoordinate = _grid.GetAdjacentCoordinateTo(coordinate, direction);
            
            Assert.Equal(expectedX, adjacentCoordinate.X);
            Assert.Equal(expectedY, adjacentCoordinate.Y);
        }
        
        [Theory]
        [InlineData(2, 4, Direction.North, 2, 0)]
        [InlineData(2, 0, Direction.South, 2, 4)]
        [InlineData(4, 2, Direction.East, 0, 2)]
        [InlineData(0, 2, Direction.West, 4, 2)]
        public void WrapCoordinatesAroundEdge(int baseX, int baseY, Direction direction, int expectedX, int expectedY)
        {
            var coordinate = _grid.GetCoordinate(baseX, baseY);
            var adjacentCoordinate = _grid.GetAdjacentCoordinateTo(coordinate, direction);
            
            Assert.Equal(expectedX, adjacentCoordinate.X);
            Assert.Equal(expectedY, adjacentCoordinate.Y);
        }
    }
}
