namespace Codewars.Codewars.ExpressionParser.Regex
{
    public class Reg
    {
        public class Exp
        {
            public ExpType Type { get; }
            public object[] Args { get; }

            public Exp(ExpType type, params object[] args)
            {
                Type = type;
                Args = args;
            }
        }

        public static Exp add(Exp left, Exp right)
        {
            return new Exp(ExpType.Add, left, right);
        }
        
        public static Exp normal(char ch)
        {
            return new Exp(ExpType.Normal, ch);
        }
        
        public static Exp or(Exp left, Exp right)
        {
            return new Exp(ExpType.Or, left, right);
        }

        public static Exp zeroOrMore(Exp ex)
        {
            return new Exp(ExpType.ZeroOrMore, ex);
        }
        
        public static Exp any()
        {
            return new Exp(ExpType.Any, null);
        }
        
        public static Exp str(Exp ex)
        {
            return new Exp(ExpType.Str, ex);
        }
    }
}