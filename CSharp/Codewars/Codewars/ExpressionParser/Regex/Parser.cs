using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.Codewars.ExpressionParser.Regex
{
    public class Parser
    {
        public static Reg.Exp parse(string input)
        {
            var p = new Parser(input);

            return p.Parse();
        }

        private IEnumerator<Token> _tokens;

        public Parser(string input)
        {
            _tokens = GetTokens(input).GetEnumerator();
        }

        public Reg.Exp Parse()
        {
            return NextToken() && ParseExpression(out var exp) && CheckToken(TokenType.End) ? exp : null;
        }

        private bool ParseExpression(out Reg.Exp exp)
        {
            if (!ParseTerm(out exp)) return false;

            while (CheckToken(TokenType.Pipe))
            {
                if (!NextToken()) return false;

                if (!ParseTerm(out var operand)) return false;

                exp = Reg.or(exp, operand);
            }

            return true;
        }

        private bool ParseTerm(out Reg.Exp exp)
        {
            exp = null;
            var list = new List<Reg.Exp>();
            while (ParseFactor(out var factor))
            {
                if (CheckToken(TokenType.Star))
                {
                    factor = Reg.zeroOrMore(factor);
                    if (!NextToken()) return false;
                }
                list.Add(factor);
            }

            if (!list.Any()) return false;
            if (list.Count == 1)
            {
                exp = list[0];
            }
            else
            {
                var add = Reg.str(list[0]);
                for (var i = 1; i < list.Count; i++)
                {
                    add = Reg.add(add, list[i]);
                }

                exp = add;
            }
            
            return true;
        }

        private bool ParseFactor(out Reg.Exp exp)
        {
            exp = null;
            switch (CurrentToken.Type)
            {
                case TokenType.Symbol:
                    exp = Reg.normal(CurrentToken.Value);

                    return NextToken();

                case TokenType.OpenBracket:
                    return (NextToken() &&
                            ParseExpression(out exp) &&
                            CheckToken(TokenType.CloseBracket) &&
                            NextToken());

                case TokenType.Dot:
                    exp = Reg.any();

                    return NextToken();

                default:
                    return false;
            }
        }

      
        private bool CheckToken(TokenType type) => CurrentToken.Type == type;

        private bool NextToken() => _tokens.MoveNext();

        private Token CurrentToken => _tokens.Current ?? throw new Exception("Unexpected end of expression");

        private IEnumerable<Token> GetTokens(string expression)
        {
            foreach (var c in expression)
            {
                var t = c switch
                {
                    '(' => TokenType.OpenBracket,
                    ')' => TokenType.CloseBracket,
                    '.' => TokenType.Dot,
                    '*' => TokenType.Star,
                    '|' => TokenType.Pipe,
                    _ => TokenType.Symbol
                };

                yield return new Token() { Type = t, Value = c };
            }

            yield return new Token() { Type = TokenType.End };
        }
    }
}