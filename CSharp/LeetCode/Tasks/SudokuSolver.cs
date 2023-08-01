using System.Diagnostics;

namespace LeetCode.Tasks;

public class SudokuSolver
{
    private const int All = 0x1FF;

    enum PuzzleState
    {
        InProgress,
        Solved,
        NoSolution
    }

    class Cell
    {
        public int Candidates = All;
        public int? Num;
        private Stack<(int? N, int C)>? _stack;

        public void Push()
        {
            _stack ??= new();
            _stack.Push((Num, Candidates));
        }

        public void Pop()
        {
            (Num, Candidates) = _stack!.Pop();
        }
    }


    public void SolveSudoku(char[][] board)
    {
        var b2 = Enumerable.Range(1, 9).Select(x => Enumerable.Range(1, 9).Select(x => '.').ToArray()).ToArray();
        var sw = Stopwatch.StartNew();
        for (var i = 0; i < 1000; i++)
        {
            var cells = ToCells(board);
            Solve(cells);
            ToBoard(cells, b2);
        }

        Console.WriteLine(sw.ElapsedMilliseconds);
        
    }

    private PuzzleState Solve(Cell[,] cells)
    {
        var state = Reduce(cells);
        if (state != PuzzleState.InProgress) return state;

        var toCheck = ForEach(cells, x => ToListOfInt(x.Candidates))
                      .Where(x => x.Value.Count > 1)
                      .OrderByDescending(x => x.Value.Count)
                      .ToList();

        foreach (var (cell, candidates) in toCheck)
        {
            ForEach(cells, x => x.Push());

            foreach (var val in candidates)
            {
                cell.Candidates = 1 << (val - 1);
                cell.Num = val;
                state = Solve(cells);
                if (state == PuzzleState.Solved) return state;
            }

            ForEach(cells, x => x.Pop());
        }

        return PuzzleState.NoSolution;
    }

    private PuzzleState Reduce(Cell[,] cells)
    {
        var marked = true;
        var solved = false;

        while (marked && !solved)
        {
            marked = false;
            solved = true;
            foreach (var w in Ways)
            {
                for (var i = 0; i < 9; i++)
                {
                    var numbers = 0;
                    foreach (var c in Cells(cells, i, w).Where(x => x.Num.HasValue))
                    {
                        var v = c.Num!.Value;
                        numbers |= 1 << (v - 1);
                    }

                    var missingNumbers = ~numbers & All;
                    var options = new int[9];
                    foreach (var c in Cells(cells, i, w).Where(x => !x.Num.HasValue))
                    {
                        c.Candidates &= missingNumbers;
                        var v = c.Candidates;
                        var m = 0;
                        for (var j = 0; j < 9; j++)
                        {
                            var f = (v & (1 << j)) > 0 ? 1 : 0;
                            m += f;
                            options[j] += f;
                        }

                        if (m == 1)
                        {
                            c.Num = ToListOfInt(c.Candidates).First();
                            marked = true;
                        }
                    }

                    //search for unique options
                    for (var j = 0; j < 9; j++)
                    {
                        if (options[j] != 1)
                        {
                            continue;
                        }

                        // set the unique value
                        foreach (var c in Cells(cells, i, w).Where(x => !x.Num.HasValue))
                        {
                            if ((c.Candidates & (1 << j)) > 0)
                            {
                                c.Num = j + 1;
                                marked = true;
                            }
                        }
                    }

                    // compute state
                    var opt = 0;
                    var cnt = 0;
                    foreach (var c in Cells(cells, i, w).Where(x => !x.Num.HasValue))
                    {
                        solved = false;
                        cnt++;
                        opt |= c.Candidates;
                    }

                    if (ToListOfInt(opt).Count < cnt)
                    {
                        return PuzzleState.NoSolution;
                    }
                    
                    var dups = new bool[9];
                    foreach (var c in Cells(cells, i, w).Where(x => x.Num.HasValue))
                    {
                        var v = c.Num!.Value;
                        if (dups[v - 1]) return PuzzleState.NoSolution;
                        dups[v - 1] = true;
                    }
                }
            }
        }

        return solved ? PuzzleState.Solved : PuzzleState.InProgress;
    }

    private static Func<int, int, (int X, int Y)>[] Ways = new Func<int, int, (int X, int Y)>[]
    {
        (x, y) => (x, y),
        (x, y) => (y, x),
        (x, y) => (x % 3 * 3 + y % 3, x / 3 * 3 + y / 3)
    };

