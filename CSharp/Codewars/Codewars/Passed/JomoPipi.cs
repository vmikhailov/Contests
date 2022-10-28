using System;
using System.Linq;
using NUnit.Framework;

namespace Codewars.Codewars.Passed
{
    public class JomoPipi
    {
        public static string StringFunc(string s, long x)
        {
            var l = s.Length;
            var c0 = s.ToCharArray();
            var c1 = s.ToCharArray();
            var c2 = new char[l];
            for (var k = 1; k <= x; k++)
            {
                for (int i = 0, g = -1; i < l; i++, g = -g)
                {
                    var j = (l + (i + 1) / 2 * g - 1) % l;
                    c2[i] = c1[j];
                }
                
                if (c2.SequenceEqual(c0))
                {
                    x = x % k;
                    k = 0;
                }
                var c = c1;
                c1 = c2;
                c2 = c;
            }

            return new string(c1);
        }
        
        public static void StringFunc2()
        {
            for (var f = 0; f <= 500 ; f++)
            {
                var s = Enumerable.Range(1, f).ToArray();
                var l = s.Length;
                var c1 = (int[])s.Clone();
                var c2 = new int[l];
                var k = 0;
                //TestContext.WriteLine($"------{l}------");
                //TestContext.WriteLine($"{k} {s}");
                while(true)
                {
                    for (int i = 0, g = -1; i < l; i++, g = -g)
                    {
                        var j = (l + (i + 1) / 2 * g - 1) % l;
                        c2[i] = c1[j];
                    }

                    var c = c1;
                    c1 = c2;
                    c2 = c;
                    //
                    if (s.Zip(c1).All(x => x.First == x.Second))
                    {
                        TestContext.WriteLine($"{f+1} {k + 1} {(f+1) % 4}");
                        break;
                    }
                    
                    k++;
                }
            }
        }

        public static void StringFunc3(int n)
        {
            //var s = Enumerable.Range(0, n).Select(x => (char)('a' + x)).ToArray();
            var s = "0" + new string(Enumerable.Repeat('-', n - 1).ToArray());
            
            var l = s.Length;
            var c1 = s.ToCharArray();
            var c2 = new char[l];
            long k = 0;
            long m = 1;
            var t = 0;
            var p1 = -1;
            TestContext.WriteLine($"------{l}------");
            //TestContext.WriteLine(new string(c1));
            var z = 0;
            while(true)
            {
                z++;
                for (int i = 0, g = -1; i < l; i++, g = -g)
                {
                    var j = (l + (i + 1) / 2 * g - 1) % l;
                    c2[i] = c1[j];
                }

                var c = c1;
                c1 = c2;
                c2 = c;
                var p = Array.IndexOf(c1, '0');
                //TestContext.WriteLine($"{new string(c1)} {p} {2*k + 1} {(2*k + 1) % n}");
                // ReSharper disable once PossibleLossOfFraction
                p1 = (int)Math.Pow(-1, (2*k + 1) / n);
                var v = ((1 << z) * 1) % (n - (n + 1) % 2);
                TestContext.WriteLine($"{p} {2*k + 1} {(2*k + 1) % n} t={(n - (2*k + 1) % n + p1) % n} p={(2*k + 1) / n} {v}");
                k += m;
                m *= 2;
                
                if (2 * k + 1 > n) t++;

                if (t > 8) break;
            }
            TestContext.WriteLine($"");
        }
    }
}