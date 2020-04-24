using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
            var x = _rover.Location.X;
            var y = _rover.Location.Y;
            var direction = _rover.Direction.ToString();
            
            return $"The rover is currently at ({x}, {y}) facing {direction}.";
        }

        public IEnumerable<char> FormatWorld()
        {
            _worldBuilder.Clear();
            
            BuildGrid();
            BuildRover();
            
            return _worldBuilder.ToString();
        }

        private void BuildGrid()
        {
            for (var y = _grid.Height-1; y >= 0; y--)
            {
                for (var x = 0; x < _grid.Width; x++)
                {
                    var location = _grid.GetLocation(x, y);
                    var locationRepresentation = GetLocationRepresentation(location);
                    _worldBuilder.Append(locationRepresentation);
                }

                if (y > 0)
                {
                    _worldBuilder.AppendLine();
                }
            }
        }

        private static char GetLocationRepresentation(ILocation location)
        {
            return location.Obstacle switch
            {
                ObstacleType.None => '.',
                ObstacleType.Tree => 'T',
                ObstacleType.Boulder => 'B',
                _ => throw new InvalidEnumArgumentException()
            };
        }
        
        private void BuildRover()
        {
            var roverBuilderIndex = GetBuilderIndex(_rover.Location);
            _worldBuilder[roverBuilderIndex] = GetRoverRepresentation();
        }

        private int GetBuilderIndex(ILocation location)
        {
            return (_grid.Height-1-location.Y) * (_grid.Width+1) + location.X;
        }

        private char GetRoverRepresentation()
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