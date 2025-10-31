using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.Tasks;

public class SpiralMatrixTask
{
	public IList<int> SpiralOrder(int[][] matrix)
	{
		return GetSpiral(matrix[0].Length, matrix.Length).Select(p => matrix[p.y][p.x]).ToList();
	}

	IEnumerable<(int x, int y)> GetSpiral(int n, int m)
	{
		if (n <= 0 || m <= 0)
		{
			yield break;
		}

		var x = 0;
		var y = 0;
		while (x < n) yield return (x++, y);
		x--;
		y++;
		while (y < m) yield return (x, y++);
		y--;
		x--;
		while (m > 1 && x >= 0) yield return (x--, y);
		x++;
		y--;
		while (n > 1 && y >= 1) yield return (x, y--);

		foreach (var p in GetSpiral(n - 2, m - 2))
		{
			yield return (p.x + 1, p.y + 1);
		}
	}
}

[TestFixture]
public class SpiralMatrixTaskTests
{
	private SpiralMatrixTask _task = null!;

	[SetUp]
	public void SetUp() => _task = new SpiralMatrixTask();

	[Test]
	public void SpiralOrder_3x3Matrix_ReturnsCorrect()
	{
		int[][] matrix = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];
		var expected = new List<int> { 1, 2, 3, 6, 9, 8, 7, 4, 5 };
		_task.SpiralOrder(matrix).Should().Equal(expected);
	}

	[Test]
	public void SpiralOrder_3x4Matrix_ReturnsCorrect()
	{
		int[][] matrix = [[1, 2, 3, 4], [5, 6, 7, 8], [9, 10, 11, 12]];
		var expected = new List<int> { 1, 2, 3, 4, 8, 12, 11, 10, 9, 5, 6, 7 };
		_task.SpiralOrder(matrix).Should().Equal(expected);
	}

	[Test]
	public void SpiralOrder_1x1Matrix_ReturnsSingleElement()
	{
		int[][] matrix = [[1]];
		var expected = new List<int> { 1 };
		_task.SpiralOrder(matrix).Should().Equal(expected);
	}

	[Test]
	public void SpiralOrder_SingleRowMatrix_ReturnsCorrect()
	{
		int[][] matrix = [[1, 2, 3, 4]];
		var expected = new List<int> { 1, 2, 3, 4 };
		_task.SpiralOrder(matrix).Should().Equal(expected);
	}

	[Test]
	public void SpiralOrder_SingleColumnMatrix_ReturnsCorrect()
	{
		int[][] matrix = [[1], [2], [3], [4]];
		var expected = new List<int> { 1, 2, 3, 4 };
		_task.SpiralOrder(matrix).Should().Equal(expected);
	}
}
