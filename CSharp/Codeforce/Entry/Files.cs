using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.Entry
{
    public static class Files
    {
        public static IEnumerable<string> Format(IEnumerable<string> paths)
        {
            var stack = new Stack<string>();
            var i = 1;
            foreach (var p in paths.OrderBy(x => x))
            {
                if (stack.Count == 0)
                {
                    stack.Push(p);
                    yield return $"{p}";        
                    continue;
                }
                
                while (true)
                {
                    var current = stack.Peek();
                    var l = current.Length;
                    if (p.StartsWith(current) && p[l] == '/')
                    {
                        var j = p.IndexOf("/", l) + 1;
                        var name = p.Substring(j, p.Length - j);
                        yield return $"{GetIndent(i)}{name}";
                        
                        i++;
                        stack.Push(p);
                        break;
                    }
                    else
                    {
                        stack.Pop();
                        i--;
                    }
                }
            }
        }

        private static IDictionary<int, string> indents = new Dictionary<int, string>();
        private static string GetIndent(int i)
        {
            if (indents.TryGetValue(i, out var indent))
            {
                indents[i] = indent = string.Join("", Enumerable.Repeat("  ", i));    
            }

            return indent;
        }

        public static void Main1()
        {
            var n = int.Parse(Console.ReadLine());
            var p = new List<string>();
            for (var i = 0; i < n; i++)
            {
                p.Add(Console.ReadLine());
            }
            
            foreach (var s in Format(p))
            {
                Console.WriteLine(s);
            }
        }
    
        public static void Test1()
        {
            //int n = 6;
            var p = new[]
            {
                "root/a",
                "root/aa",
                "root/aa/b",
                "root/a/a",
                "root/c/x",
                "root/a/b",
                "root/a/b/c",
                "root",
                "root/c"
            };
            
            foreach (var s in Format(p))
            {
                Console.WriteLine(s);
            }
        }
    }
}