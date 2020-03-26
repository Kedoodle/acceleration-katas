using System;
using System.Collections.Generic;

namespace tictactoe
{
    public static class BoardStringFormatter
    {
        public static IEnumerable<char> GetBoardAsString(Board board)
        {
            var boardAsString = "";
            
            for (var y = 0; y < board.GridSize; y++)
            {
                for (var x = 0; x < board.GridSize; x++)
                {
                    var cell = board.GetCell(x, y);
                    boardAsString += Cell.GetCellStateAsString(cell.State);
                }

                if (y < board.GridSize - 1)
                {
                    boardAsString += Environment.NewLine;
                }
            }
            
            return boardAsString;
        }
    }
}