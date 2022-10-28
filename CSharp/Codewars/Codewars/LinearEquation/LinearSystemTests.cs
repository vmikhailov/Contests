using NUnit.Framework;

namespace Codewars.Codewars.LinearEquation
{
    [TestFixture]
    public class LinearSystemTests
    {
        [Test]
        public void TestAndVerify01()
        {
            var ls = new LinearSystem();
            var input = "1 -1 -5\r\n2 1 -7";
            var result = ls.Solve(input);
            //should be SOLUTION=(10; -1,5; 2,75)
            //string testResult = Tests.testIt(input, result);
            
            //if (testResult.Length > 0) Assert.Fail(testResult);
            //else Console.WriteLine("'" + result + "' accepted!");
        }
        
        [Test]
        public void TestAndVerify02()
        {
            var ls = new LinearSystem();
            var input = "2 -3 1 2\r\n2 1 -4 9\r\n6 -5 2 17";
            var result = ls.Solve(input);
        }
        
        [Test]
        public void TestAndVerify1()
        {
            var ls = new LinearSystem();
            var input = "1 2 0 7\r\n0 2 4 8\r\n0 5 6 9";
            var result = ls.Solve(input);
            //should be SOLUTION=(10; -1,5; 2,75)
            //string testResult = Tests.testIt(input, result);
            
            //if (testResult.Length > 0) Assert.Fail(testResult);
            //else Console.WriteLine("'" + result + "' accepted!");
        }

        [Test]
        public void TestAndVerify2()
        {
            var ls = new LinearSystem();
            var input = "1 2 0 4 7\r\n0 2 0 2 8\r\n0 0 -1 4 6\r\n1 2 3 2 3";
            var result = ls.Solve(input);
            //string testResult = Tests.testIt(input, result);
            //if (testResult.Length > 0) Assert.Fail(testResult);
            //else Console.WriteLine("'" + result + "' accepted!");
        }

        [Test]
        public void TestAndVerify3()
        {
            var ls = new LinearSystem();
            var input = "1 2 1\r\n1 2 0";
            var result = ls.Solve(input);
            //string testResult = Tests.testIt(input, result);
            //if (testResult.Length > 0) Assert.Fail(testResult);
            //else Console.WriteLine("'" + result + "' accepted!");
        }
        
        [Test]
        public void TestAndVerify4()
        {
            var ls = new LinearSystem();
            var input = "-9 -7 -19 -18\r\n17 4 5 13\r\n-13 6 -2 -9";
            var result = ls.Solve(input);
        }
        
        [Test]
        public void TestAndVerify5()
        {
            var ls = new LinearSystem();
            var input = "-4 4 -17 -6\r\n8 -14 -17 -10\r\n17 18 4 19";
            var result = ls.Solve(input);
        }
        
        [Test]
        public void TestAndVerify6()
        {
            var ls = new LinearSystem();
            var input = "1 2 0 0 4 2 7\r\n0 0 3 4 -4 2 8\r\n0 5 6 0 -1 3 9\r\n1 2 0 0 1 1 7\r\n-2 0 3 4 2 8 8\r\n0 5 6 0 1 2 9";
            var result = ls.Solve(input);
        }
        
        [Test]
        public void TestAndVerify7()
        {
            var ls = new LinearSystem();
            var input = "12 -8 -17 9\r\n8 12 -6 -10\r\n12 6 -7 8";
            var result = ls.Solve(input);
        }
        
        [Test]
        public void TestUnsolvable1()
        {
            var ls = new LinearSystem();
            var input = "1 2 0 0 7\r\n0 3 4 0 8\r\n0 0 5 6 9";
            var result = ls.Solve(input);
        }
    }
}