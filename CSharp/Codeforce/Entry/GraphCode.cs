using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.Entry
{
    public static class GraphCode
    {
        public static List<int> GetCode(int n, List<int[]> edges)
        {
            var result = new List<int>();
            var graph = new ISet<int>[n + 1];
            
            foreach (var e in edges)
            {
                (graph[e[0]] ?? (graph[e[0]] = new HashSet<int>())).Add(e[1]);
                (graph[e[1]] ?? (graph[e[1]] = new HashSet<int>())).Add(e[0]);
            }

            for (var i = 1; i <= n; i++)
            {
                var j = i; 
                while(j <= i && graph[j].Count == 1)
                {
                    var k = graph[j].First();
                    graph[j].Clear();
                    graph[k].Remove(j);
                    j = k;
                    
                    result.Add(k);
                    if (result.Count == n - 2) return result;
                }
            }
            
            return result;
        }

        public static void Main1()
        {
            var n = int.Parse(Console.ReadLine());
            var v = new List<int[]>();
            for (var i = 0; i < n - 1; i++)
            {
                v.Add(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
            }

            var code = GetCode(n, v);

            Console.WriteLine(string.Join(" ", code));
        }
    }
}