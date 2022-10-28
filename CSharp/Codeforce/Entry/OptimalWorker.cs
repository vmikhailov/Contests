using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.Entry
{
    public static class OptimalWorker
    {
        public static long Compute(string workersStr, string costsStr)
        {
            var workers = workersStr.Split(' ').Select(long.Parse).ToArray();
            var costs = costsStr.Split(' ').Select(long.Parse).ToArray();

            var tree = MakeTree(workers);
            return Compute(tree, costs, 0);
        }

        public static IDictionary<long, IList<long>> MakeTree(long[] workers)
        {
            var gr = new Dictionary<long, IList<long>>();
            for (var i = 0; i < workers.Length; i++)
            {
                var w = workers[i];
                if (!gr.TryGetValue(w, out var nodes))
                {
                    gr[w] = nodes = new List<long>();
                }

                nodes.Add(i + 1);
            }

            return gr;
        }

        
        public static long Compute(IDictionary<long, IList<long>> tree, long[] costs, int root)
        {
            var stack = new Stack<(long, IList<long>, int)>();
            var visited = new HashSet<long>();
           
            var m = long.MaxValue;
            var level = tree[root];
            var i = 0;
            while(i < level.Count)
            {
                var node = level[i];
                
                if (tree.ContainsKey(node) && !visited.Contains(node))
                {
                    stack.Push((m, level, i));
                    level = tree[node];
                    i = 0;
                    m = long.MaxValue;
                    continue;
                }

                i++;
                var v = costs[node - 1];
                if (m > v)
                {
                    m = v;
                }

                if (i == level.Count && stack.Any())
                {
                    var mm = m;
                    (m, level, i) = stack.Pop();
                    costs[level[i] - 1] += mm;
                    visited.Add(level[i]);
                }
            }
           
            return m;
        }

        
        public static long Compute1(IDictionary<long, IList<long>> tree, long[] costs, long root)
        {
            var a = root != 0 ? costs[root - 1] : 0L;
           
            var m = long.MaxValue;
            foreach (var node in tree[root])
            {
                var v = tree.ContainsKey(node) ? Compute1(tree, costs, node) : costs[node - 1];
                if (m > v)
                {
                    m = v;
                }
            }
           
            return a + m;
           
        }

        
        public static void Main1()
        {
            var n = long.Parse(Console.ReadLine());
            var w = Console.ReadLine();
            var c = Console.ReadLine();
            
            Console.WriteLine(Compute(w, c));
        }
    }
}