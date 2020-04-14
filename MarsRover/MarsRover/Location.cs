namespace MarsRover
{
    public class Location
    {
        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        public int X { get; }
        public int Y { get; }
        public bool HasRover { get; set; } = false;

        public bool IsEmpty()
        {
            return !HasRover;
        }
    }   
}
