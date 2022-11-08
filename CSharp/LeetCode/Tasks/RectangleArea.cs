namespace LeetCode.Tasks;

public class RectangleArea
{
	public int ComputeArea(int ax1, int ay1, int ax2, int ay2, int bx1, int by1, int bx2, int by2) 
	{
		var cx = new[]{ax1,ax2,bx1,bx2};
		var cy = new[]{ay1,ay2,by1,by2};
		var xx = cx.OrderBy(_ => _).ToArray();
		var yy = cy.OrderBy(_ => _).ToArray();
		        
		var field = new int[]?[yy.Length];
		var s = 0;
        
		for (var i = 0; i < 4; i +=2)
		{
			var x1 = Array.BinarySearch(xx, cx[i]);
			var x2 = Array.BinarySearch(xx, cx[i+1]);
            
			var y1 = Array.BinarySearch(yy, cy[i]);
			var y2 = Array.BinarySearch(yy, cy[i+1]);
			
			for (var y = y1; y < y2; y++)
			{
				for (var x = x1; x < x2; x++)
				{
					var row = field[y];
					if (row == null) field[y] = row = new int[xx.Length];
					if(row[x] == 0)
					{
						s += (xx[x + 1] - xx[x]) * (yy[y + 1] - yy[y]);
					}

					row[x]++;
				}
			}
		}
        
		return s;
	}
}