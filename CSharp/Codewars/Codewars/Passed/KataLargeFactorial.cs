using System;
using System.Collections;
using System.Linq;
using System.Numerics;
using System.Reflection;

namespace Codewars.Codewars.Passed
{
    public class KataLargeFactorial
    {
        public static string Factorial(int n)
        {
            if (n <= 2) return n.ToString();
            
            var len = (int)Enumerable.Range(1, n).Sum(x => Math.Log2(x)) + 2;
            var f = new BitArray(len);
            Increment(f);
            
            var m = new BitArray(len);
            Increment(m);

            for (var i = 2; i <= n; i++)
            {
                Increment(m);
                f = Multiply(f, m);
            }

            return Value(f).ToString();
        }
        
        public static string Factorial2(int n)
        {
            if (n <= 2) return n.ToString();
            
            var len = (int)Enumerable.Range(1, n).Sum(x => Math.Log2(x)) + 2;
            var f = new BitArray(len);
            Increment(f);

            for (var i = 2; i <= n; i++)
            {
                f = Multiply(f, i);
            }

            return Value(f).ToString();
        }

        public static BigInteger FF2(BigInteger n)
        {
            if (n <= 2) return n;
            else return n * FF2(n - 1);
        }
        
        public static object FF(int n)
        {
            if (n <= 2) return n;

            var t = typeof(Complex).Assembly.GetType("System.Numerics.Big"+"Integer");
            var m = t.GetMethod("Multiply");
            var o = Activator.CreateInstance(t, 1);
            return FFImpl(o, t, m, n - 1);
        }
        
        public static object FFImpl(object o, Type t,  MethodInfo mul, int n)
        {
            while (n > 1)
            {
                var m = Activator.CreateInstance(t, n);
                o = mul.Invoke(o, new [] { o, m });
                n--;
            }

            return o;
        }

        private static void Increment(BitArray n)
        {
            var overflow = true;
            for (var i = 0; i < n.Length && overflow; i++)
            {
                if (!n[i])
                {
                    n[i] = true;
                    overflow = false;
                }
                else
                {
                    n[i] = false;
                }
            }
        }

        private static BitArray Add(BitArray a, BitArray b)
        {
            var overflow = false;
            var r = new BitArray(Math.Max(a.Length, b.Length));
            var len = Math.Max(MaxBit(a), MaxBit(b));
            for (var i = 0; i <= len; i++)
            {
                if (a[i] || b[i])
                {
                    if (a[i] && b[i])
                    {
                        r[i] = overflow;
                        overflow = true;
                    }
                    else
                    {
                        r[i] = !overflow;
                    }
                }
                else
                {
                    r[i] = overflow;
                    overflow = false;
                }
            }

            return r;
        }

        private static BitArray Multiply(BitArray a, BitArray b)
        {
            var r = new BitArray(Math.Max(a.Length, b.Length));
            var c = new BitArray(a);
            for (var i = 0; i <= MaxBit(b); i++)
            {
                if (b[i]) r = Add(r, c);

                c.LeftShift(1);
            }

            return r;
        }
        
        private static BitArray Multiply(BitArray a, long n)
        {
            var r = new BitArray(a.Length);
            var c = new BitArray(a);
            while(n > 0)
            {
                if (n % 2 == 1) r = Add(r, c);
                n = n >> 1;
                c.LeftShift(1);
            }

            return r;
        }

        private static long Power(long b, long p)
        {
            var r = 1L;
            while (p-- > 0) r *= b;

            return r;
        }

        private static int MaxBit(BitArray n)
        {
            var i = n.Length - 1;
            while (!n[i] && i > 0) i--;

            return i + 1;
        }

        private static BigInteger Value(BitArray n)
        {
            BigInteger m = 1;
            BigInteger v = 0;
            for (var i = 0; i < n.Length; i++)
            {
                if (n[i]) v += m;
                m *= 2;
            }

            return v;
        }
    }
}