using System;
using System.Linq;
using NUnit.Framework;

namespace Codewars.Codewars.Passed
{
    public class SimpleNumberSequence
    {
        public static int missing(string s)
        {
            for (var i = 1; i < s.Length; i++)
            {
                var n0 = long.Parse(s.Take(i).ToArray());
                if (n0 > int.MaxValue) break;
                var m = -1L;
                var j = i;
                while(j < s.Length)
                { 
                    var len1 = (int)Math.Log10(n0 + 1) + 1;
                    var len2 = (int)Math.Log10(n0 + 2) + 1;
                    var n1 = long.Parse(s.Skip(j).Take(len1).ToArray());
                    var n2 = long.Parse(s.Skip(j).Take(len2).ToArray());

                    if (n1 == n0 + 1)
                    {
                        n0 = n1;
                        j += len1;
                        continue;
                    }

                    if (n2 == n0 + 2 && m == -1)
                    {
                        m = n0 + 1;
                        n0 = n2;
                        j += len2;
                    }
                    else
                    {
                        m = -1;
                        break;
                    }
                }

                if (m != -1)
                {
                    return (int)m;
                }
            }

            return -1;
        }
    }


    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void ExampleTests()
        {
            Assert.AreEqual(999,SimpleNumberSequence.missing("9979981000100110021003"));
            Assert.AreEqual(4,SimpleNumberSequence.missing("123567"));
            Assert.AreEqual(92,SimpleNumberSequence.missing("899091939495"));
            Assert.AreEqual(100,SimpleNumberSequence.missing("9899101102"));
            Assert.AreEqual(-1,SimpleNumberSequence.missing("599600601602"));
            Assert.AreEqual(-1,SimpleNumberSequence.missing("8990919395"));
            Assert.AreEqual(1002,SimpleNumberSequence.missing("998999100010011003"));
            Assert.AreEqual(10000,SimpleNumberSequence.missing("99991000110002"));
            Assert.AreEqual(-1,SimpleNumberSequence.missing("979899100101102"));
            Assert.AreEqual(900003,SimpleNumberSequence.missing("900001900002900004900005900006")); 
   
        }
    }
}