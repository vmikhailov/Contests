using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static NUnit.Framework.Assert;

namespace Codewars.Codewars.CrossingSquares
{
    [TestFixture]
    public class KataSquaresTests
    {
        [Test]
        public void ZeroRectangles()
        {
            AreEqual(0, KataSquares2.Calculate(Enumerable.Empty<int[]>()));
        }

        [Test]
        public void OneRectangle()
        {
            AreEqual(1, KataSquares2.Calculate(new[] { new[] { 0, 0, 1, 1 } }));
        }

        [Test]
        public void OneRectangleV2()
        {
            AreEqual(22, KataSquares2.Calculate(new[] { new[] { 0, 4, 11, 6 } }));
        }

        [Test]
        public void TwoRectangles()
        {
            AreEqual(2, KataSquares2.Calculate(new[] { new[] { 0, 0, 1, 1 }, new[] { 1, 1, 2, 2 } }));
        }

        [Test]
        public void TwoRectanglesV2()
        {
            AreEqual(4, KataSquares2.Calculate(new[] { new[] { 0, 0, 1, 1 }, new[] { 0, 0, 2, 2 } }));
        }


        [Test]
        public void ThreeRectangles()
        {
            AreEqual(36, KataSquares2.Calculate(new[] { new[] { 3, 3, 8, 5 }, new[] { 6, 3, 8, 9 }, new[] { 11, 6, 14, 12 } }));
        }

        [Test]
        public void SecondPartiallyCoveringFirst()
        {
            AreEqual(22, KataSquares2.Calculate(new[] { new[] { 2, 0, 4, 4 }, new[] { 1, 1, 5, 6 } }));
        }

        [Test]
        public void FirstPartiallyCoveringSecond()
        {
            AreEqual(22, KataSquares2.Calculate(new[] { new[] { 1, 1, 5, 6 }, new[] { 2, 0, 4, 4 } }));
        }

        [Test]
        public void IntervalTreeTest1()
        {
            AreEqual(
                71,
                KataSquares2.Calculate(
                    new[]
                    {
                        new[] { 1, 1, 5, 5 },
                        new[] { 2, 2, 10, 10 },
                        new[] { 4, 4, 6, 6 }
                    }));
        }

        [Test]
        public void ManyRectangles1()
        {
            var n = 6000;
            var maxX = 1000000;
            var maxY = 1000000;
            var maxDX = 1000;
            var maxDY = 1000;
            var list = new List<int[]>();
            var r = new Random();
            while (n-- > 0)
            {
                var x = r.Next(maxX);
                var y = r.Next(maxY);
                list.Add(new int[] { x, y, x + r.Next(maxDX), y + r.Next(maxDY) });
            }

            KataSquares2.Calculate(list);
        }
        
        
        [Test]
        public void ManyRectangles2()
        {
            var n = 1500;
            var maxX = 1000000;
            var maxY = 1000000;
            var maxDX = 10000;
            var maxDY = 10000;
            var list = new List<int[]>();
            var r = new Random();
            while (n-- > 0)
            {
                var x = r.Next(maxX);
                var y = r.Next(maxY);
                list.Add(new int[] { x, y, x + r.Next(maxDX), y + r.Next(maxDY) });
            }

            KataSquares2.Calculate(list);
        }

        [Test]
        public void ManySmallRectangles()
        {
            var n = 20000;
            var maxX = 100;
            var maxY = 100;
            var maxDX = 10;
            var maxDY = 10;
            var list = new List<int[]>();
            var r = new Random();
            while (n-- > 0)
            {
                var x = r.Next(maxX);
                var y = r.Next(maxY);
                list.Add(new int[] { x, y, x + r.Next(maxDX), y + r.Next(maxDY) });
            }

            KataSquares2.Calculate(list);
        }

        [Test]
        public void ComplexTest1()
        {
            AreEqual(
                21,
                KataSquares2.Calculate(
                    new[]
                    {
                        new[] { 1, 1, 2, 2 }, 
                        new[] { 1, 4, 2, 7 }, 
                        new[] { 1, 4, 2, 6 }, 
                        new[] { 1, 4, 4, 5 }, 
                        new[] { 2, 5, 6, 7 },
                        new[] { 4, 3, 7, 6 },
                    }));
        }
    }
}