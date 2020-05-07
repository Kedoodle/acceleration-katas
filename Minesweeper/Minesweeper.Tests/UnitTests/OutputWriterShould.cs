using System;
using System.IO;
using Moq;
using Xunit;

namespace Minesweeper.Tests.UnitTests
{
    public class OutputWriterShould
    {
        [Fact]
        public void WriteFormattedFieldToConsole()
        {
            var expectedOutput = "*100" + Environment.NewLine +
                                        "2210" + Environment.NewLine +
                                        "1*10" + Environment.NewLine +
                                        "1110";
            
            const int width = 4;
            const int height = 4;
            var field = new Field(width, height);
            
            field.SetMine(0, 0);
            field.SetMine(1, 2);

            var mockOutputStream = Mock.Of<TextWriter>();
            var outputWriter = new OutputWriter(mockOutputStream);

            outputWriter.WriteField(field);
            
            Mock.Get(mockOutputStream).Verify(o => o.WriteLine(expectedOutput), Times.Once);
        }
    }
}