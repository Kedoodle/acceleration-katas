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
            var stubLocation = Mock.Of<ILocation>();

            _rover.DropOnGrid(stubGrid, stubLocation, startingDirection);
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
            var stubLocation = Mock.Of<ILocation>();

            _rover.DropOnGrid(stubGrid, stubLocation, startingDirection);
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
            var stubStartingLocation = Mock.Of<ILocation>();
            var stubEndingLocation = Mock.Of<ILocation>();
            var stubGrid = Mock.Of<IGrid>(grid =>
                grid.GetAdjacentLocationTo(It.IsAny<ILocation>(), It.IsAny<Direction>()) == stubEndingLocation);
            
            _rover.DropOnGrid(stubGrid, stubStartingLocation, direction);
            Assert.Equal(stubStartingLocation, _rover.Location);
            
            var hasMoved = _rover.MoveForward();
            Assert.True(hasMoved);
            Assert.Equal(stubEndingLocation, _rover.Location);
        }
        
        [Theory]
        [InlineData(Direction.North)]
        [InlineData(Direction.South)]
        [InlineData(Direction.East)]
        [InlineData(Direction.West)]
        public void MoveBackward(Direction direction)
        {
            var stubStartingLocation = Mock.Of<ILocation>();
            var stubEndingLocation = Mock.Of<ILocation>();
            var stubGrid = Mock.Of<IGrid>(grid =>
                grid.GetAdjacentLocationTo(It.IsAny<ILocation>(), It.IsAny<Direction>()) == stubEndingLocation);
            
            _rover.DropOnGrid(stubGrid, stubStartingLocation, direction);
            Assert.Equal(stubStartingLocation, _rover.Location);
            
            var hasMoved = _rover.MoveBackward();
            Assert.True(hasMoved);
            Assert.Equal(stubEndingLocation, _rover.Location);
        }

        [Fact]
        public void NotMoveWhenObstacleDetected()
        {
            var stubStartingLocation = Mock.Of<ILocation>();
            var stubEndingLocation = Mock.Of<ILocation>(location => location.HasObstacle() == true);
            var stubGrid = Mock.Of<IGrid>(grid =>
                grid.GetAdjacentLocationTo(It.IsAny<ILocation>(), It.IsAny<Direction>()) == stubEndingLocation);
            
            _rover.DropOnGrid(stubGrid, stubStartingLocation, It.IsAny<Direction>());
            Assert.Equal(stubStartingLocation, _rover.Location);
            
            var hasMoved = _rover.MoveForward();
            Assert.False(hasMoved);
            Assert.Equal(stubStartingLocation, _rover.Location);
            
            hasMoved = _rover.MoveBackward();
            Assert.False(hasMoved);
            Assert.Equal(stubStartingLocation, _rover.Location);
            
        }
    }
}
