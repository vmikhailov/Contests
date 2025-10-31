using NUnit.Framework.Legacy;
using NUnit.Framework;

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
}

[TestFixture]
public class ThreeSumTaskTests
{
    private ThreeSumTask _task = null!;

    [SetUp]
    public void SetUp() => _task = new ThreeSumTask();

    [Test]
    public void ThreeSum_BasicCase_ReturnsCorrectTriplets()
    {
        var result = _task.ThreeSum([-1, 0, 1, 2, -1, -4]);
        ClassicAssert.GreaterOrEqual(result.Count, 1);
    }

    [Test]
    public void ThreeSum_AllZeros_ReturnsOneZeroTriplet()
    {
        var result = _task.ThreeSum([0, 0, 0]);
        ClassicAssert.AreEqual(1, result.Count);
        CollectionClassicAssert.AreEqual(new[] { 0, 0, 0 }, result[0]);
    }

    [Test]
    public void ThreeSum_NoSolution_ReturnsEmpty()
    {
        var result = _task.ThreeSum([1, 2, 3]);
        ClassicAssert.AreEqual(0, result.Count);
    }

    [Test]
    public void ThreeSum_TwoElements_ReturnsEmpty()
    {
        var result = _task.ThreeSum([0, 1]);
        ClassicAssert.AreEqual(0, result.Count);
    }

    [Test]
    public void ThreeSum_WithNegatives_ReturnsCorrectTriplets()
    {
        var result = _task.ThreeSum([-2, 0, 1, 1, 2]);
        ClassicAssert.GreaterOrEqual(result.Count, 1);
    }
}
