using System;
using System.Linq;
using NUnit.Framework;

namespace Codewars.Entry
{
    public class Pool
    {
        private const double Epsilon = 1e-8;

        public static double FlatCompute(int w, int d, double s)
        {
            var f = w / 2.0;
            var z = 0d;
            while (s > 0)
            {
                f = Math.Min(s, f);
                s -= f;
                z += f * d;
                d *= -1;
                f = w;
            }

            return z;
        }
        
        public static (double x, double y) Compute(int w, int h, int a, double s)
        {
            var x = 0d;
            var y = 0d;
            if (a == 0 || a == 180)
            {
                x = FlatCompute(w, a == 0 ? 1 : -1, s);
                return (x, y);
            }
            
            if (a == 90 || a == 270)
            {
                y = FlatCompute(h, a == 90 ? 1 : -1, s);
                return (x, y);
            }
            
            
            while (Math.Abs(s) > Epsilon)
            {
                var r = a * Math.PI / 180;
                var cr = Math.Cos(r);
                var sr = Math.Sin(r);
                
                var dx = Math.Sign(cr);
                var dy = Math.Sign(sr);
                
                var mw = (dx > 0 ? w / 2.0 - x : w / 2.0 + x) * dx; //max w
                var mh = (dy > 0 ? h / 2.0 - y : h / 2.0 + y) * dy; //max h

                var sw = mh * cr / sr; // fact w
                var sh = mw * sr / cr; // fact h
                var d = Math.Abs(sh) < Math.Abs(mh);
                
                var dw = d ? mw : sw;
                var dh = d ? sh : mh;
                var da = d ? 180 : 360;
                
                var ds = dw / cr;
                if (ds > s)
                {
                    dw = s * cr;
                    dh = s * sr;
                    ds = s;
                }
                    
                x += dw;
                y += dh;
                s -= ds;
                a = da - a;
            }

            return (x , y);
        }

        public static void Main1()
        {
            var s = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var v = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var coords = Compute(s[0], s[1], v[0], v[1]);

            Console.WriteLine($"{coords.x:F8} {coords.y:F8}");
        }
    }

    public static class PoolTest
    {
        public static void Test1()
        {
            var c = Pool.Compute(8, 6, 30, 15);

            Assert.IsTrue(Math.Abs(-3.009618943233 - c.x) < 1e-6);
            Assert.IsTrue(Math.Abs(-1.500000000000 - c.y) < 1e-6);
        }
        
        public static void Test2()
        {
            var c = Pool.Compute(6, 6, 45, 10);
            Assert.IsTrue(Math.Abs(-1.071067811865 - c.x) < 1e-6);
            Assert.IsTrue(Math.Abs(-1.071067811865 - c.y) < 1e-6);
        }
        
          
        public static void Test3()
        {
            var c = Pool.Compute(6, 6, 0, 10);
            Assert.IsTrue(Math.Abs(-2 - c.x) < 1e-6);
            Assert.IsTrue(Math.Abs( 0 - c.y) < 1e-6);
            
            var c1 = Pool.Compute(6, 6, 0, 11);
            Assert.IsTrue(Math.Abs(-1 - c1.x) < 1e-6);
            Assert.IsTrue(Math.Abs( 0 - c1.y) < 1e-6);
            
            var c2 = Pool.Compute(6, 6, 0, 12);
            Assert.IsTrue(Math.Abs( 0 - c2.x) < 1e-6);
            Assert.IsTrue(Math.Abs( 0 - c2.y) < 1e-6);
            
            var c3 = Pool.Compute(6, 6, 0, 13);
            Assert.IsTrue(Math.Abs( 1 - c3.x) < 1e-6);
            Assert.IsTrue(Math.Abs( 0 - c3.y) < 1e-6);
            
            var c4 = Pool.Compute(6, 6, 180, 13);
            Assert.IsTrue(Math.Abs(-1 - c4.x) < 1e-6);
            Assert.IsTrue(Math.Abs( 0 - c4.y) < 1e-6);
        }
        
        public static void Test4()
        {
            var c = Pool.Compute(6, 8, 90, 6);
            Assert.IsTrue(Math.Abs(0 - c.x) < 1e-6);
            Assert.IsTrue(Math.Abs(2 - c.y) < 1e-6);
        }
    }

}