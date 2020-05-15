using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToyBlockFactory
{
    public static class TableParser
    {
        public static string ToStringTable(this IEnumerable<IEnumerable<string>> rows, IEnumerable<string> headers)
        {
            var cells = GetCellsArray(rows, headers, out var columnWidths);

            return ToStringTable(cells, columnWidths);
        }

        private static string ToStringTable(string[,] cells, IReadOnlyList<int> columnWidths)
        {
            var tableBuilder = new StringBuilder();

            var width = cells.GetLength(1);
            var height = cells.GetLength(0);
            
            tableBuilder.AddHeaderRow(cells, columnWidths, width);
            tableBuilder.AddSeparatorRow(columnWidths, width);
            tableBuilder.AddDataRows(cells, columnWidths, height, width);
            
            return tableBuilder.ToString();
        }

        private static string[,] GetCellsArray(IEnumerable<IEnumerable<string>> rows, IEnumerable<string> headers, out int[] columnWidths)
        {
            var headersArray = headers.ToArray();
            var rowsArray = rows.Select(row => row.ToArray()).ToArray();

            var height = rowsArray.Length + 1;
            var width = headersArray.Length;

            var cells = new string[height, width];
            columnWidths = headersArray.Select(header => header.Length).ToArray();

            for (var column = 0; column < width; column++)
            {
                cells[0, column] = headersArray[column];
            }

            for (var row = 1; row < height; row++)
            {
                for (var column = 0; column < width; column++)
                {
                    var cell = rowsArray[row - 1][column];
                    cells[row, column] = cell;

                    if (cell.Length > columnWidths[column]) columnWidths[column] = cell.Length;
                }
            }

            return cells;
        }

        private static void AddHeaderRow(this StringBuilder tableBuilder,
            string[,] cells, IReadOnlyList<int> columnWidths, int width)
        {
            tableBuilder.Append("|");
            for (var column = 0; column < width; column++)
            {
                tableBuilder.AppendFormat($" {{0, {-columnWidths[column]}}} |", cells[0, column]);
            }
            tableBuilder.AppendLine();
        }

        private static void AddSeparatorRow(this StringBuilder tableBuilder,
            IReadOnlyList<int> columnWidths, int width)
        {
            tableBuilder.Append("|");
            for (var column = 0; column < width; column++)
            {
                tableBuilder.Append(string.Format($"-{{0, {-columnWidths[column]}}} |", "").Replace(' ', '-'));
            }
            tableBuilder.AppendLine();
        }

        private static void AddDataRows(this StringBuilder tableBuilder,
            string[,] cells, IReadOnlyList<int> columnWidths, int height, int width)
        {
            for (var row = 1; row < height; row++)
            {
                tableBuilder.Append("|");
                for (var column = 0; column < width; column++)
                {
                    tableBuilder.AppendFormat($" {{0, {-columnWidths[column]}}} |", cells[row, column]);
                }
                tableBuilder.AppendLine();
            }
        }
    }
}