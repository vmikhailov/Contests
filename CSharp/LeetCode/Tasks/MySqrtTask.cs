using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.Tasks;

public class MySqrtTask
{
	public int MySqrt(int x)
	{
		var q = (int)Math.Round(Math.Exp(Math.Log(x)/2), 0);
		while(true)
		{
			var qq = q * q;
			if(qq >= 0 && qq < x)
			{
				break;
			}

			q--;
		} 
		return q;
	}
}

[TestFixture]
public class MySqrtTaskTests
{
	private MySqrtTask _task = null!;

	[SetUp]
	public void SetUp() => _task = new MySqrtTask();

	[Test]
	public void MySqrt_PerfectSquare_ReturnsCorrect()
	{
		_task.MySqrt(4).Should().Be(2);
		_task.MySqrt(9).Should().Be(3);
		_task.MySqrt(16).Should().Be(4);
	}

	[Test]
	public void MySqrt_NonPerfectSquare_ReturnsFloor()
	{
		_task.MySqrt(8).Should().Be(2);
		_task.MySqrt(20).Should().Be(4);
	}

	[Test]
	public void MySqrt_Zero_ReturnsZero()
	{
		_task.MySqrt(0).Should().Be(0);
	}

	[Test]
	public void MySqrt_One_ReturnsOne()
	{
		_task.MySqrt(1).Should().Be(1);
	}

	[Test]
	public void MySqrt_LargeNumber_ReturnsCorrect()
	{
		_task.MySqrt(2147395600).Should().Be(46340);
	}
}
