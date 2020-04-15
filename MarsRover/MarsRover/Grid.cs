using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    public class Grid
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
        
        public Rover Rover { get; private set; }

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

        public Coordinate GetRoverCoordinate()
        {
            return _coordinates.FirstOrDefault(coordinate => coordinate.HasRover);
        }

        public void PlaceRover(int x, int y, Direction direction)
        {
            Rover = new Rover(direction);
            ClearRoverCoordinates();
            GetCoordinate(x, y).HasRover = true;
        }

        private void ClearRoverCoordinates()
        {
            _coordinates.ForEach(coordinate => coordinate.HasRover = false);
        }

        public Coordinate GetCoordinate(int x, int y)
        {
            return _coordinates.FirstOrDefault(coordinate => coordinate.X == x && coordinate.Y == y);
        }

        public bool IsEmpty()
        {
            return _coordinates.All(coordinate => coordinate.IsEmpty());
        }
    }
}
