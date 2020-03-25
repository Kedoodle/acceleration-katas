using System.Linq;

namespace tictactoe
{
    public static class ConsoleInputParser
    {
        public static bool TryParseCoordinates(string userInput, out int x, out int y)
        {
            if (HasSingleComma(userInput))
            {
                var commaIndex = userInput.IndexOf(',');
            }
            x = -1;
            y = -1;
            return false;
        }

        private static bool HasSingleComma(string userInput)
        {
            return userInput.Count(c => c == ',') == 1;
        }
    }
}