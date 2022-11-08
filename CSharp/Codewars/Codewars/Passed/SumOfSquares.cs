using System;
using NUnit.Framework;

namespace Codewars.Codewars.Passed;

public class SumOfSquares
{
	public static int NSquaresFor(int n)
	{
		var q = (int)Math.Sqrt(n);
		if (q * q == n) return 1;

		for (var i = q; i >= 1; i--)
		{
			var m = n - i * i;
			var qq = (int)Math.Sqrt(m);
			if (qq * qq == m) return 2;
		}

		//4^a(8b+7)
		var f = n;
		while (f % 4 == 0) f /= 4;

		f -= 7;
		return f % 8 == 0 ? 4 : 3;
	}
}

[TestFixture]
public class SumOfSquaresTest
{
	[Test]
	[TestCase(17, 2)]
	[TestCase(153, 2)]
	[TestCase(16, 1)]
	[TestCase(15, 4)]
	[TestCase(19, 3)]
	[TestCase(17000, 2)]
	[TestCase(17001, 2)]
	[TestCase(17005, 3)]
	public void Test1(int n, int k)
	{
		Assert.AreEqual(k, SumOfSquares.NSquaresFor(n));
	}

	[Test]
	[TestCase(1703434344)]
	[TestCase(1703434351)]
	[TestCase(1703434352)]
	public void Test2(int n)
	{
		var k = SumOfSquares.NSquaresFor(n);
		TestContext.WriteLine($"{n} {k}");
	}


	[Test]
	[TestCase(100000000, 10000)]
	public void Test3(int n, int k)
	{
		for (var i = n; i < n + k; i++)
		{
			SumOfSquares.NSquaresFor(i);
		}
	}
}