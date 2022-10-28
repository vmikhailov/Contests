using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Codewars.Codewars.Passed
{
    public class InfiniteDigitalString
    {
        public static long findPosition(string str)
        {
            var d = str.Select(c => (int)c - (int)'0').ToArray();
            var n = FindNumber(d);
            var p = FindPosition(n.num);
            var nums = AllDigits(int.MaxValue).Skip(13030).Take(20);
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
                for (var shift = 0; shift < nd; shift++)
                {
                    if (shift + nd > digits.Length)
                    {
                        var extendedDigits = digits.Skip(shift).Take(nd - shift).Concat(digits).ToArray();
                        if (ProbeSequence(nd, 0, extendedDigits, out var sequence))
                        {
                            options.Add((sequence, nd, nd-shift));
                            var ss = string.Join(", ", sequence);
                            TestContext.WriteLine($"{ss} nd={nd} shift={nd-shift} ex");
                        }
                        
                        // need to cover 8_99_0 case    
                        var head = GetNumber(nd - shift, 0, extendedDigits);
                        extendedDigits = Digits(head - 1).Concat(digits).ToArray();
                        if (ProbeSequence(nd, 0, extendedDigits, out sequence))
                        {
                            options.Add((sequence, nd, nd-shift));
                            var ss = string.Join(", ", sequence);
                            TestContext.WriteLine($"{ss} nd={nd} shift={nd-shift} -1");
                        }
                    }
                    else if (ProbeSequence(nd, shift, digits, out var sequence))
                    {
                        options.Add((sequence, nd, (nd - shift) % nd));
                        var ss = string.Join(", ", sequence);
                        TestContext.WriteLine($"{ss} nd={nd} shift={(nd - shift) % nd}");
                    }
                }
            }

            if (options.Any())
            {
                var min = options.OrderBy(x => x.sequence[0]).ThenBy(x => x.shift).First();

                return (min.sequence.First(), min.nd, min.shift);
            }

            return ((long)Math.Pow(10, digits.Length), digits.Length + 1, 1);
        }

        private static bool ProbeSequence(in int nd, in int shift, int[] digits, out long[] sequence)
        {
            sequence = null;
            var numbers = new List<long>();
            var len = digits.Length;
            var current = 0L;

            if (shift > 0)
            {
                current = GetNumber(nd, shift, digits) - 1;
                var head = GetNumber(shift, 0, digits);

                if (current % (long)Math.Pow(10, shift) != head) return false;
                numbers.Add(current);
            }

            var position = shift;
            while (position < len)
            {
                var l = current == 0 ? nd : (int)Math.Log10(current + 1) + 1;

                if (digits[position] == 0) return false;
                var next = GetNumber(l, position, digits);
                position += l;

                if (position > digits.Length)
                {
                    //truncated tail
                    if ((current + 1) / (int)Math.Pow(10, position - len) != next) return false;
                    next = current + 1;
                }
                else if (current > 0 && current + 1 != next) return false;

                numbers.Add(next);
                current = next;
            }

            if (numbers.Last() == numbers.First() + numbers.Count - 1)
            {
                sequence = numbers.ToArray();

                return true;
            }

            return false;
        }

        private static long GetNumber(int nd, int shift, int[] digits) =>
            digits.Skip(shift).Take(nd).Select(x => (long)x).Aggregate((x, r) => x * 10 + r);

        private static IEnumerable<int> Digits(long n)
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

        public static IEnumerable<int> AllDigits(long n)
        {
            return Enumerable.Range(1, (int)n).SelectMany(x => Digits(x));
        }
    }
}