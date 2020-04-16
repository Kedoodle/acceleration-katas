using System;
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

        // [Theory]
        // [InlineData(2, 2, Direction.North, 2, 3)]
        // [InlineData(2, 2, Direction.South, 2, 1)]
        // [InlineData(2, 2, Direction.East, 3, 2)]
        // [InlineData(2, 2, Direction.West, 1, 2)]
        // public void MoveForwardInFacingDirectionOnGrid(int startingX, int startingY, Direction direction, int expectedX, int expectedY)
        // {
        //     const int width = 5;
        //     const int height = 5;
        //     var grid = new Grid(width, height);
        //     
        //     _rover.MoveForward(grid);
        //     
        //     Assert.False(grid.GetCoordinate(startingX, startingY).HasRover);
        //     Assert.Equal(expectedX, grid.GetRoverCoordinate().X);
        //     Assert.Equal(expectedY, grid.GetRoverCoordinate().Y);
        // }
    }
}