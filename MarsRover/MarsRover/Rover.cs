using System;
using System.ComponentModel;

namespace MarsRover
{
    public class Rover
    {
        private IGrid Grid { get; set; }
        public ICoordinate Coordinate { get; private set; }
        public Direction Direction { get; private set; }

        public void DropOnGrid(IGrid grid, ICoordinate coordinate, Direction direction)
        {
            Grid = grid;
            Coordinate = coordinate;
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
                _ => throw new InvalidEnumArgumentException()
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
                _ => throw new InvalidEnumArgumentException()
            };
        }
        
        public void MoveForward()
        {
            Coordinate = Grid.GetAdjacentCoordinateTo(Coordinate, Direction);
        }      
        
        public void MoveBackward()
        {
            var backwardDirection = GetBackwardDirection(Direction);
            Coordinate = Grid.GetAdjacentCoordinateTo(Coordinate, backwardDirection);
        }

        private static Direction GetBackwardDirection(Direction direction)
        {
            return direction switch
            {
                Direction.North => Direction.South,
                Direction.South => Direction.North,
                Direction.East => Direction.West,
                Direction.West => Direction.East,
                _ => throw new InvalidEnumArgumentException()
            };
        }
    }
}
