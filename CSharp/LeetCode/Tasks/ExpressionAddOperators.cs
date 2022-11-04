using System.Text;

namespace LeetCode.Tasks;

public class ExpressionAddOperators
{
	private string _ops = "+-*=";
	
	public int Computed { get; private set; } 
	
	public IList<string> AddOperators(string num, int target) 
	{
		var result = new List<string>();
		var current = new Stack<long>();
		GetDigitsPermutation(0, num.Length - 1);

		void GetDigitsPermutation(int start, int end)
		{
			for (var i = start; i <= end; i++)
			{
				var s = num[start..(i + 1)];
				if(s[0] == '0' && s.Length > 1) continue;
				var v = long.Parse(s);
				current.Push(v);
				GetOpPermutation(i + 1, end);
				current.Pop();
			}
		}

		void GetOpPermutation(int start, int end)
		{
			if (start > end)
			{
				var reversed = current.Reverse().ToList();
				if(Compute(reversed) == target) result.Add(GetExpression(reversed));
				return;
			}
			
			for (var i = 0; i < 3; i++)
			{
				current.Push(i);
				GetDigitsPermutation(start, end);
				current.Pop();
			}
		}

		long Compute(IEnumerable<long> parts)
		{
			Computed++;
			var en = parts.GetEnumerator();
			var r = new Queue<long>();
			
			if (!en.MoveNext()) return 0;
			
			var a = en.Current;
			while (en.MoveNext())
			{
				var op = en.Current;
				en.MoveNext();
				var b = en.Current;
				if (op == 2)
				{
					a *= b;
				}
				else
				{
					r.Enqueue(a);
					r.Enqueue(op);
					a = b;
				}
			}
			r.Enqueue(a);

			en = r.GetEnumerator();
			en.MoveNext();
			a = en.Current;
			while (en.MoveNext())
			{
				var op = en.Current;
				en.MoveNext();
				var b = en.Current;
				a += op == 0 ? b : -b;
			}

			return a;
		}
		
		string GetExpression(IList<long> parts)
		{
			var sb = new StringBuilder();
			var i = 0;
			while (i < parts.Count - 1)
			{
				sb.Append(parts[i++]);
				sb.Append(_ops[(int)parts[i++]]);
			}
			sb.Append(parts[i++]);

			return sb.ToString();
		}

		return result;
	}
}