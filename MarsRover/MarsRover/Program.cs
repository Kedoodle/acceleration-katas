using System;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            const int width = 5;
            const int height = 5;
            var grid = new Grid(width, height);
            var rover = new Rover();
            var worldFormatter = new WorldFormatter(rover, grid);
            
            var coordinateToDropRover = grid.GetCoordinate(1, 2);
            rover.DropOnGrid(grid, coordinateToDropRover, Direction.South);
            
            Console.WriteLine(worldFormatter.FormatRoverStatusSummary());
            Console.WriteLine(worldFormatter.FormatWorld());
        }
    }
}
