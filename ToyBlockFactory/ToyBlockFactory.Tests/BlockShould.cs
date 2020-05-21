using Xunit;

namespace ToyBlockFactory.Tests
{
    public class BlockShould
    {
        [Theory]
        [InlineData(Shape.Square, Colour.Red)]
        [InlineData(Shape.Square, Colour.Blue)]
        [InlineData(Shape.Square, Colour.Yellow)]
        [InlineData(Shape.Triangle, Colour.Red)]
        [InlineData(Shape.Triangle, Colour.Blue)]
        [InlineData(Shape.Triangle, Colour.Yellow)]
        [InlineData(Shape.Circle, Colour.Red)]
        [InlineData(Shape.Circle, Colour.Blue)]
        [InlineData(Shape.Circle, Colour.Yellow)]
        public void HaveShapeAndColour(Shape expectedShape, Colour expectedColour)
        {
            var block = new Block(expectedShape, expectedColour);
            
            Assert.Equal(expectedShape, block.Shape);
            Assert.Equal(expectedColour, block.Colour);
        }
    }
}
