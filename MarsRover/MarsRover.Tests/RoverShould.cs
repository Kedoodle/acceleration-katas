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
    }
}