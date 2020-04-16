using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    public class Grid : IGrid
    {
        private readonly int _height;
        private readonly int _width;
        private readonly List<Coordinate> _coordinates = new List<Coordinate>();

        public Grid(int width, int height)
        {
            _width = width;
            _height = height;
            InitialiseCoordinates();
        }

        private void InitialiseCoordinates()
        {
            for (var x = 0; x < _width; x++)
            {
                for (var y = 0; y < _height; y++)
                {
                    _coordinates.Add(new Coordinate(x, y));
                }
            }
        }

        public bool IsEmpty()
        {
            return _coordinates.All(coordinate => coordinate.IsEmpty());
        }

        public ICoordinate GetAdjacentCoordinateTo(ICoordinate coordinate, Direction direction)
        {
            var x = coordinate.X;
            var y = coordinate.Y;

            switch (direction)
            {
                case Direction.North:
                    y = coordinate.Y == _height-1 ? 0 : y+1;
                    break;
                case Direction.South:
                    y = coordinate.Y == 0 ? _height-1 : y-1;
                    break;
                case Direction.East:
                    x = coordinate.X == _width-1 ? 0 : x+1;
                    break;
                case Direction.West:
                    x = coordinate.X == 0 ? _width-1 : x-1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }

            return GetCoordinate(x, y);
        }

        public ICoordinate GetCoordinate(int x, int y)
        {
            return _coordinates.FirstOrDefault(coordinate => coordinate.X == x && coordinate.Y == y);
        }
    }
}
