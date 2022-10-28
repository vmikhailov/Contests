using NUnit.Framework;

namespace Codewars.Codewars.Passed
{
    public class JomoPipiTests
    {
        [Test]
        public void TestOfZero()
        {
            var s = "This is a string exemplification!";
            var a = s;
            Assert.AreEqual(a, JomoPipi.StringFunc(s, 0));
        }
        [Test]
        public void The2ndTest()
        {
            var s = "Ohh Man God Damn";
            var a = " nGOnmohaadhMD  ";
            Assert.AreEqual(a, JomoPipi.StringFunc(s, 7));
        }
        [Test]
        public void The3rdTest()
        {
            var s = "Ohh Man God Damnn";
            var a = "haG mnad MhO noDn";
            Assert.AreEqual(a, JomoPipi.StringFunc(s, 19));
        }
        
        [Test]
        public void TestOfOriginalString()
        {
            var s = "String";
            var a = s;
            Assert.AreEqual("nrtgSi", JomoPipi.StringFunc(s, 3));
        }
        
        [Test]
        public void TestOfNumbers5()
        {
            var s = "12345";
            var a = s;
            Assert.AreEqual("51423", JomoPipi.StringFunc(s, 1));
        }
        
        [Test]
        public void TestOfNumbers7()
        {
            var s = "1234567";
            var a = s;
            Assert.AreEqual("7162534", JomoPipi.StringFunc(s, 117));
        }
        
        [Test]
        public void TestOfNumbers4()
        {
            var s = "1234";
            var a = s;
            Assert.AreEqual("4132", JomoPipi.StringFunc(s, 1));
        }
        
        [Test]
        public void TestOfNumbers42()
        {
            var s = "1234";
            var a = s;
            Assert.AreEqual("2431", JomoPipi.StringFunc(s, 32));
        }
        
        [Test]
        public void TestOfNumbers6()
        {
            var s = "123456";
            var a = s;
            Assert.AreEqual("123456", JomoPipi.StringFunc(s, 16));
        }
        
        [Test]
        public void TestOfNumbers9()
        {
            var s = "123456789";
            var a = s;
            Assert.AreEqual("123456789", JomoPipi.StringFunc(s, 26));
        }
        
        //[Test]
        public void EnumPeriod()
        {
            JomoPipi.StringFunc2();
        }
        
                
        //[Test]
        public void EnumPeriod3()
        {
            for (var i = 1; i < 65; i++)
            {
                JomoPipi.StringFunc3(i);
            }
        }
    }
}