using System.Collections.Generic;

namespace Codewars.Codewars.Passed
{
    public class ConnectFour
    {
        private const int rows = 6;
        private const int cols = 7;
        private const int win = 4;

        public static string WhoIsWinner(List<string> piecesPositionList)
        {
            var grid = new int[cols, rows];

            foreach (var s in piecesPositionList)
            {
                var split = s.Split("_");
                var c = split[0][0] - 'A';
                var p = split[1] == "Red" ? 1 : 2;

                var r = MakeStep(grid, c, p);
                if (r == -1)
                {
                    break;
                }

                if (CheckWin(grid, c, r, out var winner))
                {
                    return winner;
                }
            }

            return "Draw";
        }

        private static bool CheckWin(int[,] grid, in int x, in int y, out string winner)
        {
            var c = grid[x, y];
            var r = y;
            var h = CountSameColor(grid, c, x, y, 1, 0) + CountSameColor(grid, c, x, y, -1, 0) - 1;
            var v = CountSameColor(grid, c, x, y, 0, 1) + CountSameColor(grid, c, x, y, 0, -1) - 1;
            var d1 = CountSameColor(grid, c, x, y, 1, 1) + CountSameColor(grid, c, x, y, -1, -1) - 1;
            var d2 = CountSameColor(grid, c, x, y, 1, -1) + CountSameColor(grid, c, x, y, -1, 1) - 1;

            if (h >= 4 || v >= 4 || d1 >= 4 || d2 >= 4)
            {
                winner = c == 1 ? "Red" : "Yellow";

                return true;
            }

            winner = "";

            return false;
        }

        private static int CountSameColor(int[,] grid, in int c, int x, int y, in int dx, int dy)
        {
            var s = 0;
            while (0 <= x && x < cols && 0 <= y && y < rows && grid[x, y] == c)
            {
                x += dx;
                y += dy;
                s++;
            }

            return s;
        }

        private static int MakeStep(int[,] grid, in int col, in int player)
        {
            var i = 0;
            while (i < rows && grid[col, i] == 0) i++;

            if (i > 0)
            {
                grid[col, i - 1] = player;
            }

            return i - 1;
        }
    }
}