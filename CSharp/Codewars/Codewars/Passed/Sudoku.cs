using System;

namespace Codewars.Codewars.Passed
{
    public class Sudoku
    {
        public static string DoneOrNot(int[][] board)
        {
            return Check(board, (i, j, b) => b[i][j]) &&
                   Check(board, (i, j, b) => b[j][i]) &&
                   Check(board, (i, j, b) => b[i % 3 * 3 + j % 3][i / 3 * 3 + j / 3])
                ? "Finished!"
                : "Try again!";
        }

        private static bool Check(int[][] board, Func<int, int, int[][], int> getter)
        {
            for (var i = 0; i < 9; i++)
            {
                var s = 0;
                for (var j = 0; j < 9; j++)
                {
                    s += getter(i, j, board);
                }

                if (s != 45)
                {
                    return false;
                }
            }

            return true;
        }
    }
}