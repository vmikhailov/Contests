using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Codewars.Codewars.ExpressionParser.v2polish
{
    public class Parser
    {
        private readonly Tokenizer _tokenizer;
        private readonly Dictionary<string, string> _functions;
        private IEnumerator<Token> _tokens;
        private IList<string> _variables;

        public Parser(Tokenizer tokenizer)
        {
            _tokenizer = tokenizer;
            _functions = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
            {
                { "log", nameof(Math.Log10) },
                { "ln", nameof(Math.Log) },
                { "exp", nameof(Math.Exp) },
                { "sqrt", nameof(Math.Sqrt) },
                { "abs", nameof(Math.Abs) },
                { "atan", nameof(Math.Atan) },
                { "acos", nameof(Math.Acos) },
                { "asin", nameof(Math.Asin) },
                { "sinh", nameof(Math.Sinh) },
                { "cosh", nameof(Math.Cosh) },
                { "tanh", nameof(Math.Tanh) },
                { "tan", nameof(Math.Tan) },
                { "sin", nameof(Math.Sin) },
                { "cos", nameof(Math.Cos) }
            };
        }

        public bool Parse(out Expression expression)
        {
            _variables = new List<string>();
            _tokens = _tokenizer.GetTokens().GetEnumerator();
            expression = null;

            return NextToken() && ParseExpressionInParenthesis(out expression) && CheckToken(TokenType.End);
        }
        
        private bool ParseBinary(out Expression expression, Dictionary<string, Func<Expression, Expression, Expression>> map, ParserLevelHandler next, bool reverse)
        {
            expression = null;
            if (map == null)
            {
                return next(out expression);
            }

            var operands = new List<Expression>();
            var operations = new List<string>();
            var count = 0;

            if (CheckToken(TokenType.Identifier))
            {
                return ParseFunction(out expression);
            }
            
            while (CheckToken(TokenType.Operator, map.Keys, out var operation))
            {
                if (!NextToken()) return false;
                
                if (!next(out var operand)) return false;
                operands.Add(operand);
                
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
                    { "-", Expression.Subtract },
                    { "*", Expression.Multiply },
                    { "/", Expression.Divide },
                    { "^", Expression.Power },
                },
                ParsePrimary,
                false);
        }
        
        private bool ParsePrimary(out Expression expression)
        {
            expression = null;
            switch (CurrentToken.Type)
            {
                case TokenType.Operator when CurrentToken.Value == "-":
                    if (NextToken() && ParsePrimary(out expression))
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

                case TokenType.Identifier:
                    return ParseFunction(out expression);

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

        private bool ParseFunction(out Expression expression)
        {
            expression = null;

            if (!(CheckToken(TokenType.Identifier, null, out var identifier) && NextToken())) return false;
            if (CurrentToken.Type == TokenType.OpenParenthesis)
            {
                if (_functions.ContainsKey(identifier) &&
                    ParseExpressionInParenthesis(out expression))
                {
                    var method = FindMethod(typeof(Math), _functions[identifier]);
                    expression = Expression.Call(null, method, expression);
                    return true;
                }
                return false;
            }
            else
            {
                _variables.Add(identifier);

                return true;
            }
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

            value = double.Parse((string)CurrentToken.Value);

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

        private MethodInfo FindMethod(Type type, string method)
        {
            return type.GetMethods(BindingFlags.Static | BindingFlags.Public)
                       .First(m => m.Name.Equals(method, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}