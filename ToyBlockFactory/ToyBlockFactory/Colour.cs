using System.ComponentModel;

namespace ToyBlockFactory
{
    public enum Colour
    {
        Red,
        Blue,
        Yellow
    }
    
    public static class ColourExtensions
    {
        public static decimal GetPrice(Colour colour)
        {
            return colour switch
            {
                Colour.Red => 1m,
                Colour.Blue => 0m,
                Colour.Yellow => 0m,
                _ => throw new InvalidEnumArgumentException()
            };
        }
    }
}
