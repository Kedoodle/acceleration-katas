using System;
using System.IO;
using Moq;
using Xunit;

namespace Minesweeper.Tests
{
    public class ConsoleWriterShould
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
            var consoleWriter = new ConsoleWriter(mockOutputStream);

            consoleWriter.WriteField(field);
            
            Mock.Get(mockOutputStream).Verify(o => o.WriteLine(expectedOutput), Times.Once);
        }
    }

    public class ConsoleWriter
    {
        private readonly TextWriter _outputStream;

        public ConsoleWriter(TextWriter outputStream)
        {
            _outputStream = outputStream;
        }

        public void WriteField(Field field)
        {
            var output = ConsoleFieldFormatter.GetDisplayString(field);
            _outputStream.WriteLine(output);
        }
    }
}