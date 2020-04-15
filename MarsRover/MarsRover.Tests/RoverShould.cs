using System;
using Xunit;

namespace MarsRover.Tests
{
    public class RoverShould
    {
        [Theory]
        [InlineData(Direction.North, Direction.West)]
        [InlineData(Direction.South, Direction.East)]
        [InlineData(Direction.East, Direction.North)]
        [InlineData(Direction.West, Direction.South)]
        public void TurnLeft(Direction startingDirection, Direction expectedDirection)
        {
            var rover = new Rover(startingDirection);
            rover.TurnLeft();
            
            Assert.Equal(expectedDirection, rover.Direction);
        }
        
        [Theory]
        [InlineData(Direction.North, Direction.East)]
        [InlineData(Direction.South, Direction.West)]
        [InlineData(Direction.East, Direction.South)]
        [InlineData(Direction.West, Direction.North)]
        public void TurnRight(Direction startingDirection, Direction expectedDirection)
        {
            var rover = new Rover(startingDirection);
            rover.TurnRight();
            
            Assert.Equal(expectedDirection, rover.Direction);
        }

        [Theory]
        [InlineData(2, 2, Direction.North, 2, 3)]
        [InlineData(2, 2, Direction.South, 2, 1)]
        [InlineData(2, 2, Direction.East, 3, 2)]
        [InlineData(2, 2, Direction.West, 1, 2)]
        public void MoveForwardInFacingDirectionOnGrid(int startingX, int startingY, Direction direction, int expectedX, int expectedY)
        {
            const int width = 5;
            const int height = 5;
            var grid = new Grid(width, height);
            grid.PlaceRover(startingX, startingY, direction);
            grid.Rover.MoveForward(grid);
            
            Assert.False(grid.GetCoordinate(startingX, startingY).HasRover);
            Assert.Equal(expectedX, grid.GetRoverCoordinate().X);
            Assert.Equal(expectedY, grid.GetRoverCoordinate().Y);
        }
        
        [Theory]
        [InlineData(2, 2, Direction.North, 2, 1)]
        [InlineData(2, 2, Direction.South, 2, 3)]
        [InlineData(2, 2, Direction.East, 1, 2)]
        [InlineData(2, 2, Direction.West, 3, 2)]
        public void MoveBackwardInFacingDirectionOnGrid(int startingX, int startingY, Direction direction, int expectedX, int expectedY)
        {
            const int width = 5;
            const int height = 5;
            var grid = new Grid(width, height);
            grid.PlaceRover(startingX, startingY, direction);
            grid.Rover.MoveBackward(grid);
            
            Assert.False(grid.GetCoordinate(startingX, startingY).HasRover);
            Assert.Equal(expectedX, grid.GetRoverCoordinate().X);
            Assert.Equal(expectedY, grid.GetRoverCoordinate().Y);
        }
    }
}