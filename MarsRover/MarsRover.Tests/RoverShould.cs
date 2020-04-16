using Moq;
using Xunit;

namespace MarsRover.Tests
{
    public class RoverShould
    {
        private readonly Rover _rover;

        public RoverShould()
        {
            _rover = new Rover();
        }

        [Theory]
        [InlineData(Direction.North, Direction.West)]
        [InlineData(Direction.South, Direction.East)]
        [InlineData(Direction.East, Direction.North)]
        [InlineData(Direction.West, Direction.South)]
        public void TurnLeft(Direction startingDirection, Direction expectedDirection)
        {
            var stubGrid = Mock.Of<IGrid>();
            var stubCoordinate = Mock.Of<ICoordinate>();

            _rover.DropOnGrid(stubGrid, stubCoordinate, startingDirection);
            _rover.TurnLeft();

            Assert.Equal(expectedDirection, _rover.Direction);
        }

        [Theory]
        [InlineData(Direction.North, Direction.East)]
        [InlineData(Direction.South, Direction.West)]
        [InlineData(Direction.East, Direction.South)]
        [InlineData(Direction.West, Direction.North)]
        public void TurnRight(Direction startingDirection, Direction expectedDirection)
        {
            var stubGrid = Mock.Of<IGrid>();
            var stubCoordinate = Mock.Of<ICoordinate>();

            _rover.DropOnGrid(stubGrid, stubCoordinate, startingDirection);
            _rover.TurnRight();

            Assert.Equal(expectedDirection, _rover.Direction);
        }

        [Theory]
        [InlineData(Direction.North)]
        [InlineData(Direction.South)]
        [InlineData(Direction.East)]
        [InlineData(Direction.West)]
        public void MoveForward(Direction direction)
        {
            var stubStartingCoordinate = Mock.Of<ICoordinate>();
            var stubEndingCoordinate = Mock.Of<ICoordinate>();
            var stubGrid = Mock.Of<IGrid>(grid =>
                grid.GetAdjacentCoordinateTo(It.IsAny<ICoordinate>(), It.IsAny<Direction>()) == stubEndingCoordinate);
            
            _rover.DropOnGrid(stubGrid, stubStartingCoordinate, direction);
            Assert.Equal(stubStartingCoordinate, _rover.Coordinate);
            
            _rover.MoveForward();
            Assert.Equal(stubEndingCoordinate, _rover.Coordinate);
        }
        
        [Theory]
        [InlineData(Direction.North)]
        [InlineData(Direction.South)]
        [InlineData(Direction.East)]
        [InlineData(Direction.West)]
        public void MoveBackward(Direction direction)
        {
            var stubStartingCoordinate = Mock.Of<ICoordinate>();
            var stubEndingCoordinate = Mock.Of<ICoordinate>();
            var stubGrid = Mock.Of<IGrid>(grid =>
                grid.GetAdjacentCoordinateTo(It.IsAny<ICoordinate>(), It.IsAny<Direction>()) == stubEndingCoordinate);
            
            _rover.DropOnGrid(stubGrid, stubStartingCoordinate, direction);
            Assert.Equal(stubStartingCoordinate, _rover.Coordinate);
            
            _rover.MoveBackward();
            Assert.Equal(stubEndingCoordinate, _rover.Coordinate);
        }
    }
}
