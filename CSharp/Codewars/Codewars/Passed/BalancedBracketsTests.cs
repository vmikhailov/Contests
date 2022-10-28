using System.Collections.Generic;
using NUnit.Framework;

namespace Codewars.Codewars.Passed
{
    public class BalancedBracketsTests
    {
        [Test]
        public void TestExample()
        {
            var warriorsList = new List<string>();
            //test for n = 0
            warriorsList = BalancedBrackets.BalancedParens(0);
            Assert.AreEqual(new List<string> { "" }, warriorsList);
            //test for n = 1
            warriorsList = BalancedBrackets.BalancedParens(1);
            Assert.AreEqual(new List<string> { "()" }, warriorsList);
            //test for n = 2
            warriorsList = BalancedBrackets.BalancedParens(2);
            warriorsList.Sort();
            Assert.AreEqual(new List<string> { "(())", "()()" }, warriorsList);
            //test for n = 3
            warriorsList = BalancedBrackets.BalancedParens(3);
            warriorsList.Sort();
            Assert.AreEqual(new List<string> { "((()))", "(()())", "(())()", "()(())", "()()()" }, warriorsList);
        }

        [Test]
        public void TestExample4()
        {
            //test for n = 4
            var warriorsList = BalancedBrackets.BalancedParens(4);
            warriorsList.Sort();
            Assert.AreEqual(
                new List<string>
                {
                    "(((())))", "((()()))", "((())())", "((()))()", "(()(()))",
                    "(()()())", "(()())()", "(())(())", "(())()()", "()((()))",
                    "()(()())", "()(())()", "()()(())", "()()()()"
                },
                warriorsList);
        }
    
        [Test]
        public void TestExampleVeryBig()
        {
            var warriorsList = BalancedBrackets.BalancedParens(20);
        }
    }
}