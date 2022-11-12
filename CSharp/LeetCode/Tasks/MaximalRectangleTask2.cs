namespace LeetCode.Tasks;

public class MaximalRectangleTask2
{
	public int MaximalRectangle(char[][] matrix)
	{
		var sy = matrix.Length;
		var sx = matrix[0].Length;
		var h = new int[sx + 1];
		h[sx] = 0;
		var max = 0;

		for (var y = 0; y < sy; y++)
		{
			var s = new Stack<int>();
			for (var x = 0; x < sx + 1; x++)
			{
				if (x < sx) h[x] = matrix[y][x] == '1' ? h[x] + 1 : 0;

				while (s.Count > 0 && h[x] < h[s.Peek()])
				{
					var area = h[s.Pop()] * (s.Count == 0 ? x : x - s.Peek() - 1);
					max = Math.Max(max, area);
				}
				
				s.Push(x);
			}
		}

		return max;
	}
}