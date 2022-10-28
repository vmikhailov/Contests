using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Codewars.Codewars.ExpressionParser.v1
{
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
               
                expression = op == "+" ? 
                    Expression.Add(expression, operand) : 
                    Expression.Subtract(expression, operand);
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
               
                expression = op == "*" ? 
                    Expression.Multiply(expression, operand) : 
                    Expression.Divide(expression, operand);
            }
            
            return true;
        }

        private bool ParseFactor(out Expression expression)
        {
            expression = null;
            switch (CurrentToken.Type)
            {
                case TokenType.Operator when CurrentToken.Value == "-":
                    if(NextToken() && ParseFactor(out expression))
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

            expression = Expression.Constant(double.Parse(CurrentToken.Value));
            return NextToken();
        }


        private bool NextToken() => _tokens.MoveNext();
        private Token CurrentToken => _tokens.Current ?? throw new Exception("Unexpected end of expression");

        private bool CheckToken(TokenType type, params string[] values)
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
}