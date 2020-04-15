using System;

namespace MarsRover
{
    public class Rover
    {
        public Direction Direction { get; private set; }

        public Rover(Direction direction)
        {
            Direction = direction;
        }

        public void TurnLeft()
        {
            Direction = Direction switch
            {
                Direction.North => Direction.West,
                Direction.South => Direction.East,
                Direction.East => Direction.North,
                Direction.West => Direction.South,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public void TurnRight()
        {
            Direction = Direction switch
            {
                Direction.North => Direction.East,
                Direction.South => Direction.West,
                Direction.East => Direction.South,
                Direction.West => Direction.North,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}