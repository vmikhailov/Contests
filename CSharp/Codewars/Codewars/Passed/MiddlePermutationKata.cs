using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Codewars.Codewars.Passed
{
    public class MiddlePermutationKata
    {
        public string MiddlePermutation(string s)
        {
            return new string(MiddlePermutationImpl(s.OrderBy(x => x).ToList()).ToArray());
        }

        private IEnumerable<char> MiddlePermutationImpl(IList<char> s)
        {
            var c = s.Count;
            var p = (c + 1) / 2 - 1;
            var a = s[p];
            s.RemoveAt(p);
            var tail = c % 2 == 0 ? s.Reverse().ToList() : MiddlePermutationImpl(s);
            return tail.Prepend(a);
        }

        private IEnumerable<char> MiddlePermutationImpl2(IList<char> s)
        {
            var r = new List<char>();
            var c = s.Count;
            var div = Factorial(c) / 2 - 1;
            while (c > 0)
            {
                var perms = Factorial(c - 1);
                var p = (int)(div / perms);
                var letter = s[p];
                r.Add(letter);
                s.RemoveAt(p);
                div -= perms * (div / perms);
                c--;
            }

            return r;
        }

        private static BigInteger Factorial(int n)
        {
            if (n <= 1) return 1;
            else return Factorial(n - 1) * n;
        }
    }
}