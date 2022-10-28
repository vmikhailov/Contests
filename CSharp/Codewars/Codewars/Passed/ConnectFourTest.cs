using System.Collections.Generic;
using NUnit.Framework;

namespace Codewars.Codewars.Passed
{
    [TestFixture]
    public class ConnectFourTest
    {
        [Test]
        public static void FirstTest()
        {
            var myList = new List<string>()
            {
                "A_Red",
                "B_Yellow",
                "A_Red",
                "B_Yellow",
                "A_Red",
                "B_Yellow",
                "G_Red",
                "B_Yellow"
            };
            StringAssert.AreEqualIgnoringCase("Yellow",ConnectFour.WhoIsWinner(myList),"it should return Yellow");
        }

        [Test]
        public static void SecondTest()
        {
            var myList = new List<string>()
            {
                "C_Yellow",
                "E_Red",
                "G_Yellow",
                "B_Red",
                "D_Yellow",
                "B_Red",
                "B_Yellow",
                "G_Red",
                "C_Yellow",
                "C_Red",
                "D_Yellow",
                "F_Red",
                "E_Yellow",
                "A_Red",
                "A_Yellow",
                "G_Red",
                "A_Yellow",
                "F_Red",
                "F_Yellow",
                "D_Red",
                "B_Yellow",
                "E_Red",
                "D_Yellow",
                "A_Red",
                "G_Yellow",
                "D_Red",
                "D_Yellow",
                "C_Red"
            };
            StringAssert.AreEqualIgnoringCase("Yellow",ConnectFour.WhoIsWinner(myList));
        }
        
        [Test]
        public static void ThirdTest()
        {
            var myList = new List<string>()
            {
                "A_Yellow",
                "B_Red",
                "B_Yellow",
                "C_Red",
                "G_Yellow",
                "C_Red",
                "C_Yellow",
                "D_Red",
                "G_Yellow",
                "D_Red",
                "G_Yellow",
                "D_Red",
                "F_Yellow",
                "E_Red",
                "D_Yellow"
            };
            StringAssert.AreEqualIgnoringCase("Red",ConnectFour.WhoIsWinner(myList),"it should return Red");
        }
    }
}