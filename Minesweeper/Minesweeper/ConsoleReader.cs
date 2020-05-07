using System.Collections.Generic;
using System.IO;

namespace Minesweeper
{
    public class ConsoleInputGetter
    {
        private readonly TextReader _inputStream;

        public ConsoleInputGetter(TextReader inputStream)
        {
            _inputStream = inputStream;
        }

        public IEnumerable<char> ReadLine()
        {
            return _inputStream.ReadLine();
        }
    }
}