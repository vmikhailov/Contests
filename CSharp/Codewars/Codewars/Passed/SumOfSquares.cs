using System;
using NUnit.Framework;

namespace Codewars.Codewars.Passed;

public class SumOfSquares
{
	public static int NSquaresFor(int n)
	{
		var nSquares = (int)Math.Sqrt(n);
		var qq = new int[nSquares];

		for (var i = 1; i <= nSquares; i++)
		{
			qq[i - 1] = i * i;
		}
		return Find(n, n, qq);
	}
	
	private static int Find(int k, int n, ReadOnlySpan<int> squares)
	{
		var q = squares[^1];
		if (q == n) return 1;

		for (var i = squares.Length - 1; i >= 0; i--)
		{
			var m = n - squares[i];
			var qq = (int)Math.Sqrt(m);
			if (qq * qq == m) return 2;
		}

		k = Math.Min(Math.Min(n - q + 1, k), 3);
		
		if(k >= 3)
		{
			//4^2(8b+7)
			var a = 0;
			var f = n;
			while (f % 4 == 0)
			{
				a++;
				f /= 4;
			}

			f -= 7;
			return f % 8 == 0 ? 4 : 3; 
		}
		
		return 0;
	}
}

[TestFixture]
public class SumOfSquaresTest
{
	[Test]
	[TestCase(17, 2)]
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
	[TestCase(1703434345)]
	[TestCase(1703434346)]
	[TestCase(1703434347)]
	[TestCase(1703434348)]
	[TestCase(1703434349)]
	[TestCase(1703434350)]
	[TestCase(1703434351)]
	[TestCase(1703434352)]
	[TestCase(2103434344)]
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