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

		int TrySolve(int min, int max, TopNSortedArray<long>? maximums = null)
		{
			if (min > max) return -1;
			var m = (min + max) / 2;

			if (maximums != null)
			{
				var selected = diffs[0..m];
				
			}
			maximums ??= new(ladders);
			var selected = diffs[0..m];

			var sum = 0L;
			foreach (var s in selected)
			{
				maximums.Add(s);
				sum += s;
			}

			sum -= maximums.Sum();
			if (sum == bricks || sum < bricks && min == max)
			{
				return m;
			}

			if (sum > bricks)
			{
				return TrySolve(min, m - 1);
			}
			else
			{
				var r = TrySolve(m + 1, max, maximums);
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