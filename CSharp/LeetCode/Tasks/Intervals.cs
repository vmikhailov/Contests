using NUnit.Framework.Legacy;
using NUnit.Framework;

namespace LeetCode.Tasks;

public class Intervals
{
    public int[][] Merge(int[][] intervals)
    {
        var r = new List<int>();
        var m = new List<int>();

        foreach (var interval in intervals)
        {
            var indexes = new int[2];
            for (var i = 0; i < 2; i++)
            {
                var p = r.BinarySearch(interval[i]);
                if (p < 0)
                {
                    p = -p - 1;
                    r.Insert(p, interval[i]);
                    if(p > 0)
                    {
                        m.Insert(p, m[p - 1]);
                    }
                    else
                    {
                        m.Insert(p, 0);
                    }
                }

                indexes[i] = p;
            }

            for (var i = indexes[0]; i < indexes[1]; i++)
            {
                m[i] = 1;
            }
        }

        var v = new List<int[]>();
        var j = 0;
        while (j < m.Count)
        {
            var i = j;         
            while (m[j] == 1) j++;
            v.Add(new[] { r[i], r[j] });
            j++;
        }

        return v.ToArray();
    }
}

[TestFixture]
public class IntervalsTests
{
    private Intervals _task = null!;

    [SetUp]
    public void SetUp() => _task = new Intervals();

    [Test]
    public void Merge_OverlappingIntervals_MergesThem()
    {
        var result = _task.Merge([[1, 3], [2, 6], [8, 10], [15, 18]]);
        ClassicAssert.AreEqual(3, result.Length);
        CollectionClassicAssert.AreEqual(new[] { 1, 6 }, result[0]);
        CollectionClassicAssert.AreEqual(new[] { 8, 10 }, result[1]);
        CollectionClassicAssert.AreEqual(new[] { 15, 18 }, result[2]);
    }

    [Test]
    public void Merge_AdjacentIntervals_MergesThem()
    {
        var result = _task.Merge([[1, 4], [4, 5]]);
        ClassicAssert.AreEqual(1, result.Length);
        CollectionClassicAssert.AreEqual(new[] { 1, 5 }, result[0]);
    }

    [Test]
    public void Merge_NonOverlapping_KeepsSeparate()
    {
        var result = _task.Merge([[1, 2], [3, 4]]);
        ClassicAssert.AreEqual(2, result.Length);
    }

    [Test]
    public void Merge_SingleInterval_ReturnsSame()
    {
        var result = _task.Merge([[1, 5]]);
        ClassicAssert.AreEqual(1, result.Length);
        CollectionClassicAssert.AreEqual(new[] { 1, 5 }, result[0]);
    }
}
