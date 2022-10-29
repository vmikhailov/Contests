namespace LeetCode;

public class Permutations
{
	public IList<IList<int>> Permute(int[] nums)
	{
		var list = new List<IList<int>>();
		var used = new bool[nums.Length];
		var current = new int[nums.Length];
		BuildPermutations(nums, used, current, 0, list);
		return list;
	}

	private void BuildPermutations(int[] nums, bool[] used, int[] current, int p, List<IList<int>> list)
	{
		if (p == nums.Length)
		{
			list.Add(current.ToList());		
		}
		
		for (var i = 0; i < nums.Length; i++)
		{
			if (used[i]) continue;
			
			used[i] = true;
			current[p] = nums[i];
			BuildPermutations(nums, used, current, p + 1, list);
			used[i] = false;
		}
	}
}

public class Permutations2
{
	public IList<IList<int>> Permute(int[] nums)
	{
		var list = new List<IList<int>>();
		var used = new bool[nums.Length];
		var current = new int[nums.Length];
		
		BuildPermutations(0);
		return list;
		
		void BuildPermutations(int p)
		{
			if (p == nums.Length)
			{
				list.Add(current.ToList());		
			}
		
			for (var i = 0; i < nums.Length; i++)
			{
				if (used[i]) continue;
			
				used[i] = true;
				current[p] = nums[i];
				BuildPermutations(p + 1);
				used[i] = false;
			}
		}
	}
}