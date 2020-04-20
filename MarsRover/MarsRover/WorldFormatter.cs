using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MarsRover
{
    public class WorldFormatter
    {
        private readonly IRover _rover;
        private readonly IGrid _grid;
        private readonly StringBuilder _worldBuilder;

        public WorldFormatter(IRover rover, IGrid grid)
        {
            _rover = rover;
            _grid = grid;
            _worldBuilder = new StringBuilder("", GetWorldLength());
        }

        private int GetWorldLength()
        {
            return _grid.Height * (_grid.Width+1);
        }

        public IEnumerable<char> FormatRoverStatusSummary()
        {
            var x = _rover.Coordinate.X;
            var y = _rover.Coordinate.Y;
            var direction = _rover.Direction.ToString();
            
            return $"The rover is currently at ({x}, {y}) facing {direction}.";
        }

        public IEnumerable<char> FormatWorld()
        {
            _worldBuilder.Clear();
            
            AddGrid();
            PlaceRover();
            
            return _worldBuilder.ToString();
        }

        private void AddGrid()
        {
            for (var y = 0; y < _grid.Height; y++)
            {
                for (var x = 0; x < _grid.Width; x++)
                {
                    _worldBuilder.Append(".");
                }

                if (y < _grid.Height - 1)
                {
                    _worldBuilder.AppendLine();
                }
            }
        }
        
        private void PlaceRover()
        {
            var roverIndex = GetRoverIndex();
            _worldBuilder[roverIndex] = GetRoverRepresentation(roverIndex);
        }

        private int GetRoverIndex()
        {
            return (_grid.Height-1-_rover.Coordinate.Y) * (_grid.Width+1) + _rover.Coordinate.X;
        }

        private char GetRoverRepresentation(int roverIndex)
        {
            return _rover.Direction switch
            {
                Direction.North => 'N',
                Direction.South => 'S',
                Direction.East => 'E',
                Direction.West => 'W',
                _ => throw new InvalidEnumArgumentException()
            };
        }
    }
}