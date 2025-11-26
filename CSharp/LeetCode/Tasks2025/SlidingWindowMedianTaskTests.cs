using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.Tasks2025;

[TestFixture]
public class SlidingWindowMedianTaskTests
{
    private SlidingWindowMedianTask.Solution Create() => new SlidingWindowMedianTask.Solution();

    [Test]
    public void Example_Test_12()
    {
        var s = Create();
        var nums = new[] { 1, 2 };
        var res = s.MedianSlidingWindow(nums, 2);
        res.Should().Equal(new double[] { 1.5 });
    }


    [Test]
    public void Example_FromLeetCode_ShouldMatchExpected()
    {
        var s = Create();
        var nums = new[] { 1, 3, -1, -3, 5, 3, 6, 7 };
        var res = s.MedianSlidingWindow(nums, 3);
        res.Should().Equal(new double[] { 1.0, -1.0, -1.0, 3.0, 5.0, 6.0 });
    }

    [Test]
    public void WindowSizeOne_ReturnsOriginalAsDoubles()
    {
        var s = Create();
        var nums = new[] { 5, 2, 9, -1 };
        var res = s.MedianSlidingWindow(nums, 1);
        res.Should().Equal(nums.Select(x => (double)x).ToArray());
    }

    [Test]
    public void WindowEqualsArrayLength_SingleMedian()
    {
        var s = Create();
        var nums = new[] { 2, 1, 4, 7 };
        var res = s.MedianSlidingWindow(nums, nums.Length);

        // median of [2,1,4,7] -> (2 + 4) / 2 = 3
        res.Should().Equal(new double[] { 3.0 });
    }

    [Test]
    public void EvenWindowSize_ReturnsAverages()
    {
        var s = Create();
        var nums = new[] { 1, 2, 3, 4, 5 };
        var res = s.MedianSlidingWindow(nums, 4);

        // windows: [1,2,3,4] -> 2.5, [2,3,4,5] -> 3.5
        res.Should().Equal(new double[] { 2.5, 3.5 });
    }

    [Test]
    public void AllEqualElements_ReturnsSameValues()
    {
        var s = Create();
        var nums = Enumerable.Repeat(7, 6).ToArray();
        var res = s.MedianSlidingWindow(nums, 3);
        res.Should().Equal(Enumerable.Repeat(7.0, nums.Length - 3 + 1).ToArray());
    }

    [Test]
    public void IncreasingSequence_CorrectMedians()
    {
        var s = Create();
        var nums = new[] { 1, 2, 3, 4, 5, 6, 7 };
        var res = s.MedianSlidingWindow(nums, 3);

        // medians: [2,3,4,5,6]
        res.Should().Equal(new double[] { 2.0, 3.0, 4.0, 5.0, 6.0 });
    }

    [Test]
    public void DecreasingSequence_CorrectMedians()
    {
        var s = Create();
        var nums = new[] { 7, 6, 5, 4, 3, 2, 1 };
        var res = s.MedianSlidingWindow(nums, 3);
        res.Should().Equal(new double[] { 6.0, 5.0, 4.0, 3.0, 2.0 });
    }

    [Test]
    public void ContainsNegativeNumbers_CorrectMedians()
    {
        var s = Create();
        var nums = new[] { -5, -1, -3, -2, 0 };
        var res = s.MedianSlidingWindow(nums, 2);

        // windows: [-5,-1]->-3, [-1,-3]->-2, [-3,-2]->-2.5, [-2,0]->-1
        res.Should().Equal(new double[] { -3.0, -2.0, -2.5, -1.0 });
    }

    [Test]
    public void Duplicates_Mixed_CorrectMedians()
    {
        var s = Create();
        var nums = new[] { 1, 2, 2, 3, 2, 1 };
        var res = s.MedianSlidingWindow(nums, 3);

        // windows and medians: [1,2,2]->2, [2,2,3]->2, [2,3,2]->2, [3,2,1]->2
        res.Should().Equal(new double[] { 2.0, 2.0, 2.0, 2.0 });
    }

    [Test]
    public void SingleElementArray_ReturnsSingleMedian()
    {
        var s = Create();
        var nums = new[] { 42 };
        var res = s.MedianSlidingWindow(nums, 1);
        res.Should().Equal(new double[] { 42.0 });
    }
}
