using NUnit.Framework.Legacy;
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
		ClassicAssert.AreEqual(2, _task.MySqrt(4));
		ClassicAssert.AreEqual(3, _task.MySqrt(9));
		ClassicAssert.AreEqual(4, _task.MySqrt(16));
	}

	[Test]
	public void MySqrt_NonPerfectSquare_ReturnsFloor()
	{
		ClassicAssert.AreEqual(2, _task.MySqrt(8));
		ClassicAssert.AreEqual(4, _task.MySqrt(20));
	}

	[Test]
	public void MySqrt_Zero_ReturnsZero()
	{
		ClassicAssert.AreEqual(0, _task.MySqrt(0));
	}

	[Test]
	public void MySqrt_One_ReturnsOne()
	{
		ClassicAssert.AreEqual(1, _task.MySqrt(1));
	}

	[Test]
	public void MySqrt_LargeNumber_ReturnsCorrect()
	{
		ClassicAssert.AreEqual(46340, _task.MySqrt(2147395600));
	}
}
