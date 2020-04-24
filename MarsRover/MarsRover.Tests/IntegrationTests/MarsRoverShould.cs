using System;
using Xunit;

namespace MarsRover.Tests.IntegrationTests
{
    public class MarsRoverShould
    {
        [Fact]
        public void MoveAroundWrappingGridWithObstacles()
        {
            var expectedStartWorld = "....N" + Environment.NewLine +
                                            "....." + Environment.NewLine +
                                            "..TBB" + Environment.NewLine +
                                            "..T.." + Environment.NewLine +
                                            "..TBB";
            var expectedEndWorld = "....." + Environment.NewLine +
                                          "....." + Environment.NewLine +
                                          "..TBB" + Environment.NewLine +
                                          "..TE." + Environment.NewLine +
                                          "..TBB";

            const int width = 5;
            const int height = 5;
            var grid = new Grid(width, height);
            grid.AddObstacle(2, 0, ObstacleType.Tree);
            grid.AddObstacle(2, 1, ObstacleType.Tree);
            grid.AddObstacle(2, 2, ObstacleType.Tree);
            grid.AddObstacle(3, 0, ObstacleType.Boulder);
            grid.AddObstacle(4, 0, ObstacleType.Boulder);
            grid.AddObstacle(3, 2, ObstacleType.Boulder);
            grid.AddObstacle(4, 2, ObstacleType.Boulder);
            
            var rover = new Rover();
            var roverStartingLocation = grid.GetLocation(4, 4);
            rover.DropOnGrid(grid, roverStartingLocation, Direction.North);
            
            var worldFormatter = new WorldFormatter(rover, grid);
            
            var actualStartWorld = worldFormatter.FormatWorld();
            Assert.Equal(expectedStartWorld, actualStartWorld);

            var commands = new[] {
                RoverCommand.TurnRight, 
                RoverCommand.MoveForward,
                RoverCommand.TurnRight,
                RoverCommand.MoveForward,
                RoverCommand.MoveForward,
                RoverCommand.MoveForward,
                RoverCommand.TurnLeft,
                RoverCommand.MoveBackward,
                RoverCommand.MoveBackward
            };
            rover.ProcessCommands(commands);
            
            var actualEndWorld = worldFormatter.FormatWorld();
            Assert.Equal(expectedEndWorld, actualEndWorld);
        }
    }
}