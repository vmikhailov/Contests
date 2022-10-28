using NUnit.Framework;

namespace Codewars.Codewars.Skyscrapers
{
    [TestFixture]
    public class SkyscraperTests4X4
    {
        [Test]
        public void SolveSkyscrapers1()
        {
            var clues = new[]
            {
                2, 2, 1, 3,
                2, 2, 3, 1,
                1, 2, 2, 3,
                3, 2, 1, 3
            };

            var expected = new[]
            {
                new[] { 1, 3, 4, 2 },
                new[] { 4, 2, 1, 3 },
                new[] { 3, 4, 2, 1 },
                new[] { 2, 1, 3, 4 }
            };

            var actual = Skyscrapers.SolvePuzzle(4, clues);
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void SolveSkyscrapers2()
        {
            var clues = new[]
            {
                0, 0, 1, 2,
                0, 2, 0, 0,
                0, 3, 0, 0,
                0, 1, 0, 0
            };

            var expected = new[]
            {
                new[] { 2, 1, 4, 3 },
                new[] { 3, 4, 1, 2 },
                new[] { 4, 2, 3, 1 },
                new[] { 1, 3, 2, 4 }
            };

            var actual = Skyscrapers.SolvePuzzle(4, clues);
            CollectionAssert.AreEqual(expected, actual);
        }
    }

    [TestFixture]
    public class SkyscraperTests6X6
    {
        [Test]
        public void SolvePuzzle1()
        {
            var clues = new[]
            {
                3, 2, 2, 3, 2, 1,
                1, 2, 3, 3, 2, 2,
                5, 1, 2, 2, 4, 3,
                3, 2, 1, 2, 2, 4
            };

            var expected = new[]
            {
                new[] { 2, 1, 4, 3, 5, 6 },
                new[] { 1, 6, 3, 2, 4, 5 },
                new[] { 4, 3, 6, 5, 1, 2 },
                new[] { 6, 5, 2, 1, 3, 4 },
                new[] { 5, 4, 1, 6, 2, 3 },
                new[] { 3, 2, 5, 4, 6, 1 }
            };

            var actual = Skyscrapers.SolvePuzzle(6, clues);
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void SolvePuzzle2()
        {
            var clues = new[]
            {
                0, 0, 0, 2, 2, 0,
                0, 0, 0, 6, 3, 0,
                0, 4, 0, 0, 0, 0,
                4, 4, 0, 3, 0, 0
            };

            var expected = new[]
            {
                new[] { 5, 6, 1, 4, 3, 2 },
                new[] { 4, 1, 3, 2, 6, 5 },
                new[] { 2, 3, 6, 1, 5, 4 },
                new[] { 6, 5, 4, 3, 2, 1 },
                new[] { 1, 2, 5, 6, 4, 3 },
                new[] { 3, 4, 2, 5, 1, 6 }
            };

            var actual = Skyscrapers.SolvePuzzle(6, clues);
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void SolvePuzzle3()
        {
            var clues = new[]
            {
                0, 3, 0, 5, 3, 4,
                0, 0, 0, 0, 0, 1,
                0, 3, 0, 3, 2, 3,
                3, 2, 0, 3, 1, 0
            };

            var expected = new[]
            {
                new[] { 5, 2, 6, 1, 4, 3 },
                new[] { 6, 4, 3, 2, 5, 1 },
                new[] { 3, 1, 5, 4, 6, 2 },
                new[] { 2, 6, 1, 5, 3, 4 },
                new[] { 4, 3, 2, 6, 1, 5 },
                new[] { 1, 5, 4, 3, 2, 6 }
            };

            var actual = Skyscrapers.SolvePuzzle(6, clues);
            CollectionAssert.AreEqual(expected, actual);
        }
    }

    [TestFixture]
    public class SkyscraperTests7X7
    {
        static readonly int[][] Clues = new[]
        {
            new[]
            {
                7, 0, 0, 0, 2, 2, 3,
                0, 0, 3, 0, 0, 0, 0,
                3, 0, 3, 0, 0, 5, 0,
                0, 0, 0, 0, 5, 0, 4
            },
            new[]
            {
                0, 2, 3, 0, 2, 0, 0,
                5, 0, 4, 5, 0, 4, 0,
                0, 4, 2, 0, 0, 0, 6,
                5, 2, 2, 2, 2, 4, 1
            },
            new[]
            {
                0, 0, 0, 5, 0, 0, 3, 0, 6, 3, 4, 0, 0, 0, 3, 0, 0, 0, 2, 4, 0, 2, 6, 2, 2, 2, 0, 0
            },
            new[]
            {
                0, 0, 5, 3, 0, 2, 0, 0, 0, 0, 4, 5, 0, 0, 0, 0, 0, 3, 2, 5, 4, 2, 2, 0, 0, 0, 0, 5
            },
            new[]
            {
                0, 2, 3, 0, 2, 0, 0, 5, 0, 4, 5, 0, 4, 0, 0, 4, 2, 0, 0, 0, 6, 5, 2, 2, 2, 2, 4, 1
            },
            new[]
            {
                0, 2, 3, 0, 2, 0, 0, 5, 0, 4, 5, 0, 4, 0, 0, 4, 2, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0
            },
            new[]
            {
                0, 2, 3, 0, 2, 0, 0, 5, 0, 4, 5, 0, 4, 0, 0, 4, 2, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0
            },
            new[]
            {
                0, 0, 0, 0, 5, 0, 4, 7, 0, 0, 0, 2, 2, 3, 0, 0, 3, 0, 0, 0, 0, 3, 0, 3, 0, 0, 5, 0
            }
        };

        static readonly int[][][] Expected = new[]
        {
            new[]
            {
                new[] { 1, 5, 6, 7, 4, 3, 2 },
                new[] { 2, 7, 4, 5, 3, 1, 6 },
                new[] { 3, 4, 5, 6, 7, 2, 1 },
                new[] { 4, 6, 3, 1, 2, 7, 5 },
                new[] { 5, 3, 1, 2, 6, 4, 7 },
                new[] { 6, 2, 7, 3, 1, 5, 4 },
                new[] { 7, 1, 2, 4, 5, 6, 3 }
            },
            new[]
            {
                new[] { 7, 6, 2, 1, 5, 4, 3 },
                new[] { 1, 3, 5, 4, 2, 7, 6 },
                new[] { 6, 5, 4, 7, 3, 2, 1 },
                new[] { 5, 1, 7, 6, 4, 3, 2 },
                new[] { 4, 2, 1, 3, 7, 6, 5 },
                new[] { 3, 7, 6, 2, 1, 5, 4 },
                new[] { 2, 4, 3, 5, 6, 1, 7 }
            },
            new int[0][],
            new int[0][],
            new int[0][],
            new int[0][],
            new int[0][],
            new int[0][]
        };


        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(6)]
        [TestCase(7)]
        public void Test(int i)
        {
            var actual = Skyscrapers.SolvePuzzle(7, Clues[i]);
            if(Expected[i].Length > 0)
                CollectionAssert.AreEqual(Expected[i], actual);
        }
    }
}