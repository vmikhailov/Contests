namespace Codewars.Codewars.ExpressionParser.Regex
{
    public enum ExpType
    {
        ZeroOrMore,
        Normal,
        Add,
        Any,
        Or,
        Str,
    }
    
    public enum TokenType
    {
        Dot,
        Star,
        OpenBracket,
        CloseBracket,
        Pipe,
        Symbol,
        End
    }
}