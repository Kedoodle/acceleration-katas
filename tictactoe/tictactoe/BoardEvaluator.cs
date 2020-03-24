using System;
using System.Linq;

namespace tictactoe
{
    public static class BoardEvaluator
    {
        public static bool IsTie(Board board)
        {
            return board.IsFull() && !HasWinCondition(board);
        }

        public static bool HasWinCondition(Board board)
        {
            return HasWinningRow(board) || HasWinningColumn(board) || HasWinningDiagonal(board);
        }

        public static bool HasWinningRow(Board board)
        {
            for (var y = 0; y < board.GridSize; y++)
            {
                if (board.GetCell(0, y).IsEmpty()) continue;
                if (Enumerable.Range(1, board.GridSize - 1).All(x => Equals(board.GetCell(x, y), board.GetCell(0, y))))
                    return true;
            }
            return false;
        }

        public static bool HasWinningColumn(Board board)
        {
            for (var x = 0; x < board.GridSize; x++)
            {
                if (board.GetCell(x, 0).IsEmpty()) continue;
                if (Enumerable.Range(1, board.GridSize - 1).All(y => Equals(board.GetCell(x, y), board.GetCell(x, 0))))
                    return true;
            }
            return false;
        }
        
        public static bool HasWinningDiagonal(Board board)
        {
            if (!board.GetCell(0, 0).IsEmpty() && Enumerable.Range(1, board.GridSize - 1)
                .All(xy => Equals(board.GetCell(xy, xy), board.GetCell(0, 0))))
            {
                return true;
            }

            if (!board.GetCell(board.GridSize - 1, 0).IsEmpty() && Enumerable.Range(1, board.GridSize - 1)
                .All(xy => Equals(board.GetCell(board.GridSize - 1 - xy, xy), board.GetCell(board.GridSize - 1, 0))))
            {
                return true;
            }
            
            return false;
        }
    }
}
