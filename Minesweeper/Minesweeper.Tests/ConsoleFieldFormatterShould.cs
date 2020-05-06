using System;
using Xunit;

namespace Minesweeper.Tests
{
    public class ConsoleFieldFormatterShould
    {
        [Fact]
        public void TakeFieldAndFormatWithNeighbouringMineCounts()
        {
            var expectedDisplayString = "*100" + Environment.NewLine +
                                        "2210" + Environment.NewLine +
                                        "1*10" + Environment.NewLine +
                                        "1110";
            
            const int width = 4;
            const int height = 4;
            var field = new Field(width, height);
            
            field.SetMine(0, 0);
            field.SetMine(1, 2);
            
            var actualDisplayString = ConsoleFieldFormatter.GetDisplayString(field);
            
            Assert.Equal(expectedDisplayString, actualDisplayString);
        }
    }
}