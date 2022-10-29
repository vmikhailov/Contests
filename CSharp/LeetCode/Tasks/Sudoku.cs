using System;

namespace LeetCode
{
    public class Sudoku
    {
	    public bool IsValidSudoku(char[][] board) 
	    {
		    return Check(board, (i, j, b) => b[i][j]) &&
		           Check(board, (i, j, b) => b[j][i]) &&
		           Check(board, (i, j, b) => b[i % 3 * 3 + j % 3][i / 3 * 3 + j / 3]);
	    }
    
	    private static bool Check(char[][] board, Func<int, int, char[][], int> getter)
	    {
		    for (var i = 0; i < 9; i++)
		    {
			    var s = 0;
			    var d = new HashSet<int>();
			    for (var j = 0; j < 9; j++)
			    {
				    var c = getter(i, j, board);
				    if(c == '.') continue;
				    var v = c - '0';
				    s += v;
				    if(!d.Add(v)) return false;
			    }

			    if (s > 45)
			    {
				    return false;
			    }
		    }

		    return true;
	    }
    }
}