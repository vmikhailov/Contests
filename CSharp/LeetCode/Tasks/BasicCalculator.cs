using System.Linq.Expressions;
using System.Text;

namespace LeetCode.Tasks;

public class BasicCalculator
{
	public int Calculate(string s)
	{
		var t = new Tokenizer(s);
		var p = new Parser(t);
		if (p.Parse(out var exp))
		{
			var lambda = Expression.Lambda<Func<int>>(exp);
			var func = lambda.Compile();
			return func();
		}

		return 0;
	}

	public class Token
	{
		public TokenType Type { get; set; }

		public string Value { get; set; }
	}

	public enum TokenType
	{
		End,
		Operator,
		OpenParenthesis,
		CloseParenthesis,
		Number,
		Unknown
	}

	public class Parser
	{
		private readonly Tokenizer _tokenizer;
		private IEnumerator<Token> _tokens;

		public Parser(Tokenizer tokenizer)
		{
			_tokenizer = tokenizer;
		}

		public bool Parse(out Expression expression)
		{
			_tokens = _tokenizer.GetTokens().GetEnumerator();
			expression = null;
			return NextToken() && ParseExpression(out expression) && CheckToken(TokenType.End);
		}

		private bool ParseExpression(out Expression expression)
		{
			if (!ParseTerm(out expression)) return false;

			while (CheckToken(TokenType.Operator, "+", "-"))
			{
				var op = CurrentToken.Value;
				if (!NextToken()) return false;

				if (!ParseTerm(out var operand)) return false;

				expression = op == "+" ? Expression.Add(expression, operand) : Expression.Subtract(expression, operand);
			}

			return true;
		}

		private bool ParseTerm(out Expression expression)
		{
			if (!ParseFactor(out expression)) return false;

			while (CheckToken(TokenType.Operator, "*", "/"))
			{
				var op = CurrentToken.Value;
				if (!NextToken()) return false;

				if (!ParseFactor(out var operand)) return false;

				expression = op == "*" ? Expression.Multiply(expression, operand) : Expression.Divide(expression, operand);
			}

			return true;
		}

		private bool ParseFactor(out Expression expression)
		{
			expression = null;
			switch (CurrentToken.Type)
			{
				case TokenType.Operator when CurrentToken.Value == "-":
					if (NextToken() && ParseFactor(out expression))
					{
						expression = Expression.Negate(expression);
					}

					return expression != null;

				case TokenType.Number:
					return ParseNumber(out expression);

				case TokenType.OpenParenthesis:

					return NextToken() &&
					       ParseExpression(out expression) &&
					       CheckToken(TokenType.CloseParenthesis) &&
					       NextToken();

				default:
					return false;
			}
		}

		private bool ParseNumber(out Expression expression)
		{
			expression = null;
			if (!CheckToken(TokenType.Number)) return false;

			expression = Expression.Constant(int.Parse(CurrentToken.Value));
			return NextToken();
		}


		private bool NextToken() => _tokens.MoveNext();

		private Token CurrentToken => _tokens.Current ?? throw new Exception("Unexpected end of expression");

		private bool CheckToken(TokenType type, params string[]? values)
		{
			return CurrentToken.Type == type && (values == null || values.Length == 0 || values.Contains(CurrentToken.Value));
		}

		private void EnsureToken(TokenType type, params string[] values)
		{
			if (!CheckToken(type, values))
			{
				ThrowInvalidExpression();
			}
		}

		private void ThrowInvalidExpression()
		{
			throw new Exception("Invalid expression");
		}
	}

	public class Tokenizer
	{
		private string _expression;

		public Tokenizer(string expression)
		{
			_expression = expression;
		}

		public IEnumerable<Token> GetTokens()
		{
			var numberParsing = false;
			var dotPassed = false;
			var sb = new StringBuilder();
			foreach (var c in _expression)
			{
				if (numberParsing)
				{
					if (char.IsDigit(c))
					{
						sb.Append(c);
						continue;
					}
					else if (c == '.' && !dotPassed)
					{
						dotPassed = true;
						sb.Append(c);
						continue;
					}
					else
					{
						yield return new Token() { Type = TokenType.Number, Value = sb.ToString() };
						numberParsing = false;
						dotPassed = false;
						sb.Clear();
					}
				}

				if (char.IsWhiteSpace(c)) continue;
				var t = c switch
				{
					'(' => TokenType.OpenParenthesis,
					')' => TokenType.CloseParenthesis,
					'+' => TokenType.Operator,
					'-' => TokenType.Operator,
					'*' => TokenType.Operator,
					'/' => TokenType.Operator,
					'^' => TokenType.Operator,
					_ => TokenType.Unknown
				};

				if (t != TokenType.Unknown)
				{
					yield return new Token() { Type = t, Value = new string(c, 1) };
				}
				else
				{
					if (char.IsDigit(c))
					{
						numberParsing = true;
						sb.Append(c);
					}
					else
					{
						yield return new Token() { Type = t, Value = new string(c, 1) };
					}
				}
			}

			if (numberParsing)
			{
				yield return new Token() { Type = TokenType.Number, Value = sb.ToString() };
			}

			yield return new Token() { Type = TokenType.End };
		}
	}
}