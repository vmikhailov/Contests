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

		var result = TrySolve(0, diffs.Length);
		return result;

		int TrySolve(int min, int max, long sum = 0, TopNSortedArray<long>? maximums = null)
		{
			if (min > max) return -1;
			var m = (min + max) / 2;

			int[] selected;
			if (maximums != null)
			{
				selected = diffs[min..m];
			}
			else
			{
				selected = diffs[0..m];
				maximums = new(ladders);
			}
			
			foreach (var s in selected.Where(x => x > 0))
			{
				maximums.Add(s);
				sum += s;
			}

			var remaining = sum - maximums.Sum();
			if (remaining == bricks || remaining < bricks && min == max)
			{
				return m;
			}

			if (remaining > bricks)
			{
				return TrySolve(min, m - 1);
			}
			else
			{
				var r = TrySolve(m + 1, max, sum, maximums.Clone());
				return r == -1 ? m : r;
			}
		}
	}

	public static (int[] Heights, int Bricks, int Ladders) ReadTestData(string file)
	{
		var f = File.OpenText(file);
		var h = f.ReadLine()!.Trim('[',']').Split(',').Select(int.Parse).ToArray();
		var b = int.Parse(f.ReadLine()!);
		var l = int.Parse(f.ReadLine()!);
		return (h, b, l);
	}
}