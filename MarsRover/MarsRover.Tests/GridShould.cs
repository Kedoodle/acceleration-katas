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
        
        // [Theory]
        // [InlineData(0, 3, Direction.North)]
        // [InlineData(1, 2, Direction.South)]
        // [InlineData(2, 1, Direction.East)]
        // [InlineData(3, 0, Direction.West)]
        // public void HaveDirectionOrientedRoverAtPlacedCoordinate(int x, int y, Direction direction)
        // {
        //     _grid.PlaceRover(x, y, direction);
        //     var roverCoordinate = _grid.GetRoverCoordinate();
        //     
        //     Assert.Equal(direction, _grid.Rover.Direction);
        //     Assert.True(roverCoordinate.HasRover);
        //     Assert.Equal(x, roverCoordinate.X);
        //     Assert.Equal(y, roverCoordinate.Y);
        // }
    }
}