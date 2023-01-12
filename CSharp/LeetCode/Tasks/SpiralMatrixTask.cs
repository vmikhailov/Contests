namespace LeetCode.Tasks;

public class SpiralMatrixTask
{
	public IList<int> SpiralOrder(int[][] matrix)
	{
		return GetSpiral(matrix[0].Length, matrix.Length).Select(p => matrix[p.y][p.x]).ToList();
	}

	IEnumerable<(int x, int y)> GetSpiral(int n, int m)
	{
		if (n <= 0 || m <= 0) yield break;
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