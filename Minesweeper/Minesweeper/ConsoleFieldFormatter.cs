using System.Text;

namespace Minesweeper
{
    public static class ConsoleFieldFormatter
    {
        public static string GetDisplayString(Field field)
        {
            var minesCalculator = new MinesCalculator(field);
            var stringBuilder = new StringBuilder();
            for (var y = 0; y < field.Height; y++)
            {
                for (var x = 0; x < field.Width; x++)
                {
                    var cell = field.GetCell(x, y);
                    stringBuilder.Append(cell.IsMine ? "*" : minesCalculator.CountNeighbouringMines(x, y).ToString());
                }
                if (y < field.Height-1) stringBuilder.AppendLine();
            }
            return stringBuilder.ToString();
        }
    }
}