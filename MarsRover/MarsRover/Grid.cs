using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    public class Grid : IGrid
    {
        public Grid(int width, int height)
        {
            Width = width;
            Height = height;
            InitialiseCoordinates();
        }

        public int Width { get; }
        public int Height { get; }
        public List<Coordinate> Coordinates { get; } = new List<Coordinate>();

        private void InitialiseCoordinates()
        {
            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    Coordinates.Add(new Coordinate(x, y));
                }
            }
        }

        public bool IsEmpty()
        {
            return Coordinates.All(coordinate => coordinate.IsEmpty());
        }

        public ICoordinate GetAdjacentCoordinateTo(ICoordinate coordinate, Direction direction)
        {
            var x = coordinate.X;
            var y = coordinate.Y;

            switch (direction)
            {
                case Direction.North:
                    y = coordinate.Y == Height-1 ? 0 : y+1;
                    break;
                case Direction.South:
                    y = coordinate.Y == 0 ? Height-1 : y-1;
                    break;
                case Direction.East:
                    x = coordinate.X == Width-1 ? 0 : x+1;
                    break;
                case Direction.West:
                    x = coordinate.X == 0 ? Width-1 : x-1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }

            return GetCoordinate(x, y);
        }

        public ICoordinate GetCoordinate(int x, int y)
        {
            return Coordinates.FirstOrDefault(coordinate => coordinate.X == x && coordinate.Y == y);
        }
    }
}
