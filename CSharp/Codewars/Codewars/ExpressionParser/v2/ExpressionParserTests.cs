using NUnit.Framework;

namespace Codewars.Codewars.ExpressionParser.v2
{
    [TestFixture]
    public class ExpressionParser2Tests
    {
        private readonly Evaluate _ev = new Evaluate();

        [Test]
        public void Eval_Test1()
        {
            Assert.AreEqual("18", _ev.eval("2*3&2"));
        }

        [Test]
        public void Eval_Test2()
        {
            Assert.AreEqual("-240", _ev.eval("(-(2 + 3)* (1 + 2)) * 4 & 2"));
        }

        [Test]
        public void Eval_Test3()
        {
            Assert.AreEqual("ERROR", (_ev.eval("sqrt(-2)*2") + "     ").Substring(0, 5).ToUpper());
        }

        [Test]
        public void Eval_Test4()
        {
            Assert.AreEqual("ERROR", (_ev.eval("2*5/0") + "     ").Substring(0, 5).ToUpper());
        }

        [Test]
        public void Eval_Test5()
        {
            Assert.AreEqual("15.5893529757165", _ev.eval("sqrt(sin(2+3)*cos(1+2)) * 4 & 2"));
        }

        [Test]
        public void Eval_Test6()
        {
            Assert.AreEqual("169", _ev.eval("abs(-(-1+(2*(4--3)))&2)"));
        }
        
        [Test]
        public void Eval_Test7()
        {
            Assert.AreEqual("-27", _ev.eval("3*-3&2"));
        }
        
           
        [Test]
        public void Eval_Test8()
        {
            Assert.AreEqual("-262144", _ev.eval("-4&3&2"));
        }
        
        [Test]
        public void Eval_Test9()
        {
            Assert.AreEqual("-1.16652903957612", _ev.eval("-4&3&-2"));
        }

  
        [Test]
        public void Eval_Test10()
        {
            Assert.AreEqual("-3906251", _ev.eval("-5&3&2*2-1"));
        }
        
        [Test]
        public void Eval_Test11()
        {
            Assert.AreEqual("0.6484371218353193", _ev.eval("sin(cos(-17--2*1e+2))"));
        }
        
        [Test]
        public void Eval_Test12()
        {
            Assert.AreEqual("2386.42541259676", _ev.eval("(Abs(1+(2--17)-3)* sin(3 + -17) / 2.1) -12.3453* 0.45+2.4e3"));
        }
        
        
    }
}
