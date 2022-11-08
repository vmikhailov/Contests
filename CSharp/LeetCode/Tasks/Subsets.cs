namespace LeetCode.Tasks;

public class SubsetsTask
{
	public IList<IList<int>> Subsets(int[] nums) 
	{
		var r = new List<IList<int>>();
		r.Add(new int[0]);
        
		for(var i = 1; i < nums.Length; i++)
		{
			FillSubsets(r, new(), 0, i);
		}
                        
		r.Add(nums);
        
		return r;
        
		void FillSubsets(IList<IList<int>> r, Stack<int> c, int k, int n)
		{
			if (n == 0)
			{
				r.Add(c.Reverse().ToList());
				return;
			}

			for(var i = k; i < nums.Length; i++)
			{
				c.Push(nums[i]);
				FillSubsets(r, c, i + 1, n - 1);
				c.Pop();
			}
		}
	}
}