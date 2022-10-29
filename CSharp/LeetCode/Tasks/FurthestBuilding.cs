namespace CodeForcesSimple.LeetCode;

public class FurthestBuilding
{
	public static int Solve(int[] heights, int bricks, int ladders)
	{
		var b = bricks;
		var i = 0;
		var n = heights.Length;

		var tops = new TopNSortedArray(ladders);

		while (ladders > 0 && i < n)
		{
			if (tops.Count > 0)
			{
				b += tops[tops.Count - 1];
				tops.RemoveAt(tops.Count - 1);
				ladders--;
			}

			var prev = 0;
			while (i < n && b >= heights[i])
			{
				var h = heights[i];
				b -= h;
				tops.Add(h - prev);
				prev = h;
				i++;
			}
		}

		return i;
	}
}

public class FurthestBuilding2
{
	public static int Solve(int[] heights, int bricks, int ladders)
	{
		var diffs = new int[heights.Length];
		var p = 0;
		for (var i = 0; i < heights.Length; i++)
		{
			var h = heights[i];
			diffs[i] = h <= p ? 0 : h - p;
			p = h;
		}

		var result = TrySolve(0, diffs.Length);
		return result;

		int TrySolve(int min, int max)
		{
			if (min > max) return -1;
			
			var maximums = new TopNSortedArray(ladders);
			var m = (min + max) / 2;
			var selected = diffs[0..m];
			
			var sum = 0;
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
			
			return sum > bricks ? TrySolve(min, m - 1) : TrySolve(m + 1, max);
		}
	}
}