namespace MarsRover
{
    public struct Coordinate : ICoordinate
    {
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
            Obstacle = ObstacleType.None;
        }
        
        public int X { get; }
        public int Y { get; }
        public ObstacleType Obstacle { get; set; }
        
        public bool IsEmpty()
        {
            return Obstacle is ObstacleType.None;
        }
    }
}
