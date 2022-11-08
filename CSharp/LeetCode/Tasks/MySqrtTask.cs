namespace LeetCode.Tasks;

public class MySqrtTask
{
	public int MySqrt(int x)
	{
		var q = (int)Math.Round(Math.Exp(Math.Log(x)/2), 0);
		while(true)
		{
			var qq = q * q;
			if(qq >= 0 && qq < x) break;
			q--;
		} 
		return q;
	}
}