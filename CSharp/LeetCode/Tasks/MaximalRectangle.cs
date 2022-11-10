using System.Diagnostics;

namespace LeetCode.Tasks;

public class MaximalRectangleTask
{
	public int MaximalRectangle1(char[][] matrix)
	{
		// running sum
		var sy = matrix.Length;
		var sx = matrix[0].Length;
		var r = new int[sy][];
		for (var y = 0; y < sy; y++)
		{
			var row = matrix[y];
			var acc = new int[sx + 1];
			r[y] = acc;
			acc[0] = 0;
			for (var x = 0; x < sx; x++)
			{
				acc[x + 1] = acc[x] - '0' + row[x];
			}
		}

		var max = 0;
		// going all pairs of vertical slicing
		for (var x1 = 0; x1 <= sx; x1++)
		{
			for (var x2 = x1 + 1; x2 <= sx; x2++)
			{
				var s = 0;
				// getting maximum square through rows
				for (var y = 0; y < sy; y++)
				{
					var w = r[y][x2] - r[y][x1];
					if (w == x2 - x1)
					{
						s += w;
					}
					else
					{
						max = Math.Max(s, max);
						s = 0;
					}
				}

				max = Math.Max(s, max);
			}
		}

		return max;
	}

	public int MaximalRectangle(char[][] matrix)
	{
		//get connected areas
		var areas = GetAreas(matrix);

		var max = 0;
		foreach (var area in areas)
		{
			var sx = area.X2 - area.X1 + 1;
			var sy = area.Y2 - area.Y1 + 1;

			// running sum
			var r = new int[sy][];
			for (var y = 0; y < sy; y++)
			{
				var row = matrix[y + area.Y1];
				var acc = new int[sx + 1];
				r[y] = acc;
				acc[0] = 0;
				for (var x = 0; x < sx; x++)
				{
					acc[x + 1] = acc[x] - '0' + row[x + area.X1];
				}
			}

			// going all pairs of vertical slicing
			for (var x1 = 0; x1 <= sx; x1++)
			{
				for (var x2 = x1 + 1; x2 <= sx; x2++)
				{
					var s = 0;
					// getting maximum square through rows
					for (var y = 0; y < sy; y++)
					{
						var w = r[y][x2] - r[y][x1];
						if (w == x2 - x1)
						{
							s += w;
						}
						else
						{
							max = Math.Max(s, max);
							s = 0;
						}
					}

					max = Math.Max(s, max);
				}
			}
		}

		return max;
	}

	private IList<(int X1, int Y1, int X2, int Y2)> GetAreas(char[][] matrix)
	{
		var sy = matrix.Length;
		var sx = matrix[0].Length;
		var r = new List<(int X1, int Y1, int X2, int Y2)>();
		var visited = new HashSet<(int X, int Y)>();
		for (var y = 0; y < sy; y++)
		{
			for (var x = 0; x < sx; x++)
			{
				if (FindConnected(matrix, x, y, sx, sy, visited, out var bounds))
				{
					r.Add(bounds!.Value);
				}
			}
		}

		return r;
	}

	private bool FindConnected(
		char[][] matrix,
		int x,
		int y,
		int sx,
		int sy,
		ISet<(int X, int Y)> visited,
		out (int X1, int Y1, int X2, int Y2)? bounds)
	{
		var current = new HashSet<(int X, int Y)>();
		if (MarkConnected(x, y))
		{
			var x1 = current.Select(c => c.X).Min();
			var x2 = current.Select(c => c.X).Max();
			var y1 = current.Select(c => c.Y).Min();
			var y2 = current.Select(c => c.Y).Max();

			bounds = (x1, y1, x2, y2);
			return true;
		}

		bounds = null;
		return false;

		bool MarkConnected(int xx, int yy)
		{
			if (matrix[yy][xx] == '1' && visited.Add((xx, yy)) && current.Add((xx, yy)))
			{
				if (xx > 0) MarkConnected(xx - 1, yy);
				if (yy > 0) MarkConnected(xx, yy - 1);
				if (xx < sx - 1) MarkConnected(xx + 1, yy);
				if (yy < sy - 1) MarkConnected(xx, yy + 1);
				return true;
			}

			return false;
		}
	}


	public char[][] ReadTestData(string file)
	{
		var f = File.OpenText(file);
		var d = f.ReadLine()!
		         .Trim('[', ']')
		         .Replace("],[", "$")
		         .Split('$')
		         .Select(x => x.Trim('[', ']').Split(',').Select(x => x.Trim('"')[0]).ToArray())
		         .ToArray();

		return d;
	}

	public static void TestPerf()
	{
		var sw = Stopwatch.StartNew();
		sw.Restart();
		sw.Stop();

		for (int i = 1; i < 10; i++)
		{
			var t1 = GridTest(2500, i);
			sw.Restart();
			Verify(t1, i * i);
			sw.Stop();
			Console.WriteLine($"{i}: {sw.Elapsed}");
		}

		var randOuts = new[] { 0, 4602, 5388, 4635, 4431, 3954 };
		for (int i = 1; i < randOuts.Length; i++)
		{
			var t1 = RandTest(2500, i);
			sw.Restart();
			Verify(t1, randOuts[i]);
			sw.Stop();
			Console.WriteLine($"{i}: {sw.Elapsed}");
		}
	}

	private static char[][] GridTest(int n, int k)
	{
		var r = new char[n][];
		for (int i = 0; i < n; i++)
		{
			var q = r[i] = new char[n];
			for (int j = 0; j < n; j++)
			{
				q[j] = (char)((i / k + j / k) % 2 + '0');
			}
		}

		return r;
	}

	private static char[][] RandTest(int n, int seed)
	{
		var rnd = new Random(seed);

		var z = new string('0', n);
		var r = new char[n][];
		for (int k = 0; k < n; k++)
			r[k] = z.ToCharArray();

		for (int k = 0; k < n; k++)
		{
			var a = rnd.Next(n);
			var b = rnd.Next(a, n);
			var c = rnd.Next(n);
			if (rnd.Next(2) == 0)
				for (int i = a; i <= b; i++)
					r[c][i] = '1';
			else
				for (int i = a; i <= b; i++)
					r[i][c] = '1';
		}

		return r;
	}

	private static void Verify(char[][] input, int output) =>
		Trace.Assert(output == new MaximalRectangleTask().MaximalRectangle(input));
}