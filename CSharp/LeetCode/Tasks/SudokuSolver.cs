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

    record Cell
    {
        public int Candidates = All;
        public int? Num;

        public override string ToString()
        {
            return Num.HasValue ? Num.Value.ToString() : "?" + string.Join(",", ToListOfInt(Candidates));
        }
    }

    public void SolveSudoku(char[][] board)
    {
        var b2 = Enumerable.Range(1, 9).Select(x => Enumerable.Range(1, 9).Select(x => '.').ToArray()).ToArray();

        // var matrix = new List<IList<IList<(int X, int Y)>>>();
        // foreach (var w in Ways)
        // {
        //     var slice = new List<IList<(int X, int Y)>>();
        //     for (var i = 0; i < 9; i++)
        //     {
        //         slice.Add(Line(i, w).ToList());
        //     }
        //
        //     matrix.Add(slice);
        // }
        
        // var matrix1 = Ways.Select(
        //                       w => Enumerable.Range(1, 9)
        //                                      .Select(x => Line(x, w).ToList())
        //                                      .OfType<IList<(int X, int Y)>>()
        //                                      .ToList())
        //                   .OfType<IList<IList<(int X, int Y)>>>()
        //                   .ToList();

        var stack = new Stack<IList<(int X, int Y, int C)>>();
        var sw = Stopwatch.StartNew();

        for (var i = 0; i < 1000; i++)
        {
            var cells = ToCells(board);
            Solve(cells, stack);
            ToBoard(cells, b2);
        }

        Console.WriteLine(sw.ElapsedMilliseconds);
    }

    private PuzzleState Solve(Cell[,] cells, Stack<IList<(int X, int Y, int C)>> stack)
    {
        var state = Reduce(cells);
        if (state != PuzzleState.InProgress)
        {
            return state;
        }

        var toCheck = ForEach(cells, x => ToListOfInt(x.Candidates))
                      .Where(x => x.Value.Count > 1)
                      .OrderBy(x => x.Value.Count)
                      .ToList();

        foreach (var (cell, candidates) in toCheck)
        {
            foreach (var val in candidates)
            {
                Push(cells, stack);
                cell.Candidates = 1 << (val - 1);
                cell.Num = val;
                state = Solve(cells, stack);
                if (state == PuzzleState.Solved)
                {
                    return state;
                }

                Pop(cells, stack);
            }
        }

        return PuzzleState.NoSolution;
    }

    private void Push(Cell[,] cells, Stack<IList<(int X, int Y, int C)>> stack)
    {
        var list = new List<(int X, int Y, int C)>();

        ForEach(
            cells,
            (x, y, c) =>
            {
                if (!c.Num.HasValue)
                {
                    list.Add((x, y, c.Candidates));
                }
            });

        stack.Push(list);
    }

    private void Pop(Cell[,] cells, Stack<IList<(int X, int Y, int C)>> stack)
    {
        var list = stack.Pop();
        foreach (var (x, y, c) in list)
        {
            cells[x, y].Candidates = c;
            cells[x, y].Num = null;
        }
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
                        if (dups[v - 1])
                        {
                            return PuzzleState.NoSolution;
                        }

                        dups[v - 1] = true;
                    }
                }
            }
        }

        return solved ? PuzzleState.Solved : PuzzleState.InProgress;
    }

    private static Func<int, int, (int X, int Y)>[] Ways =
    [
        (x, y) => (x, y),
        (x, y) => (y, x),
        (x, y) => (x % 3 * 3 + y % 3, x / 3 * 3 + y / 3)
    ];

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

    private static void ForEach(Cell[,] cells, Action<int, int, Cell> action)
    {
        for (var i = 0; i < 9; i++)
        {
            for (var j = 0; j < 9; j++)
            {
                action(i, j, cells[i, j]);
            }
        }
    }

    private static IList<int> ToListOfInt(int n)
    {
        var r = new List<int>();
        for (var i = 0; i < 9; i++)
        {
            if ((n & (1 << i)) > 0)
            {
                r.Add(i + 1);
            }
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

    public char[][] Test1 =
    [
        ['5', '3', '.', '.', '7', '.', '.', '.', '.'],
        ['6', '.', '.', '1', '9', '5', '.', '.', '.'],
        ['.', '9', '8', '.', '.', '.', '.', '6', '.'],
        ['8', '.', '.', '.', '6', '.', '.', '.', '3'],
        ['4', '.', '.', '8', '.', '3', '.', '.', '1'],
        ['7', '.', '.', '.', '2', '.', '.', '.', '6'],
        ['.', '6', '.', '.', '.', '.', '2', '8', '.'],
        ['.', '.', '.', '4', '1', '9', '.', '.', '5'],
        ['.', '.', '.', '.', '8', '.', '.', '7', '9']
    ];

    public char[][] Test2 =
    [
        ['.', '6', '.', '.', '.', '.', '.', '5', '.'],
        ['5', '.', '.', '.', '9', '4', '.', '.', '8'],
        ['4', '.', '3', '.', '.', '.', '1', '.', '.'],

        ['.', '9', '.', '.', '.', '.', '.', '.', '.'],
        ['.', '.', '1', '.', '.', '7', '9', '.', '.'],
        ['.', '.', '.', '.', '1', '8', '.', '6', '.'],

        ['3', '.', '.', '.', '4', '.', '.', '.', '.'],
        ['.', '.', '7', '8', '6', '.', '4', '.', '.'],
        ['.', '4', '.', '3', '.', '1', '.', '7', '.']
    ];

    public char[][] Test3 =
    [
        ['.', '.', '9', '7', '4', '8', '.', '.', '.'],
        ['7', '.', '.', '.', '.', '.', '.', '.', '.'],
        ['.', '2', '.', '1', '.', '9', '.', '.', '.'],
        ['.', '.', '7', '.', '.', '.', '2', '4', '.'],
        ['.', '6', '4', '.', '1', '.', '5', '9', '.'],
        ['.', '9', '8', '.', '.', '.', '3', '.', '.'],
        ['.', '.', '.', '8', '.', '3', '.', '2', '.'],
        ['.', '.', '.', '.', '.', '.', '.', '.', '6'],
        ['.', '.', '.', '2', '7', '5', '9', '.', '.']
    ];
}