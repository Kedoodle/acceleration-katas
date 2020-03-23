using System;
using System.Linq;

namespace tictactoe
{
    public static class GameRules
    {
        public static bool IsTie(Board board)
        {
            return board.IsFull() && !GameRules.HasWinCondition(board);
        }

        private static bool HasWinCondition(Board board)
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
            throw new NotImplementedException();
        }
        
        public static bool HasWinningDiagonal(Board board)
        {
            throw new NotImplementedException();
        }

    }
}