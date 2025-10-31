using NUnit.Framework.Legacy;
using NUnit.Framework;

namespace LeetCode.Tasks;

public class MedianSlidingWindowTask
{
    public double[] MedianSlidingWindow(int[] nums, int k)
    {

        return [];
    }
}

[TestFixture]
public class MedianSlidingWindowTaskTests
{
    private MedianSlidingWindowTask _task = null!;

    [SetUp]
    public void SetUp() => _task = new MedianSlidingWindowTask();

    private static bool AreEqual(double[] a, double[] b, double eps = 1e-5)
    {
        if (ReferenceEquals(a, b)) return true;
        if (a.Length != b.Length) return false;
        return !a.Where((t, i) => Math.Abs(t - b[i]) > eps).Any();
    }

    [Test]
    public void MedianSlidingWindow_BasicCase_ReturnsCorrect()
    {
        var result = _task.MedianSlidingWindow([1, 3, -1, -3, 5, 3, 6, 7], 3);
        ClassicAssert.IsTrue(AreEqual([1, -1, 3, 5], result));
    }

    [Test]
    public void MedianSlidingWindow_EvenWindowSize_ReturnsAverages()
    {
        var result = _task.MedianSlidingWindow([1, 2, 3, 4], 4);
        ClassicAssert.IsTrue(AreEqual([2.5], result));
    }

    [Test]
    public void MedianSlidingWindow_WindowSizeTwo_ReturnsCorrect()
    {
        var result = _task.MedianSlidingWindow([1, 2, 3, 4, 5], 2);
        ClassicAssert.IsTrue(AreEqual([1.5, 2.5, 3.5, 4.5], result));
    }

    [Test]
    public void MedianSlidingWindow_AllSameValues_ReturnsSameValue()
    {
        var result = _task.MedianSlidingWindow([1, 1, 1, 1], 2);
        ClassicAssert.IsTrue(AreEqual([1.0, 1.0, 1.0], result));
    }

    [Test]
    public void MedianSlidingWindow_SingleElement_ReturnsElement()
    {
        var result = _task.MedianSlidingWindow([5], 1);
        ClassicAssert.IsTrue(AreEqual([5.0], result));
    }
}
