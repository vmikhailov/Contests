namespace CodeForcesSimple.LeetCode;

public class StrToNum
{
	public static int Convert(string s) {
		var i = 0;
		while(s.Length > i && s[i] == ' ') i++;
		if(s.Length <= i) return 0;
		var negative = s[i] == '-' || s[i] == '+' ? s[i++] == '-' : false;
        
		var c = 0;
		var d = 0L;
		while(s.Length > i && char.IsDigit(s[i])) 
		{
			d = d * 10L + s[i]-'0';
			c++;
			i++;
		}
        
		if(d > int.MaxValue || c > 12) return negative ? int.MinValue : int.MaxValue;
        
		return (int)(negative ? -d : d);
	}
}