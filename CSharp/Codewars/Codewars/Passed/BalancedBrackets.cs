using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Codewars.Codewars.Passed
{
    public class BalancedBrackets
    {
        public static List<string> BalancedParens(int n)
        {
            if (n == 0) return new List<string> { "" };

            var original = Enumerable.Repeat(1, n).Concat(Enumerable.Repeat(-1, n)).ToArray();
            var all = new List<int[]> { original };

            for (var i = 1; i <= n; i++)
            {
                foreach (var c in Combinations(2 * i, 2 * (n - 1)))
                {
                    var instance = (int[])original.Clone();
                    Inverse(instance, c);
                    if (IsValid(instance)) all.Add(instance);
                }
            }

            var result = all.Select(x => new string(x.Select(y => y == 1 ? '(' : ')').ToArray()))
                            .ToList();

            result.Sort();

            return result;
        }

        private static bool IsValid(int[] instance)
        {
            var s = 0;
            foreach (var i in instance)
            {
                s += i;

                if (s < 0) return false;
            }

            return s == 0;
        }

        private static void Inverse(int[] arr, int[] pos)
        {
            foreach (var p in pos)
            {
                arr[p + 1] = -arr[p + 1];
            }
        }

        private static void Inverse(int[] arr, BigInteger pos)
        {
            BigInteger p = 1;
            for (var i = 1; i < arr.Length - 2; i++)
            {
                if ((p & pos) > 0)
                {
                    arr[i] = -arr[i];
                }

                p *= 2;
            }
        }


        private static IEnumerable<int[]> Combinations(int m, int n)
        {
            var result = new int[m];
            var stack = new Stack<int>(m);
            stack.Push(0);
            while (stack.Count > 0)
            {
                var index = stack.Count - 1;
                var value = stack.Pop();
                while (value < n)
                {
                    result[index++] = value++;
                    stack.Push(value);

                    if (index != m) continue;

                    yield return (int[])result.Clone();

                    break;
                }
            }
        }
    }
}
