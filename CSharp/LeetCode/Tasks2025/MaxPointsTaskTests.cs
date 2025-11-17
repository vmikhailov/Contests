using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.Tasks2025;

[TestFixture]
public class MaxPointsTaskTests
{
	private MaxPointsTask _task = null!;

	[SetUp]
	public void SetUp() => _task = new MaxPointsTask();

	[Test]
	public void MaxPoints_ThreePointsOnSameLine_Returns3()
	{
		var points = new[] { new[] { 1, 1 }, new[] { 2, 2 }, new[] { 3, 3 } };
		_task.MaxPoints(points).Should().Be(3);
	}

	[Test]
	public void MaxPoints_FourPointsWithThreeOnLine_Returns3()
	{
		var points = new[]
		{
			new[] { 1, 1 },
			new[] { 3, 2 },
			new[] { 5, 3 },
			new[] { 4, 1 },
			new[] { 2, 3 },
			new[] { 1, 4 }
		};
		_task.MaxPoints(points).Should().Be(4);
	}

	[Test]
	public void MaxPoints_SinglePoint_Returns1()
	{
		var points = new[] { new[] { 1, 1 } };
		_task.MaxPoints(points).Should().Be(1);
	}

	[Test]
	public void MaxPoints_TwoPoints_Returns2()
	{
		var points = new[] { new[] { 1, 1 }, new[] { 2, 2 } };
		_task.MaxPoints(points).Should().Be(2);
	}

	[Test]
	public void MaxPoints_VerticalLine_ReturnsCorrectCount()
	{
		var points = new[]
		{
			new[] { 1, 1 },
			new[] { 1, 2 },
			new[] { 1, 3 },
			new[] { 2, 1 }
		};
		_task.MaxPoints(points).Should().Be(3);
	}

	[Test]
	public void MaxPoints_HorizontalLine_ReturnsCorrectCount()
	{
		var points = new[]
		{
			new[] { 1, 1 },
			new[] { 2, 1 },
			new[] { 3, 1 },
			new[] { 1, 2 }
		};
		_task.MaxPoints(points).Should().Be(3);
	}

	[Test]
	public void MaxPoints_AllPointsOnSameLine_ReturnsAllPoints()
	{
		var points = new[]
		{
			new[] { 0, 0 },
			new[] { 1, 1 },
			new[] { 2, 2 },
			new[] { 3, 3 },
			new[] { 4, 4 }
		};
		_task.MaxPoints(points).Should().Be(5);
	}

	[Test]
	public void MaxPoints_NoPointsOnSameLine_Returns2()
	{
		var points = new[]
		{
			new[] { 0, 0 },
			new[] { 1, 2 },
			new[] { 2, 1 }
		};
		_task.MaxPoints(points).Should().Be(2);
	}

	[Test]
	public void MaxPoints_DuplicatePoints_HandlesCorrectly()
	{
		var points = new[]
		{
			new[] { 1, 1 },
			new[] { 1, 1 },
			new[] { 2, 2 }
		};
		_task.MaxPoints(points).Should().Be(3);
	}

	[Test]
	public void MaxPoints_NegativeCoordinates_ReturnsCorrectCount()
	{
		var points = new[]
		{
			new[] { -1, -1 },
			new[] { 0, 0 },
			new[] { 1, 1 },
			new[] { 2, 3 }
		};
		_task.MaxPoints(points).Should().Be(3);
	}

	[Test]
	public void MaxPoints_LargeCoordinates_HandlesOverflow()
	{
		var points = new[]
		{
			new[] { 0, 0 },
			new[] { 94911151, 94911150 },
			new[] { 94911152, 94911151 }
		};
		_task.MaxPoints(points).Should().Be(2);
	}

	[Test]
	public void MaxPoints_SteepSlope_ReturnsCorrectCount()
	{
		var points = new[]
		{
			new[] { 0, 0 },
			new[] { 1, 10 },
			new[] { 2, 20 },
			new[] { 3, 30 }
		};
		_task.MaxPoints(points).Should().Be(4);
	}

	[Test]
	public void MaxPoints_MultipleLines_ReturnsMaxCount()
	{
		var points = new[]
		{
			new[] { 0, 0 },
			new[] { 1, 1 },
			new[] { 0, 1 },
			new[] { 1, 0 },
			new[] { 2, 2 }
		};
		_task.MaxPoints(points).Should().Be(3); // (0,0), (1,1), (2,2)
	}
}

