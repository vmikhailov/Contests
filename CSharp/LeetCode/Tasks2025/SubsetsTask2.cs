namespace LeetCode.Tasks2025;

public class SubsetsTask2
{
    public IList<IList<int>> SubsetsWithDup(int[] nums) {
        Array.Sort(nums);
        var res = new List<IList<int>>();
        var path = new List<int>();

        Dfs(0);
        return res;

        void Dfs(int start)
        {
            res.Add(new List<int>(path));
            for (var i = start; i < nums.Length; i++)
            {
                if (i > start && nums[i] == nums[i - 1]) continue;

                path.Add(nums[i]);
                Dfs(i + 1);
                path.RemoveAt(path.Count - 1);
            }
        }
    }
}

