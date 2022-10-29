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
				tops.Insert(h - prev);
				prev = h;
				i++;
			}
		}

		return i;
	}
}