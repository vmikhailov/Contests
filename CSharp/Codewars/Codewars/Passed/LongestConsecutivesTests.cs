using System;
using NUnit.Framework;

namespace Codewars.Codewars.Passed
{
    [TestFixture]
    public static class LongestConsecutivesTests 
    {
        private static void testing(string actual, string expected) 
        {
            Assert.AreEqual(expected, actual);
        }
    
        [Test]
        public static void test1() 
        {        
            Console.WriteLine("Basic Tests");
            testing(LongestConsecutives.LongestConsec(new string[] {"zone", "abigail", "theta", "form", "libe", "zas", "theta", "abigail"}, 2), "abigailtheta");
            testing(LongestConsecutives.LongestConsec(new string[] {"ejjjjmmtthh", "zxxuueeg", "aanlljrrrxx", "dqqqaaabbb", "oocccffuucccjjjkkkjyyyeehh"}, 1), "oocccffuucccjjjkkkjyyyeehh");
            testing(LongestConsecutives.LongestConsec(new string[] {}, 3), "");
            testing(LongestConsecutives.LongestConsec(new string[] {"itvayloxrp","wkppqsztdkmvcuwvereiupccauycnjutlv","vweqilsfytihvrzlaodfixoyxvyuyvgpck"}, 2), "wkppqsztdkmvcuwvereiupccauycnjutlvvweqilsfytihvrzlaodfixoyxvyuyvgpck");
            testing(LongestConsecutives.LongestConsec(new string[] {"wlwsasphmxx","owiaxujylentrklctozmymu","wpgozvxxiu"}, 2), "wlwsasphmxxowiaxujylentrklctozmymu");
            testing(LongestConsecutives.LongestConsec(new string[] {"zone", "abigail", "theta", "form", "libe", "zas"}, -2), "");
            testing(LongestConsecutives.LongestConsec(new string[] {"it","wkppv","ixoyx", "3452", "zzzzzzzzzzzz"}, 3), "ixoyx3452zzzzzzzzzzzz");
            testing(LongestConsecutives.LongestConsec(new string[] {"it","wkppv","ixoyx", "3452", "zzzzzzzzzzzz"}, 15), "");
            testing(LongestConsecutives.LongestConsec(new string[] {"it","wkppv","ixoyx", "3452", "zzzzzzzzzzzz"}, 0), "");
        }
    }
}