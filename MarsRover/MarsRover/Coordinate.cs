namespace MarsRover
{
    public struct Coordinate : ICoordinate
    {
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        public int X { get; }
        public int Y { get; }
    }
}
