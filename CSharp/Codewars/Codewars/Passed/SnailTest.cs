using System;
using System.Linq;
using NUnit.Framework;

namespace Codewars.Codewars.Passed
{
    public class SnailTest
    {
        [Test]
        public void SnailTest1()
        {
            int[][] array =
            {
                new []{1, 2, 3},
                new []{4, 5, 6},
                new []{7, 8, 9}
            };
            var r = new[] { 1, 2, 3, 6, 9, 8, 7, 4, 5 };
            Test(array, r);
        }
    
        [Test]
        public void SnailTest2()
        {
            int[][] array =
            {
                new []{ 1,  2,  3, 13},
                new []{ 4,  5,  6, 10},
                new []{ 7,  8,  9, 11},
                new []{12, 18, 19, 20},
            };
            var r = new[] { 1, 2, 3, 13, 10, 11, 20, 19, 18, 12, 7, 4, 5, 6, 9, 8 };
            Test(array, r);
        }

        public string Int2dToString(int[][] a)
        {
            return $"[{string.Join("\n", a.Select(row => $"[{string.Join<int>(",", row)}]"))}]";
        }

        public void Test(int[][] array, int[] result)
        {
            var text = $"{Int2dToString(array)}\nshould be sorted to\n[{string.Join(",", result)}]\n";
            Console.WriteLine(text);
            Assert.AreEqual(result, SnailSolution.Snail(array));
        }
    }
}