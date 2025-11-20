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
            testing(LongestConsecutives.LongestConsec(["zone", "abigail", "theta", "form", "libe", "zas", "theta", "abigail"
            ], 2), "abigailtheta");
            testing(LongestConsecutives.LongestConsec(["ejjjjmmtthh", "zxxuueeg", "aanlljrrrxx", "dqqqaaabbb", "oocccffuucccjjjkkkjyyyeehh"
            ], 1), "oocccffuucccjjjkkkjyyyeehh");
            testing(LongestConsecutives.LongestConsec([], 3), "");
            testing(LongestConsecutives.LongestConsec(["itvayloxrp","wkppqsztdkmvcuwvereiupccauycnjutlv","vweqilsfytihvrzlaodfixoyxvyuyvgpck"
            ], 2), "wkppqsztdkmvcuwvereiupccauycnjutlvvweqilsfytihvrzlaodfixoyxvyuyvgpck");
            testing(LongestConsecutives.LongestConsec(["wlwsasphmxx","owiaxujylentrklctozmymu","wpgozvxxiu"], 2), "wlwsasphmxxowiaxujylentrklctozmymu");
            testing(LongestConsecutives.LongestConsec(["zone", "abigail", "theta", "form", "libe", "zas"], -2), "");
            testing(LongestConsecutives.LongestConsec(["it","wkppv","ixoyx", "3452", "zzzzzzzzzzzz"], 3), "ixoyx3452zzzzzzzzzzzz");
            testing(LongestConsecutives.LongestConsec(["it","wkppv","ixoyx", "3452", "zzzzzzzzzzzz"], 15), "");
            testing(LongestConsecutives.LongestConsec(["it","wkppv","ixoyx", "3452", "zzzzzzzzzzzz"], 0), "");
        }
    }
}