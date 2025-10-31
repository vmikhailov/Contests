using NUnit.Framework.Legacy;
using NUnit.Framework;

namespace LeetCode.Tasks;

public class LargestNumberClass
{
    public string LargestNumber(int[] nums)
    {
        var comparer = new CustomComparer();
        var s = nums.OrderByDescending(x => x, comparer)
                    .Select(x => x.ToString())
                    .Aggregate("", (r, x) => r + x);
        return s;
    }

    class CustomComparer : IComparer<int>
    {
        public int Compare(int v1, int v2)
        {
            var d1 = v1 == 0 ? 1 : (int)Math.Log(v1, 10) + 1;
            var d2 = v2 == 0 ? 1 : (int)Math.Log(v2, 10) + 1;
            if (d1 == d2)
            {
                return v1.CompareTo(v2);
            }

            var a1 = (int)Math.Pow(10, d2) * v1 + v2;
            var a2 = (int)Math.Pow(10, d1) * v2 + v1;
            
            return a1.CompareTo(a2);
        }
    }
}

[TestFixture]
public class LargestNumberClassTests
{
    private LargestNumberClass _task = null!;

    [SetUp]
    public void SetUp() => _task = new LargestNumberClass();

    [Test]
    public void LargestNumber_BasicCase_ReturnsLargest()
    {
        ClassicAssert.AreEqual("210", _task.LargestNumber([10, 2]));
    }

    [Test]
    public void LargestNumber_MultipleDigits_ReturnsCorrect()
    {
        ClassicAssert.AreEqual("9534330", _task.LargestNumber([3, 30, 34, 5, 9]));
    }

    [Test]
    public void LargestNumber_AllZeros_ReturnsZero()
    {
        ClassicAssert.AreEqual("0", _task.LargestNumber([0, 0]));
    }

    [Test]
    public void LargestNumber_SingleElement_ReturnsElement()
    {
        ClassicAssert.AreEqual("1", _task.LargestNumber([1]));
    }

    [Test]
    public void LargestNumber_SameDigits_ReturnsCorrect()
    {
        ClassicAssert.AreEqual("111", _task.LargestNumber([1, 1, 1]));
    }
}
