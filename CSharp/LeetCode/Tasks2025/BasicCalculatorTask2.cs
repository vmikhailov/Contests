
namespace LeetCode.Tasks2025;

public class BasicCalculatorTask2
{
    /* Given a string s representing a valid expression, implement a basic calculator to evaluate it, and return
       the result of the evaluation.

       Note: You are not allowed to use any built-in function which evaluates strings as mathematical
       expressions, such as eval().
    */

    public int Calculate(string s)
    {
        var parser = new Parser(s);
        return parser.Calculate();
    }

    private class Parser
    {
        private readonly string _expression;
        private int _position;

        public Parser(string expression)
        {
            _expression = expression;
            _position = 0;
        }

        public int Calculate()
        {
            SkipWhitespace();
            var result = CalculateExpression();

            if (_position < _expression.Length)
            {
                throw new InvalidOperationException("Unexpected characters at end of expression");
            }

            return result;
        }

        private int CalculateExpression()
        {
            var result = CalculateFactor();

            while (_position < _expression.Length)
            {
                SkipWhitespace();

                if (_position >= _expression.Length || (_expression[_position] != '+' && _expression[_position] != '-'))
                {
                    break;
                }

                var op = _expression[_position];
                _position++;
                SkipWhitespace();

                var operand = CalculateFactor();
                result = op == '+' ? result + operand : result - operand;
            }

            return result;
        }

        private int CalculateFactor()
        {
            SkipWhitespace();

            if (_position >= _expression.Length)
            {
                throw new InvalidOperationException("Unexpected end of expression");
            }

            switch (_expression[_position])
            {
                // Handle unary minus
                case '-':
                    _position++;
                    return -CalculateFactor();

                // Handle parentheses
                case '(':
                {
                    _position++;
                    var result = CalculateExpression();
                    SkipWhitespace();

                    if (_position >= _expression.Length || _expression[_position] != ')')
                    {
                        throw new InvalidOperationException("Missing closing parenthesis");
                    }

                    _position++;
                    return result;
                }
                default:
                    // Parse number
                    return ParseNumber();
            }
        }

        private int ParseNumber()
        {
            SkipWhitespace();

            if (_position >= _expression.Length || !char.IsDigit(_expression[_position]))
            {
                throw new InvalidOperationException("Expected number");
            }

            var start = _position;
            while (_position < _expression.Length && char.IsDigit(_expression[_position]))
            {
                _position++;
            }

            return int.Parse(_expression.Substring(start, _position - start));
        }

        private void SkipWhitespace()
        {
            while (_position < _expression.Length && char.IsWhiteSpace(_expression[_position]))
            {
                _position++;
            }
        }
    }
}
