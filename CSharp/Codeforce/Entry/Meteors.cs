using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Codewars.Entry
{
    public static class Meteors
    {
        public static List<long> Compute(List<long> meteors)
        {
            var changed = true;
            var current = meteors;
            var next = new List<long>();
            
            while (changed)
            {
                changed = false;
                for (var i = 0; i < current.Count; i++)
                {
                    var a = current[i];
                    var b = i < current.Count - 1 ? current[i + 1] : 0;
                    if (a > 0 && b < 0)
                    {
                        if (a != -b)
                        {
                            next.Add(a > -b ? a : b);
                        }

                        changed = true;
                        i++;
                    }
                    else
                    {
                        next.Add(a);
                    }
                }

                var c = current;
                current = next;
                next = c;
                next.Clear();
            }

            return current;
        }

        public static void Main1()
        {
            var n = int.Parse(Console.ReadLine());
            var m = Console.ReadLine().Split(' ').Select(long.Parse).ToList();
            var r = Compute(m);

            Console.WriteLine(r.Count);
            if (r.Count > 0)
            {
                Console.WriteLine(string.Join(" ", r));
            }
        }

        public static void Test0()
        {
            Assert.AreEqual(new [] { -5, 4 }, Meteors.Compute(new List<long> { -5, 1, -1, 4, -3 }));
        }
        
        public static void Test1()
        {
            Assert.AreEqual(new [] { 10 }, Meteors.Compute(new List<long> { 10, 2, -5 }));
        }
        
        public static void Test2()
        {
            Assert.AreEqual(new int[0], Meteors.Compute(new List<long> { 8, -8 }));
        }
    }
}