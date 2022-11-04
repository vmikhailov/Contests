using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Codewars.Codewars.Passed;

public class SumOfSquares
{
	private static IDictionary<int, int> Cache = new Dictionary<int, int>();
	public static int Hits = 0;
	public static int Calls = 0;
	public static int NSquaresFor(int n)
	{
		var nSquares = (int)Math.Sqrt(n);
		var qq = new int[nSquares];

		for (var i = 1; i <= nSquares; i++)
		{
			qq[i - 1] = i * i;
		}

		Calls = 0;
		return Find(n, n, qq);
	}
	
	private static int Find(int k, int n, int[] squares)
	{
		Calls++;
		var q = squares[^1];
		if (q == n) return 1;

		for (var i = squares.Length - 1; i >= 0; i--)
		{
			var m = n - squares[i];
			var p = Array.BinarySearch(squares, m);
			if (p >= 0) return 2;
		}

		k = Math.Min(Math.Min(n - q + 1, k), 4);
		
		for (var i = 3; i <= k; i++)
		{
			for (var j = squares.Length - 1; j >= 0; j--)
			{
				var m = n - squares[j];
				if (m == 0) return 1;
				if (i == 1) break;
				
				var p = Array.BinarySearch(squares, m);
				var qq = p < 0 ? squares[..~p] : squares[..(p + 1)];
				var r = qq[^1] == m ? 1 : qq.Length <= 1 ? 0 : Find(i - 1, m, qq);

				if (r > 0) return r + 1;
			}
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
		TestContext.WriteLine(SumOfSquares.Hits);
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
	[TestCase(2103434344)]
	public void Test2(int n)
	{
		var k = SumOfSquares.NSquaresFor(n);
		TestContext.WriteLine($"{n} {k} {SumOfSquares.Calls}");
	}
}