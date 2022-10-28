using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Codewars.Codewars.Passed
{
    public class InfiniteDigitalString2
    {
        public static long findPosition(string str)
        {
            var d = str.Select(c => (int)c - (int)'0').ToArray();
            var n = FindNumber(d);
            var p = FindPosition(n.num);
            var nums = InfiniteDigitalString.AllDigits(int.MaxValue).Skip(3950275).Take(20);
            TestContext.WriteLine(string.Join(", ", nums));
            TestContext.WriteLine($"best: {n.num} nd={n.nd} shift={n.shift} pos={p + n.shift}");
            return p + n.shift;
        }

        private static long FindPosition(long n)
        {
            var p = (int)Math.Log10(n);

            var s = 0L;
            var m = 1L;
            for (var i = 1; i <= p; i++)
            {
                s += i * m * 9;
                m *= 10;
            }

            s += (n - m) * (p + 1);

            return s;
        }

        private static (long num, int nd, int shift) FindNumber(int[] digits)
        {
            var options = new List<(long[] sequence, int nd, int shift)>();
            for (var nd = 1; nd <= digits.Length; nd++)
            {
                if (ProbeSequence(nd, digits, out var sequence))
                {
                    options.Add((sequence, nd, 0));
                    var ss = string.Join(", ", sequence);
                    TestContext.WriteLine($"{ss} nd={nd} shift={0}");
                }

                for (var shift = 1; shift < nd; shift++)
                {
                    var n = GetNumber(digits.Skip(shift).Take(nd - shift));
                    var actualLen = nd;
                    if (digits[0] == 9 && n > 1 && shift == 1)
                    {
                        n--;
                        actualLen = (int)Math.Log10(n) + shift + 1;
                    }
                    var extendedDigits = GetDigits(n).Concat(digits).ToArray();
                    if (ProbeSequence(actualLen, extendedDigits, out sequence))
                    {
                        options.Add((sequence, actualLen, actualLen - shift));
                        var ss = string.Join(", ", sequence);
                        TestContext.WriteLine($"{ss} nd={actualLen} shift={actualLen - shift} ex");
                    }
                }
            }

            if (options.Any())
            {
                var min = options.OrderBy(x => x.sequence[0])
                                 .ThenBy(x => x.shift)
                                 .First();

                return (min.sequence.First(), min.nd, min.shift);
            }

            return (Pow10(digits.Length), digits.Length + 1, 1);
        }

        private static bool ProbeSequence(in int nd, int[] digits, out long[] sequence)
        {
            sequence = null;

            if (digits[0] == 0) return false;
            var numbers = new List<long>();
            var p = nd;
            var n = GetNumber(digits.Take(nd));
            numbers.Add(n);
            while (p < digits.Length)
            {
                var next = GetDigits(n + 1).ToArray();
                var i = 0;
                while (i < next.Length && p < digits.Length && next[i] == digits[p])
                {
                    i++;
                    p++;
                }

                if (p != digits.Length && i != next.Length) return false;
                n = n + 1;
                numbers.Add(n);
            }

            if (numbers.Last() == numbers.First() + numbers.Count - 1)
            {
                sequence = numbers.ToArray();

                return true;
            }

            return false;
        }

        private static long Pow10(int n)
        {
            var r = 1L;
            while (n-- > 0) r *= 10;

            return r;
        }
        
        private static long GetNumber(IEnumerable<int> digits) => digits.Select(x => (long)x).Aggregate((x, r) => x * 10 + r);

        private static IEnumerable<int> GetDigits(long n)
        {
            var p = (long)Math.Pow(10, Math.Floor(Math.Log10(n)));
            while (p > 0)
            {
                var d = (n - n % p) / p;

                yield return (int)d;
                n = n - d * p;
                p = p / 10;
            }
        }
    }
}