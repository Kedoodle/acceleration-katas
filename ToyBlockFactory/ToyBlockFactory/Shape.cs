using System.ComponentModel;

namespace ToyBlockFactory
{
    public enum Shape
    {
        Square,
        Triangle,
        Circle
    }
    
    public static class ShapeExtensions
    {
        public static decimal GetPrice(Shape shape)
        {
            return shape switch
            {
                Shape.Square => 1m,
                Shape.Triangle => 2m,
                Shape.Circle => 3m,
                _ => throw new InvalidEnumArgumentException()
            };
        }
    }
}
