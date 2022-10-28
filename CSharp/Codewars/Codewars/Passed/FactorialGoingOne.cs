using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Codewars.Codewars
{
    public class FactorialGoingZero
    {
        public static double going(int n)
        {
            double r = 1;
            var i = n;
            var m = 1L;
            while (i > 1)
            {
                m *= i;
                var a = 1d / m;

                if (a < 1e-7) break;
                r += a;
                i--;
            }

            return Math.Round(r, 6, MidpointRounding.ToZero);
        }
    }


    [TestFixture]
    [DefaultFloatingPointTolerance(.000002)]
    public class SuiteTests
    {
        [Test]
        public void Test01()
        {
            Assert.AreEqual(1.275, FactorialGoingZero.going(5));
        }

        [Test]
        public void Test02()
        {
            Assert.AreEqual(1.2125, FactorialGoingZero.going(6));
        }

        [Test]
        public void Test03()
        {
            Assert.AreEqual(1.173214, FactorialGoingZero.going(7));
        }
    }

    public static class KataRepetition
    {
        public static string StringLetterCount(string str)
        {
            return str.Where(char.IsLetter)
                      .Select(char.ToLower)
                      .GroupBy(x => x)
                      .OrderBy(x => x.Key)
                      .Select(x => $"{x.Count()}{x.Key}")
                      .Aggregate((x, r) => $"{x}{r}");
        }

        public static Tuple<char?, int> LongestRepetition(string input)
        {
            if (string.IsNullOrEmpty(input)) return new Tuple<char?, int>(null, 0);
            var p = (char)0;
            var s = 0;
            var list = new List<(char, int)>();
            foreach (var c in input)
            {
                if (c == p) s++;
                else
                {
                    if (p > 0) list.Add((p, s));
                    p = c;
                    s = 1;
                }
            }

            if (p > 0) list.Add((p, s));

            var a = list.OrderBy(x => -x.Item2).FirstOrDefault();

            return new Tuple<char?, int>(a.Item1, a.Item2);
        }
    }


    [TestFixture]
    public class ExampleTests
    {
        [Test]
        public void LongestAtTheBeginning()
        {
            Assert.AreEqual(new Tuple<char?, int>('a', 4), KataRepetition.LongestRepetition("aaaabb"));
            Assert.AreEqual(new Tuple<char?, int>('b', 5), KataRepetition.LongestRepetition("abbbbb"));
        }

        [Test]
        public void LongestAtTheEnd()
        {
            Assert.AreEqual(new Tuple<char?, int>('a', 4), KataRepetition.LongestRepetition("bbbaaabaaaa"));
        }

        [Test]
        public void LongestInTheMiddle()
        {
            Assert.AreEqual(new Tuple<char?, int>('u', 3), KataRepetition.LongestRepetition("cbdeuuu900"));
        }

        [Test]
        public void MultipleLongest()
        {
            Assert.AreEqual(new Tuple<char?, int>('a', 2), KataRepetition.LongestRepetition("aabb"));
            Assert.AreEqual(new Tuple<char?, int>('b', 1), KataRepetition.LongestRepetition("ba"));
        }

        [Test]
        public void EmptyString()
        {
            Assert.AreEqual(new Tuple<char?, int>(null, 0), KataRepetition.LongestRepetition(""));
        }
    }
}