using System;
using NUnit.Framework;

namespace Codewars.Codewars.ExpressionParser.Regex
{
    [TestFixture]
    public class RegexParserTests
    {
        public void shouldBe(string input, string expected)
        {
            Reg.Exp r = Parser.parse(input);
            string result = r == null ? "" : r.ToString();
            bool ok = expected.Equals(result);
            if (!ok) Console.WriteLine($"parse '{input}' = '{result}' shouldBe '{expected}'");
           // Assert.AreEqual(expected, result);
        }

        [Test]
        public void core()
        {
            Reg.Exp list = Reg.str(Reg.zeroOrMore(Reg.normal('a')));
            Console.WriteLine(list);
            Reg.add(list, Reg.normal('b'));
            Console.WriteLine(list);
            Console.WriteLine(
                Reg.add(Reg.add(Reg.add(list, Reg.normal('b')), Reg.or(Reg.normal('c'), Reg.normal('d'))), Reg.zeroOrMore(Reg.normal('e'))));
        }

        [Test]
        public void basicTests()
        {
            //shouldBe("", "");
            //shouldBe(".", ".");
            //shouldBe("a", "a");
            //shouldBe("a|b", "(a|b)");
            // shouldBe("a|b*", "(a|b*)");
            // shouldBe("a*", "a*");
            // shouldBe("(a)", "a");
            // shouldBe("(a)*", "a*");
            // shouldBe("(a|b)*", "(a|b)*");
            // shouldBe("a|b*", "(a|b*)");
            shouldBe("abcd", "(abcd)");
            shouldBe("ab|cd", "((ab)|(cd))");
        }

        [Test]
        public void precedence_examples()
        {
            shouldBe("ab*", "(ab*)");
            shouldBe("(ab)*", "(ab)*");
            shouldBe("ab|a", "((ab)|a)");
            shouldBe("a(b|a)", "(a(b|a))");
            shouldBe("a|b*", "(a|b*)");
            shouldBe("(a|b)*", "(a|b)*");
        }

        [Test]
        public void the_other_examples()
        {
            shouldBe("a", "a");
            shouldBe("ab", "(ab)");
            shouldBe("a.*", "(a.*)");
            shouldBe("(a.*)|(bb)", "((a.*)|(bb))");
        }

        [Test]
        public void invalid_examples()
        {
            shouldBe("", "");
            shouldBe("(", "");
            shouldBe(")(", "");
            shouldBe("*", "");
        }

        [Test]
        public void complex_examples()
        {
            shouldBe("((aa)|ab)*|a", "(((aa)|(ab))*|a)");
            shouldBe("((a.)|.b)*|a", "(((a.)|(.b))*|a)");
        }
    }
}
