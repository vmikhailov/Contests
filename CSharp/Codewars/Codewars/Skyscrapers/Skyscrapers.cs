using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Codewars.Codewars.Skyscrapers
{
    public partial class Skyscrapers
    {
        private readonly int[] _clues;
        private readonly Cell[,] _field;
        private readonly int _n;

        public Skyscrapers(int n, int[] clues)
        {
            _n = n;
            _clues = clues;
            _field = new Cell[_n, _n];
            for (var x = 0; x < _n; x++)
            {
                for (var y = 0; y < _n; y++)
                {
                    _field[x, y] = new Cell();
                    foreach (var v in Enumerable.Range(1, _n))
                    {
                        _field[x, y].Set(v);
                    }
                }
            }
        }

        public static int[][] SolvePuzzle(int n, int[] clues)
        {
            var solver = new Skyscrapers(n, clues);

            return solver.Solve();
        }

        public int[][] Solve()
        {
            Mark();
            Iterate();
            return Result();
        }

        private void Mark()
        {
            for (var i = 0; i < 4 * _n; i++)
            {
                var v = GetVector(i);
                if (_clues[i] > 0)
                {
                    Mark(v, _clues[i]);
                }
            }
        }

        private void Mark(Cell[] vector, int clue)
        {
            if (clue == _n)
            {
                for (var i = 0; i < _n; i++)
                {
                    vector[i].Value = i + 1;
                }
            }
            else if (clue == 1)
            {
                vector[0].Value = _n;
                for (var i = 1; i < _n; i++)
                {
                    vector[i].Remove(_n);
                }
            }
            else
            {
                var c = _n - clue + 2;
                for (var i = 0; i < _n; i++)
                {
                    for (var j = c + i; j <= _n; j++)
                    {
                        vector[i].Remove(j);
                    }
                }
            }
        }
        
        private void Iterate()
        {
            var changed = new HashSet<int>();
            var k = 0;
            while(true)
            { 
                changed.Clear();
                for (var i = 0; i < 2 * _n; i++)
                {
                    var clue = _clues[i];
                    var oppositeClue = _clues[((i / _n + 2) % 4) * _n + (_n - i % _n - 1)];
                    if (clue == 0 &&  oppositeClue == 0 && k < 2) continue; 
                    var v = GetVector(i);
                    LimitOptions(i, v, clue, oppositeClue, changed);
                }
                if (!changed.Any() && k++ > 2) break;
                Reduce();
            }
        }

        private void LimitOptions(int i, Cell[] vector, int clue, int oppositeClue, HashSet<int> changed)
        {
            var options = new Cell[_n];
            for (var j = 0; j < _n; j++)
            {
                options[j] = new Cell();
            }
            
            var lst = EnumerateOptions(vector, clue, oppositeClue).ToList();
            foreach (var opt in lst)
            {
                for (var j = 0; j < _n; j++)
                {
                    options[j].Set(opt[j]);
                }
            }

            for (var j = 0; j < _n; j++)
            {
                if (vector[j].Intersect(options[j]))
                {
                    changed.Add(i);
                }
            }
        }

        private int[][] Result()
        {
            var r = new int[_n][];

            for (var y = 0; y < _n; y++)
            {
                r[y] = new int[_n];
                for (var x = 0; x < _n; x++)
                {
                    r[y][x] = _field[x, y].Value;
                }
            }

            return r;
        }

        private Cell[] GetVector(int k)
        {
            var vector = new Cell[_n];
            var (x, y, dx, dy) = GetCoordsAndDelta(k);
            for (var j = 0; j < _n; j++)
            {
                vector[j] = _field[x, y];
                x += dx;
                y += dy;
            }

            return vector;
        }
        
        private IEnumerable<int[]> EnumerateOptions(Cell[] vector, int clue, int oppositeClue)
        {
            var v = vector.Select(x => x.ToArray()).ToArray();
            var n = v.Select(x => x.Length).Aggregate((x, y) => x * y);

            var used = new bool[_n];
            var sample = new int[v.Length];
            for (var i = 0; i < n; i++)
            {
                var k = i;
                var h = 0;
                var m = 0;
                Array.Fill(used, false);
                for (var j = 0; j < v.Length; j++)
                {
                    var l = v[j].Length;
                    var d = v[j][k % l];

                    if (used[d - 1])
                    {
                        break;
                    }

                    if (d > m)
                    {
                        h++;
                        m = d;
                    }

                    if (clue > 0 && h > clue)
                    {
                        break;
                    }

                    used[d - 1] = true;
                    sample[j] = d;
                    k /= l;

                    if ((j == v.Length - 1) &&
                        (clue == 0 || h == clue) &&
                        (oppositeClue == 0 || CountVisibleInverted(sample) == oppositeClue))
                    {
                        yield return sample;
                        sample = new int[v.Length];
                    }
                }
            }
        }

        private int CountVisibleInverted(int[] vector)
        {
            var m = 0;
            var c = 0;
            for (var i = vector.Length - 1; i >= 0; i--)
            {
                var v = vector[i];
                if (v > m)
                {
                    c++;
                    m = v;
                }
            }

            return c;
        }
        
        private void Reduce(IEnumerable<int> ids = null)
        {
            var toProcess = new HashSet<int>();
            foreach (var id in ids ?? Enumerable.Range(0, 2 * _n))
            {
                toProcess.Add(id);
            }
            
            var processed = new HashSet<int>();
            while (toProcess.Count > 0)
            {
                var i = toProcess.First();
                var next = Reduce(i, GetVector(i));
                processed.Add(i);
                toProcess.Remove(i);
                foreach (var j in next)
                {
                    toProcess.Add(j);
                }
            }
        }
        
        private IEnumerable<int> Reduce(int k, Cell[] vector)
        {
            var changed = new List<int>();
            
            for (var i = 0; i < vector.Length; i++)
            {
                var v = vector[i];

                if (v.Count > 1) continue;
                for (var j = 0; j < vector.Length; j++)
                {
                    if (j == i) continue;
                    var w = vector[j];
                    if (w.Except(v))
                    {
                        //adding orthogonal line to check
                        changed.Add(k < _n ? _n + j : _n - j - 1);
                    }
                }
            }
            
            for (var i = 1; i <= _n; i++)
            {
                var col = -1;
                for (var j = 0; j < vector.Length; j++)
                {
                    if (vector[j].Contains(i))
                    {
                        if (col != -1)
                        {
                            col = -1;
                            break;
                        }
                        col = j;
                    }
                }

                if (col != -1)
                {
                    var j = col;
                    var c = vector[j];
                    if (c.Count > 1)
                    {
                        c.Value = i;
                        //adding orthogonal line to check
                        changed.Add(k < _n ? _n + j : _n - j - 1);
                    }
                }
            }

            return changed;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private (int x, int y, int dx, int dy) GetCoordsAndDelta(int i)
        {
            return (i / _n) switch
            {
                0 => (i % _n, 0, 0, 1),
                1 => (_n - 1, i % _n, -1, 0),
                2 => (_n - i % _n - 1, _n - 1, 0, -1),
                3 => (0, _n - i % _n - 1, 1, 0),
                _ => (0, 0, 0, 0)
            };
        }
    }
}