    private static Cell[,] ToCells(char[][] board)
    {
        var cells = new Cell[9, 9];
        for (var i = 0; i < 9; i++)
        {
            for (var j = 0; j < 9; j++)
            {
                var v = board[i][j];
                if (v == '.')
                {
                    cells[i, j] = new();
                }
                else
                {
                    var n = v - '0';
                    cells[i, j] = new() { Num = n, Candidates = 1 << (n - 1) };
                }
            }
        }

        return cells;
    }

    private static void ToBoard(Cell[,] cells, char[][] board)
    {
        for (var i = 0; i < 9; i++)
        {
            for (var j = 0; j < 9; j++)
            {
                board[i][j] = (char)(cells[i, j].Num!.Value + '0');
            }
        }
    }

    private static IEnumerable<(int X, int Y)> Line(int n, Func<int, int, (int X, int Y)> map)
    {
        for (var i = 0; i < 9; i++)
        {
            yield return map(n, i);
        }
    }

    private static IEnumerable<Cell> Cells(Cell[,] cells, int n, Func<int, int, (int X, int Y)> map)
    {
        foreach (var p in Line(n, map))
        {
            yield return cells[p.X, p.Y];
        }
    }

    private static IEnumerable<(Cell Cell, T Value)> ForEach<T>(Cell[,] cells, Func<Cell, T> func)
    {
        for (var i = 0; i < 9; i++)
        {
            for (var j = 0; j < 9; j++)
            {
                var c = cells[i, j];
                yield return (c, func(c));
            }
        }
    }

    private static void ForEach(Cell[,] cells, Action<Cell> action)
    {
        for (var i = 0; i < 9; i++)
        {
            for (var j = 0; j < 9; j++)
            {
                action(cells[i, j]);
            }
        }
    }

    private IList<int> ToListOfInt(int n)
    {
        var r = new List<int>();
        for (var i = 0; i < 9; i++)
        {
            if ((n & (1 << i)) > 0) r.Add(i + 1);
        }

        return r;
    }

    private void Print(Cell[,] cells)
    {
        Console.WriteLine("---------------------------------------");
        for (var i = 0; i < 9; i++)
        {
            for (var j = 0; j < 9; j++)
            {
                var c = cells[i, j];
                if (c.Num.HasValue)
                {
                    Console.Write($"{c.Num,20}");
                }
                else
                {
                    var s = "?" + string.Join(',', ToListOfInt(c.Candidates));
                    Console.Write($"{s,20}");
                }
            }

            Console.WriteLine();
        }
    }

    public char[][] Test1 = new[]
    {
        new[] { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
        new[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
        new[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
        new[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
        new[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
        new[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
        new[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
        new[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
        new[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
    };

    public char[][] Test2 = new[]
    {
        new[] { '.', '6', '.', '.', '.', '.', '.', '5', '.' },
        new[] { '5', '.', '.', '.', '9', '4', '.', '.', '8' },
        new[] { '4', '.', '3', '.', '.', '.', '1', '.', '.' },

        new[] { '.', '9', '.', '.', '.', '.', '.', '.', '.' },
        new[] { '.', '.', '1', '.', '.', '7', '9', '.', '.' },
        new[] { '.', '.', '.', '.', '1', '8', '.', '6', '.' },

        new[] { '3', '.', '.', '.', '4', '.', '.', '.', '.' },
        new[] { '.', '.', '7', '8', '6', '.', '4', '.', '.' },
        new[] { '.', '4', '.', '3', '.', '1', '.', '7', '.' },
    };

    public char[][] Test3 = new[]
    {
        new[] { '.', '.', '9', '7', '4', '8', '.', '.', '.' },
        new[] { '7', '.', '.', '.', '.', '.', '.', '.', '.' },
        new[] { '.', '2', '.', '1', '.', '9', '.', '.', '.' },
        new[] { '.', '.', '7', '.', '.', '.', '2', '4', '.' },
        new[] { '.', '6', '4', '.', '1', '.', '5', '9', '.' },
        new[] { '.', '9', '8', '.', '.', '.', '3', '.', '.' },
        new[] { '.', '.', '.', '8', '.', '3', '.', '2', '.' },
        new[] { '.', '.', '.', '.', '.', '.', '.', '.', '6' },
        new[] { '.', '.', '.', '2', '7', '5', '9', '.', '.' }
    };
}