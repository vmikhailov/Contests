using System.Collections.Generic;
using System.Text;

namespace Codewars.Codewars.ExpressionParser.v2polish
{
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
            var identifierParsing = false;
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

                if (identifierParsing)
                {
                    if (char.IsLetter(c))
                    {
                        sb.Append(c);

                        continue;
                    }
                    else
                    {
                        yield return new Token() { Type = TokenType.Identifier, Value = sb.ToString() };
                        identifierParsing = false;
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
                    else if (char.IsLetter(c))
                    {
                        identifierParsing = true;
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