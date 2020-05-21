namespace ToyBlockFactory
{
    public class Block
    {
        public Block(Shape shape, Colour colour)
        {
            Shape = shape;
            Colour = colour;
        }
        
        public Shape Shape { get; }
        public Colour Colour { get; }
    }
}