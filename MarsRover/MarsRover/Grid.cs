using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace MarsRover
{
    public class Grid : IGrid
    {
        public Grid(int width, int height)
        {
            Width = width;
            Height = height;
            InitialiseLocations();
        }

        public int Width { get; }
        public int Height { get; }
        public List<ILocation> Locations { get; } = new List<ILocation>();

        private void InitialiseLocations()
        {
            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    Locations.Add(new Location(x, y));
                }
            }
        }

        public bool IsEmpty()
        {
            return Locations.All(c => c.IsEmpty());
        }

        public ILocation GetAdjacentLocationTo(ILocation location, Direction direction)
        {
            var x = location.X;
            var y = location.Y;

            switch (direction)
            {
                case Direction.North:
                    y = location.Y == Height-1 ? 0 : y+1;
                    break;
                case Direction.South:
                    y = location.Y == 0 ? Height-1 : y-1;
                    break;
                case Direction.East:
                    x = location.X == Width-1 ? 0 : x+1;
                    break;
                case Direction.West:
                    x = location.X == 0 ? Width-1 : x-1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }

            return GetLocation(x, y);
        }

        public ILocation GetLocation(int x, int y)
        {
            return Locations.FirstOrDefault(location => location.X == x && location.Y == y);
        }

        public static void AddObstacle(ObstacleType obstacleType, ILocation location)
        {
            location.Obstacle = obstacleType;
        }
    }
}
