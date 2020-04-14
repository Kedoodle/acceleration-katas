using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    public class Grid
    {
        private readonly int _height;
        private readonly int _width;
        private readonly List<Location> _locations = new List<Location>();

        public Grid(int width, int height)
        {
            _width = width;
            _height = height;
            InitialiseLocations();
        }

        private void InitialiseLocations()
        {
            for (var x = 0; x < _width; x++)
            {
                for (var y = 0; y < _height; y++)
                {
                    _locations.Add(new Location(x, y));
                }
            }
        }

        public bool IsEmpty()
        {
            return _locations.All(location => location.IsEmpty());
        }
    }
}
