using System;
using System.ComponentModel;

namespace MarsRover
{
    public class Rover : IRover
    {
        private IGrid Grid { get; set; }
        public ILocation Location { get; private set; }
        public Direction Direction { get; private set; }

        public void DropOnGrid(IGrid grid, ILocation location, Direction direction)
        {
            Grid = grid;
            Location = location;
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
        
        public bool MoveForward()
        {
            var targetLocation = Grid.GetAdjacentLocationTo(Location, Direction);
            if (targetLocation.HasObstacle()) return false;
            
            Location = targetLocation;
            return true;
        }      
        
        public bool MoveBackward()
        {
            var backwardDirection = GetBackwardDirection(Direction);
            var targetLocation = Grid.GetAdjacentLocationTo(Location, backwardDirection);
            if (targetLocation.HasObstacle()) return false;

            Location = targetLocation;
            return true;
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
