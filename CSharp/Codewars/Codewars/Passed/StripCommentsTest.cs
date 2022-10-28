using NUnit.Framework;

namespace Codewars.Codewars.Passed
{
    public class StripCommentsTest
    {
        [Test]
        public void StripComments()
        {
            Assert.AreEqual("", StripCommentsSolution.StripComments("#a", new string[] { "#", "$" }));
            Assert.AreEqual(
                "apples, pears\ngrapes\nbananas",
                StripCommentsSolution.StripComments("apples, pears # and bananas\ngrapes\nbananas !apples", new string[] { "#", "!" }));

            Assert.AreEqual("a\nc\nd", StripCommentsSolution.StripComments("a #b\nc\nd $e f g", new string[] { "#", "$" }));
        
        
        }
    }
}