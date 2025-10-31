using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.Tasks;

public class MedianFinder
{
	private long _n;
	private List<int> _data = new();

	public void AddNum(int num)
	{
		_n++;

		var p = _data.BinarySearch(num);
		p = p < 0 ? ~p : p;
		_data.Insert(p, num);
	}

	public double FindMedian()
	{
		var c = _data.Count;
		if (c % 2 == 0)
		{
			return (_data[c / 2 - 1] + _data[c / 2]) / 2.0;
		}
		else
		{
			return _data[c / 2];
		}
	}
}

[TestFixture]
public class MedianFinderTests
{
	[Test]
	public void FindMedian_SingleElement_ReturnsElement()
	{
		var mf = new MedianFinder();
		mf.AddNum(1);
		mf.FindMedian().Should().Be(1.0);
	}

	[Test]
	public void FindMedian_TwoElements_ReturnsAverage()
	{
		var mf = new MedianFinder();
		mf.AddNum(1);
		mf.AddNum(2);
		mf.FindMedian().Should().Be(1.5);
	}

	[Test]
	public void FindMedian_OddElements_ReturnsMiddle()
	{
		var mf = new MedianFinder();
		mf.AddNum(1);
		mf.AddNum(2);
		mf.AddNum(3);
		mf.FindMedian().Should().Be(2.0);
	}

	[Test]
	public void FindMedian_UnorderedInsert_ReturnsCorrect()
	{
		var mf = new MedianFinder();
		mf.AddNum(5);
		mf.AddNum(1);
		mf.AddNum(3);
		mf.FindMedian().Should().Be(3.0);
	}

	[Test]
	public void FindMedian_MultipleOperations_WorksCorrectly()
	{
		var mf = new MedianFinder();
		mf.AddNum(1);
		mf.AddNum(2);
		mf.FindMedian().Should().Be(1.5);
		mf.AddNum(3);
		mf.FindMedian().Should().Be(2.0);
	}

	[Test]
	public void FindMedian_IncrementalSequence_MatchesProgramCs()
	{
		var mf = new MedianFinder();
		mf.AddNum(6);
		mf.FindMedian().Should().Be(6.0);
		mf.AddNum(10);
		mf.FindMedian().Should().Be(8.0);
		mf.AddNum(2);
		mf.FindMedian().Should().Be(6.0);
		mf.AddNum(6);
		mf.FindMedian().Should().Be(6.0);
	}
}
