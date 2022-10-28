namespace LeetCode
{
	public class DivideNumbers
	{
		public static int Compute(int dividend, int divisor)
		{
			var sa = dividend >= 0 ? 1 : -1;
			var sb = divisor > 0 ? 1 : -1;
			
			if(dividend == int.MinValue && divisor== -1) return int.MaxValue;
			if(dividend == 0) return 0;
        
			var d = (long)dividend * sa;
			var v = (long)divisor * sb;

			var r = 0;
			while (v >> 1 << 1 == v)
			{
				d = d >> 1;
				v = v >> 1;
			}
			
			if(v == 1) return (int)(d*sa*sb);
			
			while(d >= v)
			{
				d -= v;
				r++;
			}
        
			return r*sa*sb;
		}
	}
}