namespace LeetCode.Tasks;

public class ThreeSumTask
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        var r = new List<IList<int>>();
        nums = nums.Order().ToArray();

        for (var i = 0; i < nums.Length - 2; i++)
        {
            for (var j = i + 1; j < nums.Length - 1; j++)
            {
                var v = -(nums[i] + nums[j]);

                var h = Array.BinarySearch(nums, j + 1, nums.Length - j - 1, v);

                if (h > j)
                {
                    r.Add(new List<int>([nums[i], nums[j], nums[h]]));
                }
            }
        }

        return r;
    }

    public static void Test()
    {
        var task = new ThreeSumTask();
        var r = task.ThreeSum([-1, 0, 1, 2, -1, -4]);
        Console.WriteLine(string.Join(", ", r.Select(x => "[" + string.Join(", ", x) + "]")));

        r = task.ThreeSum([0,0,0]);
        Console.WriteLine(string.Join(", ", r.Select(x => "[" + string.Join(", ", x) + "]")));
    }
}
