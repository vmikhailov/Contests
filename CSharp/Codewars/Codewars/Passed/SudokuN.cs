using System;
using System.Linq;

namespace Codewars.Codewars.Passed
{
    public class SudokuN
    {
        private readonly int[][] _board;
        private readonly int _size;
        private readonly int _len;
        private readonly int _sum;
        private readonly bool _valid;

        public SudokuN(int[][] board)
        {
            _board = board;
            _len = board.Length;
            _valid = _board.SelectMany(x => x).Count() == _len * _len;
            _sum = _len * (_len + 1) / 2;
            _size = (int)Math.Sqrt(_len);
        }
    
        public bool IsValid() =>
            _valid &&
            Check((i, j) => _board[i][j]) &&
            Check((i, j) => _board[j][i]) &&
            Check((i, j) => _board[i % _size * _size + j % _size][i / _size * _size + j / _size]);

        private bool Check(Func<int, int, int> getter) => 
            Enumerable.Range(0,_len).Any(i => Enumerable.Range(0, _len).Sum(j => getter(i, j)) != _sum);
    }
}