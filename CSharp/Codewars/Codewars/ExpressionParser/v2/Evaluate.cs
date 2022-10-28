using System;
using System.Linq.Expressions;

namespace Codewars.Codewars.ExpressionParser.v2
{
    public class Evaluate
    {
        public string eval(string text)
        {
            var t = new Tokenizer(text);
            var p = new Parser(t);
            if (p.Parse(out var exp))
            {
                var lambda = Expression.Lambda<Func<double>>(exp);
                var func = lambda.Compile();

                try
                {
                    var r = func();

                    if (double.IsNaN(r) || double.IsInfinity(r)) return "ERROR";

                    return r.ToString("G15");
                }
                catch (ArithmeticException)
                {
                    return "ERROR";
                }
            }

            return "ERROR";
        }
    }
}