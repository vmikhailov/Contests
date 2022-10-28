namespace LeetCode;

public static class SquareSums
{
	private static int[] numbers;
	public static int GetPermutations(int[] nums)
	{
		numbers = nums;
		Array.Sort(nums);
		var c = nums.Where(x => x == 2).Count();
		var p = c > 0 ? Fact(c) : 1;
		var n = nums.Length;
		var graph = new List<IList<int>>();
		
		for (var i = 0; i < n; i++)
		{
			var sq = new List<int>();
			graph.Add(sq);
			for (var j = 0; j < n; j++)
			{
				if(i == j) continue;
				var v = nums[i] + nums[j];
				var q = (int)Math.Sqrt(v);
				if (v == q * q) sq.Add(j);
			}
		}

		if (graph.Any(x => x.Count == 0)) return 0;

		return Count(graph)/p;
	}

	private static int Fact(int n)
	{
		var k = n;
		while (--n > 0) k *= n;
		return k;
	}

	private static int Count(IList<IList<int>> graph)
	{
		var n = graph.Count;
		var used = new bool[n];
		
		int Impl(int i, int k)
		{
			if (used[i]) return 0;
			if (k == n - 1) return 1;
			
			used[i] = true;
			var r = graph[i].Select(x => Impl(x, k + 1)).Sum();
			used[i] = false;
			
			return r;
		}
		
		var result = Enumerable.Range(0, n).Select(x => Impl(x, 0)).Sum();
		return result;
	}
}