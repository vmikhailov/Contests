namespace CodeForcesSimple.LeetCode;

public class FurthestBuilding
{
	public static int Solve(int[] heights, int bricks, int ladders)
	{
		var diffs = new int[heights.Length - 1];
		var p = heights[0];
		for (var i = 0; i < heights.Length - 1; i++)
		{
			var h = heights[i + 1];
			diffs[i] = h <= p ? 0 : h - p;
			p = h;
		}

		var result = TrySolve(0, diffs.Length - 1, 0, new(ladders));
		return result + 1;

		int TrySolve(int min, int max, long sum, TopNSortedArray<long> maximums)
		{
			var step = 2;
			
			while (min <= max)
			{
				var m = min + (max - min) / step;
				var selected = diffs[min..(m + 1)];
				var mm = maximums.Clone();
				var ss = sum;
				foreach (var s in selected)
				{
					mm.Add(s);
					ss += s;
				}

				var steps = ss - mm.Sum();
				if (steps <= bricks)
				{
					var r = TrySolve(m + 1, max, ss, mm);
					return r == -1 ? m : r;
				}

				max = m - 1;
				step *= 2;
			}

			return -1;
		}
	}
	
	public static int Solve2(int[] heights, int bricks, int ladders)
	{
		var mm = new TopNSortedArray<long>(ladders);
		var ss = 0L;
		var i = 1;
		var rem = 0L;
		while (rem <= bricks && i < heights.Length)
		{
			var d = heights[i] - heights[i - 1];
			mm.Add(d);
			ss += d;
			rem = ss - mm.Sum();
			i++;
		}

		return i - 1;
	}

	public static (int[] Heights, int Bricks, int Ladders) ReadTestData(string file)
	{
		var f = File.OpenText(file);
		var h = f.ReadLine()!.Trim('[',']').Split(',').Select(int.Parse).ToArray();
		var b = int.Parse(f.ReadLine()!);
		var l = int.Parse(f.ReadLine()!);
		return (h, b, l);
	}
	
	public static int Solve3(int[] heights, int bricks, int ladders)
	{
		var diffs = new int[heights.Length - 1];
		var p = heights[0];
		for (var i = 0; i < heights.Length - 1; i++)
		{
			var h = heights[i + 1];
			diffs[i] = h <= p ? 0 : h - p;
			p = h;
		}

		var result = TrySolve(0, diffs.Length - 1, 0, new(ladders));
		return result + 1;

		int TrySolve(int min, int max, long sum, PriorityQueue<long, long> maximums)
		{
			var step = 2;
			
			while (min <= max)
			{
				var m = min + (max - min) / step;
				var selected = diffs[min..(m + 1)];
				var mm = new PriorityQueue<long, long>();
				mm.EnqueueRange(maximums.UnorderedItems);
				var ss = sum;
				foreach (var s in selected)
				{
					mm.Enqueue(s, s);
					ss += s;
				}

				var steps = ss - mm.UnorderedItems.Sum(x => x.Element);
				if (steps <= bricks)
				{
					var r = TrySolve(m + 1, max, ss, mm);
					return r == -1 ? m : r;
				}

				max = m - 1;
				step *= 2;
			}

			return -1;
		}
	}
}