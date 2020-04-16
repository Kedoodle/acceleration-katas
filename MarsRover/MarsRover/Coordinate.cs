namespace MarsRover
{
    public class Coordinate : ICoordinate
    {
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        public int X { get; }
        public int Y { get; }

        public bool IsEmpty()
        {
            return true;
        }
    }   
}
