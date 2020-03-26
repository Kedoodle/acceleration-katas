using System.Linq;

namespace tictactoe
{
    public static class ConsoleInputParser
    {
        private const char CoordinateSeparator = ',';
        private const string PlayerQuitString = "q";

        public static bool HasQuit(string userInput)
        {
            return userInput == PlayerQuitString;
        }

        public static bool TryParseCoordinates(string userInput, out int x, out int y)
        {
            if (HasSingleSeparator(userInput, CoordinateSeparator))
            {
                var coordinateStrings = userInput.Split(CoordinateSeparator);
                if (int.TryParse(coordinateStrings[0], out x) && int.TryParse(coordinateStrings[1], out y))
                {
                    x--;
                    y--;
                    return true;
                }
            }
            x = -1;
            y = -1;
            return false;
        }

        private static bool HasSingleSeparator(string userInput, char separator)
        {
            return userInput.Count(c => c == separator) == 1;
        }
    }
}