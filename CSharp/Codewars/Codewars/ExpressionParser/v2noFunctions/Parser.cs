using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Codewars.Codewars.ExpressionParser.v2noFunctions
{
    public class Parser
    {
        private readonly Tokenizer _tokenizer;
        private IEnumerator<Token> _tokens;
        private delegate bool ParserLevelHandler(out Expression expression);

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

        private bool ParseBinary(
            out Expression expression,
            Dictionary<string, Func<Expression, Expression, Expression>> map,
            ParserLevelHandler next,
            bool reverse)
        {
            expression = null;
            if (map == null)
            {
                return next(out expression);
            }

            var operands = new List<Expression>();
            var operations = new List<string>();

            if (!next(out var operand)) return false;
            operands.Add(operand);
            var count = 0;
            while (CheckToken(TokenType.Operator, map.Keys, out var operation))
            {
                if (!NextToken()) return false;

                if (!next(out operand)) return false;
                operands.Add(operand);
                operations.Add(operation);
                count++;
            }

            if (!reverse)
            {
                expression = operands[0];
                for (var i = 0; i < count; i++)
                {
                    expression = map[operations[i]](expression, operands[i + 1]);
                }
            }
            else
            {
                expression = operands[count];
                for (var i = count - 1; i >= 0; i--)
                {
                    expression = map[operations[i]](operands[i], expression);
                }
            }

            return true;
        }

        private bool ParseExpression(out Expression expression)
        {
            return ParseBinary(
                out expression,
                new Dictionary<string, Func<Expression, Expression, Expression>>()
                {
                    { "+", Expression.Add },
                    { "-", Expression.Subtract }
                },
                ParseTerm,
                false);
        }

        private bool ParseTerm(out Expression expression)
        {
            return ParseBinary(
                out expression,
                new Dictionary<string, Func<Expression, Expression, Expression>>()
                {
                    { "*", Expression.Multiply },
                    { "/", Expression.Divide }
                },
                ParseFactor,
                false);
        }

        private bool ParseFactor(out Expression expression)
        {
            return ParseBinary(
                out expression,
                new Dictionary<string, Func<Expression, Expression, Expression>>()
                {
                    { "^", Expression.Power },
                },
                ParsePrimary,
                true);
        }

        private bool ParsePrimary(out Expression expression)
        {
            expression = null;
            switch (CurrentToken.Type)
            {
                case TokenType.Operator when CurrentToken.Value == "-":
                    if (NextToken() && ParseFactor(out expression))
                    {
                        expression = Expression.Negate(expression);

                        return true;
                    }

                    return false;
                case TokenType.Number:
                    if (!ParseNumber(out var value)) return false;
                    expression = Expression.Constant(value);

                    return true;

                case TokenType.OpenParenthesis:

                    return ParseExpressionInParenthesis(out expression);

                default:
                    return false;
            }
        }

        private bool ParseExpressionInParenthesis(out Expression expression)
        {
            expression = null;

            return CheckToken(TokenType.OpenParenthesis) &&
                   NextToken() &&
                   ParseExpression(out expression) &&
                   CheckToken(TokenType.CloseParenthesis) &&
                   NextToken();
        }

        private bool ParseUnary(out Expression expression)
        {
            expression = null;
            switch (CurrentToken.Type)
            {
                case TokenType.Number:
                    if (!ParseNumber(out var value)) return false;
                    expression = Expression.Constant(-value);

                    return true;

                case TokenType.OpenParenthesis:
                    if (ParseExpressionInParenthesis(out expression))
                    {
                        expression = Expression.Negate(expression);

                        return true;
                    }

                    return false;
            }

            return false;
        }

        private bool ParseNumber(out double value)
        {
            value = default;

            if (!CheckToken(TokenType.Number)) return false;

            value = double.Parse(CurrentToken.Value);

            if (!NextToken()) return false;
            var expSign = 1;
            var exp = 0.0;
            if (CheckToken(TokenType.Identifier, "e", "E"))
            {
                //scientific form
                if (!NextToken()) return false;
                switch (CurrentToken.Type)
                {
                    case TokenType.Operator when CurrentToken.Value == "-":
                        if (!NextToken()) return false;
                        if (!ParseNumber(out exp)) return false;
                        expSign = -1;

                        break;
                    case TokenType.Operator when CurrentToken.Value == "+":
                        if (!NextToken()) return false;
                        if (!ParseNumber(out exp)) return false;
                        expSign = 1;

                        break;
                    case TokenType.Number:
                        if (!ParseNumber(out exp)) return false;

                        break;
                }

                value *= Math.Pow(10, expSign * exp);
            }

            return true;
        }


        private bool NextToken() => _tokens.MoveNext();
        private Token CurrentToken => _tokens.Current ?? throw new Exception("Unexpected end of expression");

        private bool CheckToken(TokenType type, params string[] values)
        {
            return CheckToken(type, (IEnumerable<string>)values);
        }

        private bool CheckToken(TokenType type, IEnumerable<string> values, out string value)
        {
            if (CheckToken(type, values))
            {
                value = CurrentToken.Value;

                return true;
            }
            else
            {
                value = null;

                return false;
            }
        }

        private bool CheckToken(TokenType type, IEnumerable<string> values = null)
        {
            return CurrentToken.Type == type && (values == null || values.Contains(CurrentToken.Value));
        }
    }
}