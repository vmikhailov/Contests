using NUnit.Framework;

namespace Codewars.Codewars.ExpressionParser.v2noFunctions
{
    [TestFixture]
    public class ExpressionParserTests
    {
        private readonly Evaluate _ev = new Evaluate();

        [Test]
        public void Eval_Test1()
        {
            Assert.AreEqual("18", _ev.calculate("2*3^2"));
        }

        [Test]
        public void Eval_Test2()
        {
            Assert.AreEqual("-240", _ev.calculate("(-(2 + 3)* (1 + 2)) * 4 ^ 2"));
        }

        [Test]
        public void Eval_Test4()
        {
            Assert.AreEqual("ERROR", (_ev.calculate("2*5/0") + "     ").Substring(0, 5).ToUpper());
        }

        [Test]
        public void Eval_Test7()
        {
            Assert.AreEqual("-27", _ev.calculate("3*-3^2"));
        }
        
           
        [Test]
        public void Eval_Test8()
        {
            Assert.AreEqual("-262144", _ev.calculate("-4^3^2"));
        }
        
        [Test]
        public void Eval_Test9()
        {
            Assert.AreEqual("-1.16652903957612", _ev.calculate("-4^3^-2"));
        }

  
        [Test]
        public void Eval_Test10()
        {
            Assert.AreEqual("-3906251", _ev.calculate("-5^3^2*2-1"));
        }
    }
}
