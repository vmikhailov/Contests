using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Codewars.Other
{
    public class Braces1
    {
        public static void Compute(int n)
        {
            var r = new List<string>();
            EnumBraces(n, r);
            TestContext.WriteLine(r.Count);
            if (n < 7)
            {
                foreach (var br in r)
                {
                    TestContext.WriteLine(br);
                }
            }
        }

        public static void EnumBraces(int n, List<string> result)
        {
            EnumBraces(0, n, new char[n], result);
        }

        private static void EnumBraces(int p, int n, char[] chars, List<string> result)
        {
            if (n == 0)
            {
                if (p == 0)
                {
                    result.Add(new string(chars));
                }

                return;
            }

            var i = chars.Length - n;
            chars[i] = '(';
            EnumBraces(p + 1, n - 1, chars, result);
            if (p > 0)
            {
                chars[i] = ')';
                EnumBraces(p - 1, n - 1, chars, result);
            }
        }
    }

    public class Braces2
    {
        private static string _braces = "()[]";

        private char[] _chars;
        private Stack<char> _stack;
        private List<string> _result;
        private int _n;

        public static void Compute(int n)
        {
            var b = new Braces2(n);
            b.EnumBraces();
            TestContext.WriteLine(b._result.Count);
            if (n < 7)
            {
                foreach (var br in b._result)
                {
                    TestContext.WriteLine(br);
                }
            }
        }

        public Braces2(int n)
        {
            _n = n;
            _chars = new char[n];
            _stack = new Stack<char>();
            _result = new List<string>();
        }

        private void EnumBraces() => EnumBraces(_n);

        private void EnumBraces(int n)
        {
            if (n == 0)
            {
                if (_stack.Count == 0)
                {
                    _result.Add(new string(_chars));
                }

                return;
            }
            
            var i = _chars.Length - n;
            for (var j = 0; j < _braces.Length; j++)
            {
                var brace = _braces[j];
                _chars[i] = brace;
                if (j % 2 == 0)
                {
                    //if (_stack.Count < _n / 2)
                    {
                        _stack.Push(brace);
                        EnumBraces(n - 1);
                        _stack.Pop();
                    }
                }
                else
                {
                    if (_stack.Count == 0 || _stack.Peek() != _braces[j - 1]) continue;
                    var b = _stack.Pop();
                    EnumBraces(n - 1);
                    _stack.Push(b);
                }
            }
        }
    }

    public class Braces3
    {
        private static string _braces = "()[]";

        public static void Compute(int n)
        {
            var r = new List<string>();
            EnumBraces(n, r);
            TestContext.WriteLine(r.Count);
            if (n < 7)
            {
                foreach (var br in r)
                {
                    TestContext.WriteLine(br);
                }
            }
        }

        public static void EnumBraces(int n, List<string> result)
        {
            var bracesStack = new Stack<char>();
            var processingStack = new Stack<(int, char?)>();
            var chars = new char[n];

            var i = 0;
            var j = 0;
            
            while (true)
            {
                if (j == _braces.Length)
                {
                    while (processingStack.Count > 0 && j == _braces.Length)
                    {
                        var (jj, b) = processingStack.Pop();
                        j = jj + 1;

                        if (b != null)
                        {
                            bracesStack.Push(b.Value);
                        }
                        else
                        {
                            bracesStack.Pop();
                        }

                        i--;
                    }

                    if (processingStack.Count == 0 && j == _braces.Length)
                    {
                        break;
                    }
                }

                var brace = chars[i] = _braces[j];
                if (j % 2 == 0)
                {
                    if (bracesStack.Count < n / 2)
                    {
                        bracesStack.Push(brace);
                        processingStack.Push((j, null));
                    }
                    else
                    {
                        j++;
                        continue;
                    }
                }
                else
                {
                    if (!bracesStack.TryPeek(out var prev) || prev != _braces[j - 1])
                    {
                        j++;
                        continue;
                    }
                    
                    processingStack.Push((j, bracesStack.Pop()));
                }
                
                j = 0;
                i++;

                if (i == n)
                {
                    if (bracesStack.Count == 0)
                    {
                        result.Add(new string(chars));
                    }

                    //will pop up
                    j = _braces.Length;
                }
            }
        }
    }


    [TestFixture]
    public class Brace1Test
    {
        private int n = 20;

        [Test]
        public void Test1()
        {
            Braces1.Compute(n);
        }

        [Test]
        public void Test2()
        {
            Braces2.Compute(n);
        }
        
        [Test]
        public void Test3()
        {
            Braces3.Compute(n);
        }
    }
}