using System.Text;

namespace LeetCode.Tasks2025;

public class BasicCalculatorTask
{
    /* Given a string s representing a valid expression, implement a basic calculator to evaluate it, and return
       the result of the evaluation.

       Note: You are not allowed to use any built-in function which evaluates strings as mathematical
       expressions, such as eval().
    */

    public int Calculate(string s)
    {
        var t = new Tokenizer(s);
        var p = new Parser(t);
        return p.Calculate();
    }

    public class Token
    {
        public TokenType Type { get; init; }

        public string Value { get; init; }
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

    private class Parser
    {
        private readonly Tokenizer _tokenizer;
        private IEnumerator<Token> _tokens;

        public Parser(Tokenizer tokenizer)
        {
            _tokenizer = tokenizer;
        }

        public int Calculate()
        {
            _tokens = _tokenizer.GetTokens().GetEnumerator();

            if(NextToken() && CalculateExpression(out var result) && CheckToken(TokenType.End))
            {
                return result;
            }

            return -1;
        }

        private bool CalculateExpression(out int result)
        {
            if (!CalculateTerm(out result)) return false;

            while (CheckToken(TokenType.Operator, "+", "-"))
            {
                var op = CurrentToken.Value;
                if (!NextToken()) return false;

                if (!CalculateTerm(out var operand)) return false;

                result = op == "+" ? result + operand : result - operand;
            }

            return true;
        }

        private bool CalculateTerm(out int result)
        {
            if (!CalculateFactor(out result)) return false;

            while (CheckToken(TokenType.Operator, "*", "/"))
            {
                var op = CurrentToken.Value;
                if (!NextToken()) return false;

                if (!CalculateFactor(out var operand)) return false;

                result = op == "*"
                    ? result * operand
                    : result / operand;
            }

            return true;
        }

        private bool CalculateFactor(out int result)
        {
            result = 0;

            switch (CurrentToken.Type)
            {
                case TokenType.Operator when CurrentToken.Value == "-":
                    if (NextToken() && CalculateFactor(out result))
                    {
                        result = -result;
                        return true;
                    }

                    return false;

                case TokenType.Number:
                    return ParseNumber(out result);

                case TokenType.OpenParenthesis:

                    return NextToken() &&
                           CalculateExpression(out result) &&
                           CheckToken(TokenType.CloseParenthesis) &&
                           NextToken();

                default:
                    return false;
            }
        }

        private bool ParseNumber(out int result)
        {
            result = 0;
            if (!CheckToken(TokenType.Number)) return false;

            result = int.Parse(CurrentToken.Value);
            return NextToken();
        }

        private bool NextToken() => _tokens.MoveNext();

        private Token CurrentToken => _tokens.Current ?? throw new("Unexpected end of expression");

        private bool CheckToken(TokenType type, params string[]? values)
        {
            return CurrentToken.Type == type &&
                   (values == null || values.Length == 0 || values.Contains(CurrentToken.Value));
        }

        private void ThrowInvalidExpression()
        {
            throw new("Invalid expression");
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

                    if (c == '.' && !dotPassed)
                    {
                        dotPassed = true;
                        sb.Append(c);
                        continue;
                    }

                    yield return new() { Type = TokenType.Number, Value = sb.ToString() };

                    numberParsing = false;
                    dotPassed = false;
                    sb.Clear();
                }

                if (char.IsWhiteSpace(c)) continue;

                var t = c switch
                {
                    '(' => TokenType.OpenParenthesis,
                    ')' => TokenType.CloseParenthesis,
                    '+' or '-' or '*' or '/' or '^' => TokenType.Operator,
                    _ => TokenType.Unknown
                };

                if (t != TokenType.Unknown)
                {
                    yield return new() { Type = t, Value = new(c, 1) };
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
                        yield return new() { Type = t, Value = new(c, 1) };
                    }
                }
            }

            if (numberParsing)
            {
                yield return new() { Type = TokenType.Number, Value = sb.ToString() };
            }

            yield return new() { Type = TokenType.End };
        }
    }
}
