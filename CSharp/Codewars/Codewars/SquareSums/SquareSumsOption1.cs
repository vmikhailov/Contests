using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Codewars.Codewars
{
    using Graph = IDictionary<int, (int len, int[] sq)>;

    public static class SquareSumsOption1
    {
        public class Cell
        {
            public Cell()
            {
                Options = new List<int[]>();
            }

            public Cell(int n)
            {
                Options = new List<int[]>
                {
                    new[] { n }
                };
            }

            public List<int[]> Options { get; private set; }

            public static Cell Add(Cell c1, Cell c2)
            {
                if (c1 == null) return c2;
                if (c2 == null) return c1;

                var c = new Cell();

                c.Options.AddRange(c1.Options.Concat(c2.Options));

                return c;
            }

            public static Cell Multiply(Cell c1, Cell c2)
            {
                if (c1 == null || c2 == null) return null;

                var c = new Cell();

                foreach (var o1 in c1.Options)
                {
                    foreach (var o2 in c2.Options)
                    {
                        c.Options.Add(o1.Concat(o2).ToArray());
                    }
                }

                return c;
            }


            public override string ToString()
            {
                return string.Join(" + ", Options.Select(x => string.Join("-", x)));
            }

            public void Simplify(int i, int j)
            {
                var newOpt = Options.Where(x => !(x.Contains(i) || x.Contains(j))).ToList();
                Options = newOpt.Any() ? newOpt : null;
            }
        }

        public static List<List<int>> Decompose(int n)
        {
            var v = Enumerable.Range(1, n).ToArray();
            var a = BuildAdjacencyMatrix(n);
            var b = Substitute(n, a, v);
            var c = Multiply(n, b, a);
            Print(a);

            for (var i = 0; i < n - 3; i++)
            {
                c = Multiply(n, b, c);
                Simplify(n, c);
            }

            var result = new List<List<int>>();

            void FindChain(int i, int j)
            {
                var opt = c[i, j]?.Options;
                if (opt != null)
                {
                    foreach (var o in opt)
                    {
                        if (o.Length == n - 2)
                        {
                            var r = new List<int>();
                            r.Add(i + 1);
                            r.AddRange(o);
                            r.Add(j + 1);
                            result.Add(r);
                        }
                    }
                }
            }

            Iterate(n, FindChain);

            foreach (var r in result)
            {
                //Write($"{string.Join("-", r)}\n");
            }
            //Print(c);

            return result;
        }


        private static Cell[,] Multiply(int n, Cell[,] b, int[,] a)
        {
            return Multiply(n, b, a, (cell, i) => i == 1 ? cell : null, Cell.Add);
        }

        private static Cell[,] Multiply(int n, Cell[,] b, Cell[,] c)
        {
            Cell Simplify(int i, int j, Cell c)
            {
                c?.Simplify(i + 1, j + 1);
                
                return c?.Options != null ? c : null;
            }
            return Multiply(n, b, c, Cell.Multiply, Cell.Add, Simplify);
        }

        private static T3[,] Multiply<T1, T2, T3>(
            int n,
            T1[,] a,
            T2[,] b,
            Func<T1, T2, T3> multiply,
            Func<T3, T3, T3> add,
            Func<int, int, T3, T3> final = null)
            where T3 : new()
        {
            var result = new T3[n, n];

            void CellAction(int i, int j)
            {
                if (i == j)
                {
                    result[i, j] = default;

                    return;
                }
                
                T3 r = default;
                for (var k = 0; k < n; k++)
                {
                    r = add(r, multiply(a[i, k], b[k, j]));
                }

                result[i, j] = final != null ? final(i, j, r) : r;
            }

            Iterate(n, CellAction);

            return result;
        }

        private static void Simplify(int n, Cell[,] a)
        {
            Iterate(n, (i, j) => a[i, j] = i == j ? null : a[i, j]);
            Iterate(n, (i, j) => a[i, j]?.Simplify(i + 1, j + 1));
        }

        private static Cell[,] Substitute(int n, int[,] matrix, int[] vector)
        {
            var m = new Cell[n, n];
            void CellAction(int i, int j) => m[i, j] = matrix[i, j] == 1 ? new Cell(vector[j]) : null;

            Iterate(n, CellAction);

            return m;
        }

        private static int[,] BuildAdjacencyMatrix(int n)
        {
            var mq = (int)Math.Sqrt(n + n - 1);
            var squares = Enumerable.Range(1, mq).Select(x => x * x).OrderBy(x => x).ToHashSet();
            var matrix = new int[n, n];

            void CellAction(int i, int j)
            {
                if (squares.Contains(i + j + 2) && j != i)
                {
                    matrix[i, j] = 1;
                    //matrix[j, i] = 1;
                }
            }

            Iterate(n, CellAction);

            return matrix;
        }

        private static void Iterate(int n, Action<int, int> cellAction, Action<int> preRowAction = null, Action<int> postRowAction = null)
        {
            for (var i = 0; i < n; i++)
            {
                preRowAction?.Invoke(i);
                for (var j = 0; j < n; j++)
                {
                    cellAction(i, j);
                }

                postRowAction?.Invoke(i);
            }
        }

        private static void Print(int[,] matrix)
        {
            var n = matrix.GetLength(0);
            Iterate(n, (i, j) => Write($"{matrix[i, j]} "), null, i => Write("\n"));
            Write("\n");
        }

        private static void Print(Cell[,] matrix)
        {
            var n = matrix.GetLength(0);

            var p = new string[n, n];
            var max = 0;

            void MeasureCell(int i, int j)
            {
                var s = matrix[i, j]?.ToString() ?? "";
                max = max > s.Length ? max : s.Length;
                p[i, j] = s;
            }

            void PrintCell(int i, int j)
            {
                var s = p[i, j].PadLeft(max);
                Write($"|{s}");
            }

            Iterate(n, MeasureCell);
            Iterate(n, PrintCell, i => Write($"{i + 1}".PadLeft(2)), i => Write("|\n"));

            Write("\n");
        }

        private static void Write(object obj)
        {
            //Console.Write(obj);
            TestContext.Write(obj);
            //Debug.Write(obj);
        }


        public static int[] Decompose1(int n)
        {
            var mq = (int)Math.Sqrt(n + n - 1);
            var squares = Enumerable.Range(2, mq - 1).Select(x => x * x).OrderBy(x => x).ToList();
            var graph = Enumerable.Range(1, n)
                                  .Select(
                                      x => (value: x, sq: squares.Select(y => y - x)
                                                                 .Where(y => y > 0 && y <= n)
                                                                 .ToArray()))
                                  .ToDictionary(x => x.value, x => (len: x.sq.Length, x.sq));

           
            Iterations = 0;
            if (Impl(n, graph, out var result))
            {
                return result.Reverse().ToArray();
            }

            return null;
        }

        public static long C(int n, int k)
        {
            if (k > n / 2) k = n - k;

            var r = 1L;
            for (var i = n - k + 1; i <= n; i++)
            {
                r *= i;
            }

            for (var i = 2; i <= k; i++)
            {
                r /= i;
            }

            return r;
        }

        public static int Iterations { get; private set; }

        private static bool Impl(int n, Graph graph, out IList<int> result)
        {
            result = new List<int>();
            var used = new bool[n];

            foreach (var v in graph.Keys)
            {
                //TestContext.WriteLine($"Probing {i}");
                var vv = 17;
                used[vv - 1] = true;

                if (Impl(n, vv, 1, used, graph, result))
                {
                    result.Add(vv);

                    return true;
                }

                used[vv - 1] = false;
            }

            return false;
        }

        private static bool Impl(
            int n,
            int p,
            int c,
            bool[] used,
            Graph graph,
            IList<int> result)
        {
            if (n == c) return true;
            foreach (var v in graph[p].sq)
            {
                if (used[v - 1]) continue;

                used[v - 1] = true;
                Iterations++;

                if (Impl(n, v, c + 1, used, graph, result))
                {
                    result.Add(v);

                    return true;
                }

                used[v - 1] = false;
            }

            return false;
        }
    }
}