using System.IO;

namespace Minesweeper
{
    public class OutputWriter
    {
        private readonly TextWriter _outputStream;

        public OutputWriter(TextWriter outputStream)
        {
            _outputStream = outputStream;
        }

        public void WriteFieldNumber(int fieldNumber)
        {
            _outputStream.WriteLine($"Field #{fieldNumber}:");
        }

        public void WriteField(Field field)
        {
            var output = ConsoleFieldFormatter.GetDisplayString(field);
            _outputStream.WriteLine(output);
        }
    }
}