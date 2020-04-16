using System;

namespace MarsRover
{
    public class Rover
    {
        public IGrid Grid { get; private set; }
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

        // public void MoveForward(Grid grid)
        // {
        //     var oldCoordinate = grid.GetRoverCoordinate();
        //     oldCoordinate.HasRover = false;
        //
        //     var newX = oldCoordinate.X;
        //     var newY = oldCoordinate.Y;
        //     
        //     switch (Direction)
        //     {
        //         case Direction.North:
        //             newY++;
        //             break;
        //         case Direction.South:
        //             newY--;
        //             break;
        //         case Direction.East:
        //             newX++;
        //             break;
        //         case Direction.West:
        //             newX--;
        //             break;
        //         default:
        //             throw new ArgumentOutOfRangeException();
        //     }
        //
        //     grid.GetCoordinate(newX, newY).HasRover = true;
        // }
        //
        // public void MoveBackward(Grid grid)
        // {
        //     var oldCoordinate = grid.GetRoverCoordinate();
        //     oldCoordinate.HasRover = false;
        //
        //     var newX = oldCoordinate.X;
        //     var newY = oldCoordinate.Y;
        //     
        //     switch (Direction)
        //     {
        //         case Direction.North:
        //             newY--;
        //             break;
        //         case Direction.South:
        //             newY++;
        //             break;
        //         case Direction.East:
        //             newX--;
        //             break;
        //         case Direction.West:
        //             newX++;
        //             break;
        //         default:
        //             throw new ArgumentOutOfRangeException();
        //     }
        //
        //     grid.GetCoordinate(newX, newY).HasRover = true;
        // }
        
        public void MoveForward()
        {
            Coordinate = Grid.GetAdjacentCoordinateTo(Coordinate, Direction);
        }      
        
        public void MoveBackward()
        {
            var backwardDirection = GetBackwardDirection(Direction);
            Coordinate = Grid.GetAdjacentCoordinateTo(Coordinate, backwardDirection);
        }

        private Direction GetBackwardDirection(Direction direction)
        {
            return direction switch
            {
                Direction.North => Direction.South,
                Direction.South => Direction.North,
                Direction.East => Direction.West,
                Direction.West => Direction.East,
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
            };
        }
    }
}