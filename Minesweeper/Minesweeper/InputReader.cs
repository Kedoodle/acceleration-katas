using System.Collections.Generic;
using System.IO;

namespace Minesweeper
{
    public class InputReader
    {
        private readonly TextReader _inputStream;

        public InputReader(TextReader inputStream)
        {
            _inputStream = inputStream;
        }

        public IEnumerable<char> ReadLine()
        {
            return _inputStream.ReadLine();
        }
    }
}