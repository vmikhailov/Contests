using NUnit.Framework;

namespace Codewars.Codewars.Passed
{
    [TestFixture]
    public class MiddlePermutationTests
    {
        
        [Test]
        public void BasicTests(){
            var kata=new MiddlePermutationKata();
            
            Assert.AreEqual("bac",kata.MiddlePermutation("abc"));
             
            Assert.AreEqual("bdca",kata.MiddlePermutation("abcd"));
             
            Assert.AreEqual("cbxda",kata.MiddlePermutation("abcdx"));
             
            Assert.AreEqual("cxgdba",kata.MiddlePermutation("abcdxg"));
            
            Assert.AreEqual("dczxgba",kata.MiddlePermutation("abcdxgz"));
            
        }
                 
    }
}