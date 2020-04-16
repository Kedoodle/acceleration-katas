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

        public ICoordinate GetCoordinate(int x, int y)
        {
            return _coordinates.FirstOrDefault(coordinate => coordinate.X == x && coordinate.Y == y);
        }

        public bool IsEmpty()
        {
            return _coordinates.All(coordinate => coordinate.IsEmpty());
        }

        public ICoordinate GetAdjacentCoordinateTo(ICoordinate stubStartingCoordinate, Direction direction)
        {
            throw new System.NotImplementedException();
        }
    }
}
